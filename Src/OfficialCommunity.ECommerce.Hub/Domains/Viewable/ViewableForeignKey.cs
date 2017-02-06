using System.Diagnostics;

namespace OfficialCommunity.ECommerce.Hub.Domains.Viewable
{
    [DebuggerDisplay("{Key}:{Name}")]
    public class ViewableForeignKey<T>
    {
        public ViewableForeignKey()
        {
        }

        public ViewableForeignKey(T key)
        {
            Key = key;
            Name = key.ToString();
        }

        public ViewableForeignKey(T key, string name)
        {
            Key = key;
            Name = name;
        }

        public T Key { get; set; }

        public string Name { get; set; }
    }
}
