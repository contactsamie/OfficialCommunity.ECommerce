using System.Collections.Generic;

namespace OfficialCommunity.Necropolis.Infrastructure
{
    public abstract class Context : List<KeyValuePair<string, object>>
    {
        public const string IdentityName = "Identity-";
        public const string DataName = "Data-";

        protected Context()
        {
        }

        protected Context(
            string passport
            , string name
            , IEnumerable<KeyValuePair<string, object>> identity = null
            , IEnumerable<KeyValuePair<string, object>> data = null
        )
        {
            if (!string.IsNullOrWhiteSpace(passport))
            {
                Add(new KeyValuePair<string, object>("Passport", passport));
            }

            if (identity != null)
            {
                var root = $"Scope-{name}-{IdentityName}-";
                foreach (var i in identity)
                {
                    Add(new KeyValuePair<string, object>($"{root}-{i.Key}-", i.Value));
                }
            }

            if (data != null)
            {
                var root = $"Scope-{name}-{DataName}-";
                foreach (var d in data)
                {
                    Add(new KeyValuePair<string, object>($"{root}-{d.Key}-", d.Value));
                }
            }
        }
        protected Context(string name
            , IEnumerable<KeyValuePair<string, object>> identity = null
            , IEnumerable<KeyValuePair<string, object>> data = null
        )
        {
            if (identity != null)
            {
                var root = $"Scope-{name}-{IdentityName}-";
                foreach (var i in identity)
                {
                    Add(new KeyValuePair<string, object>($"{root}-{i.Key}-", i.Value));
                }
            }

            if (data != null)
            {
                var root = $"Scope-{name}-{DataName}-";
                foreach (var d in data)
                {
                    Add(new KeyValuePair<string, object>($"{root}-{d.Key}-", d.Value));
                }
            }
        }
    }
}
