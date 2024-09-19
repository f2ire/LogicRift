using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicRiftCore
{
    public class GameData
    {
        public Database Database { get; set; } = new();
        public List<Molecule> MoleculeOnDisplay { get; set; } = new();
        public List<string> Choices { get; set; } = new(); 
        public int Score { get; set; } = 0;
        public float Speed { get; set; } = 1;

    }
}
