namespace OfficialCommunity.ECommerce.Nuvango.Infrastructure
{
    public interface ISessionConfiguration
    {
        string GetEndPoint();
        string GetToken();
    }
}