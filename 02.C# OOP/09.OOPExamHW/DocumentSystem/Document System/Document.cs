using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystems
{

    public abstract class Document : IDocument
    {
        public string Name
        {
            get
            {
                return (this.GetProperty("Name") as string);
            }
            set
            {
                this.LoadProperty("Name", value.ToString());
            }
        }

        public string Content
        {
            get
            {
                return (this.GetProperty("Content").ToString());
            }
            set
            {
                this.LoadProperty("Content", value.ToString());
            }
        }


        protected readonly Dictionary<string, object> properties = new Dictionary<string, object>();

        public void LoadProperty(string key, string value)
        {
            string loweredkey = key.ToLower();
            if (this.properties.ContainsKey(loweredkey))
            {
                this.properties[loweredkey] = value;
            }
            else
            {
                this.properties.Add(loweredkey, value);
            }
        }

        public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output = this.properties.ToList();
            output = output.OrderBy(x => x.Key).ToList();
        }

        protected object GetProperty(string key)
        {
            string loweredkey = key.ToLower();
            if (this.properties.ContainsKey(loweredkey))
            {
                return this.properties[loweredkey];
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append('[');

            var list = this.properties.ToList();

            list = list.OrderBy(x => x.Key).ToList();

            foreach (var prop in list)
            {
                if (prop.Value != null)
                {
                    sb.AppendFormat("{0}={1};", prop.Key.ToLower(), prop.Value);
                }
            }

            string result = sb.ToString().Trim(';') + "]";

            return result;
        }
    }
}
