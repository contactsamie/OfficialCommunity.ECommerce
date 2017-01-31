using System;

namespace OfficialCommunity.ECommerce.Services
{
    public interface IService
    {
        string Name { get;  }
        Guid Key { get; }

        string Icon { get;  }
        string Banner { get; }
    }

    [Serializable]
    public abstract class Service : IService
    {
        protected Service(string name, Guid key, string icon = null, string banner = null)
        {
            Name = name;
            Key = key;
            Icon = icon;
            Banner = banner;
        }

        public string Name { get; private set; }
        public Guid Key { get; private set; }
        public string Icon { get; private set; }
        public string Banner { get; private set; }
    }
}
