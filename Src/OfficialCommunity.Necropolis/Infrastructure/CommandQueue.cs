using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using OfficialCommunity.Necropolis.Domains.Commands;

namespace OfficialCommunity.Necropolis.Infrastructure
{
    public abstract class CommandQueue<TCommand, TResponse> : IDisposable
            where TCommand : ICommand
    {
        #region IDisposable

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _queue.CompleteAdding();
            }
            _disposed = true;
        }

        // Destructor 
        ~CommandQueue()
        {
            Dispose(false);
        }

        #endregion //IDisposable

        private class WorkItem
        {
            public readonly TCommand Command;
            public readonly TaskCompletionSource<TResponse> TaskSource;
            public readonly Func<TCommand, Task<TResponse>> Work;
            public readonly CancellationToken? CancelToken;

            public WorkItem(
                TCommand command,
                TaskCompletionSource<TResponse> taskSource,
                Func<TCommand, Task<TResponse>> action,
                CancellationToken? cancelToken)
            {
                Command = command;
                TaskSource = taskSource;
                Work = action;
                CancelToken = cancelToken;
            }
        }

        private readonly BlockingCollection<WorkItem> _queue = new BlockingCollection<WorkItem>();

        protected CommandQueue(int workerCount)
        {
            // Create and start a separate Task for each consumer:
            for (var i = 0; i < workerCount; i++)
                Task.Run(async () => await Consume());
        }

        protected async Task<TResponse> Ask(TCommand command
            , Func<TCommand, Task<TResponse>> work
            , CancellationToken? cancelToken
            )
        {
            var tcs = new TaskCompletionSource<TResponse>(command);
            _queue.Add(new WorkItem(command, tcs, work, cancelToken));
            return await tcs.Task;
        }

        private async Task Consume()
        {
            foreach (var workItem in _queue.GetConsumingEnumerable())
            {
                if (workItem.CancelToken.HasValue &&
                    workItem.CancelToken.Value.IsCancellationRequested)
                {
                    workItem.TaskSource.SetCanceled();
                }
                else
                {
                    try
                    {
                        var result = await workItem.Work(workItem.Command);
                        workItem.TaskSource.SetResult(result);
                    }
                    catch (OperationCanceledException ex)
                    {
                        if (ex.CancellationToken == workItem.CancelToken)
                            workItem.TaskSource.SetCanceled();
                        else
                            workItem.TaskSource.SetException(ex);
                    }
                    catch (Exception ex)
                    {
                        workItem.TaskSource.SetException(ex);
                    }
                }
            }
        }
    }
}
