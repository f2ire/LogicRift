using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicRiftCore
{
    public class Molecule(int ID, string Caterogie)
    {
        public int ID { get; private set; } = ID;
        public float Lifetime { get; private set; } = 100; // Lifetime of the molecule. If 0, time to guess is over. Start at 100.
        public string Caterogie { get; private set; } = Caterogie;
        public Dictionary<string, string> Reprensation { get; private set; } = [];



        // METHODS

        public void SetImage(string representation, string imagePath)
        {

        }
    }
}
