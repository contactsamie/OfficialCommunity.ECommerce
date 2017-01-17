namespace OfficialCommunity.Necropolis.Domains.Infrastructure
{
    public interface IStandardResponse<T>
    {
        bool HasError { get; }

        T Response { get; set; }

        StandardError StandardError { get; set; }
    }
}
