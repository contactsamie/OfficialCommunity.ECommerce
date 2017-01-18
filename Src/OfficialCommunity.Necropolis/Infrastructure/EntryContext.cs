using System.Collections.Generic;

namespace OfficialCommunity.Necropolis.Infrastructure
{
    public class EntryContext : Context
    {
        public class Builder
        {
            private string _name;

            public Builder Passport(string passport)
            {
                EntryContext.Add(new KeyValuePair<string, object>("Passport", passport));
                return this;
            }

            public Builder Name(string name)
            {
                _name = name;
                return this;
            }

            public Builder Identity(string key, object value)
            {
                var root = $"Scope-{_name}-{IdentityName}-";
                EntryContext.Add(new KeyValuePair<string, object>($"{root}-{key}-", value));
                return this;
            }

            public Builder Data(string key, object value)
            {
                var root = $"Scope-{_name}-{DataName}-";
                EntryContext.Add(new KeyValuePair<string, object>($"{root}-{key}-", value));
                return this;
            }

            public Builder Data(string key, IEnumerable<object> values)
            {
                var root = $"Scope-{_name}-{DataName}-";

                var i = 0;
                foreach (var o in values)
                {

                    EntryContext.Add(new KeyValuePair<string, object>($"{root}-{key}-{i++}", o));
                }
                return this;
            }

            public EntryContext EntryContext { get; } = new EntryContext();
        }

        public static Builder Capture => new Builder();

        public EntryContext()
        {
        }

        public EntryContext(
            string passport
            , string name
            , IEnumerable<KeyValuePair<string, object>> identity = null
            , IEnumerable<KeyValuePair<string, object>> data = null
        )
            : base(passport, name, identity, data)
        {
        }
    }
}