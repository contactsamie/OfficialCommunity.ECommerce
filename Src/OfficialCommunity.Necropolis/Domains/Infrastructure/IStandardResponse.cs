namespace OfficialCommunity.Necropolis.Domains.Infrastructure
{
    public interface IStandardResponse<T>
    {
        bool HasError { get; }

        T Response { get; set; }

        IStandardError StandardError { get; set; }
    }
}
