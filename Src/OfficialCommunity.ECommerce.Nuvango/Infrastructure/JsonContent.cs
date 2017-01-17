using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace OfficialCommunity.ECommerce.Nuvango.Infrastructure
{
    public class JsonContent<T> : StringContent
    {
        public JsonContent(T obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        { }
    }
}
