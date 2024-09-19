using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicRiftCore
{
    public class Database
    {
        public List<Molecule> Molecules { get; set; } = new();
        public static Database Load(string path)
        {
            return null;
        }

        public void Filter(params string[] categories)
        {
           
        }
    }
}
