using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinimizeCostsOfACableCompany
{
    public class CableConnection
    {
        public HouseNode House { get; set; }

        public int CableLenth { get; set; }

        public CableConnection(HouseNode house, int cableLenth)
        {
            this.House = house;
            this.CableLenth = cableLenth;
        }
    }
}
