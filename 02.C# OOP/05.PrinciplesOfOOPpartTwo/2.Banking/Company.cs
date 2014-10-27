using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public class Company : Custumer
    {
        public Company(string name, string id)
        {
            if (name != null && name.Length >= 2)
            {
                this.Name = name;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The name must be at least 3 symbols");
            }

            if (id != null && id.Length == 8 )
            {
                this.Id = id;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The number ID must be exactly 8 digits!");
            }
        }
    }
}
