using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinimizeCostsOfACableCompany
{
    public class HouseNode : IComparable
    {
        public int MinCableLenth { get; set; }

        public int HouseID { get; set; }

        public HouseNode(int houseID)
        {
            this.HouseID = houseID;
        }

        public int CompareTo(object obj)
        {
            return this.MinCableLenth.CompareTo((obj as HouseNode).MinCableLenth);
        }
    }
}
