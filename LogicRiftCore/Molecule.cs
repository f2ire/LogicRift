using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicRiftCore
{
    public class Molecule(int ID, string Name, string Brut, string Category)
    {
        public int ID { get; private set; } = ID;
        public string Name { get; private set; } = Name;
        public string Brut { get; private set; } = Brut;
        public string Category { get; private set; } = Category;
        public float Lifetime { get; set; } = 100; // Lifetime of the molecule. If 0, time to guess is over. Start at 100.
        public Dictionary<string, string> Reprensation { get; private set; } = [];



        // METHODS

        public void SetImage(string representation, string imagePath)
        {

        }
    }
}
