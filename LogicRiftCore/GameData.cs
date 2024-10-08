using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicRiftCore
{
    public class GameData(Database db)
    {
        public Database Database { get; set; } = db;
        public List<Molecule> MoleculeOnDisplay { get; set; } = new();
        public int Score { get; set; } = 0;
        public float Speed { get; set; } = 1;
    }
}
