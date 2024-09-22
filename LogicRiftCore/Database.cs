using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace LogicRiftCore
{
    public class Database
    {
        public List<Molecule> Molecules { get; set; } = new();
        public static Database Load(string path)
        {
            Database database = new Database();

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"File {path} doesn't exist.");
            }

            string jsonContent = File.ReadAllText(path);
            try
            {
                database.Molecules = JsonConvert.DeserializeObject<List<Molecule>>(jsonContent);
                return database;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Filter(params string[] categories)
        {
            Molecules.RemoveAll(molecule => !categories.Contains(molecule.Category));
        }
    }
}
