using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using LogicRiftCore;

namespace LogicRiftTests
{
    public class DataBaseTests
    {
        string resourcesPath;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var testsDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            resourcesPath = Path.Combine(testsDirectory, "Resources");
        }

        [Test]
        public void LoadEmptyDatabase()
        {
            var emptyDb = Database.Load(Path.Combine(resourcesPath, "emptyDatabase.json"));

            Assert.That(emptyDb, Is.Not.Null);
            Assert.That(emptyDb.Molecules.Count, Is.EqualTo(0));
        }

        [Test]
        public void LoadSingleMolecule()
        {
            var singleDb = Database.Load(Path.Combine(resourcesPath, "singleMolecule.json"));

            Assert.That(singleDb, Is.Not.Null);
            Assert.That(singleDb.Molecules.Count, Is.EqualTo(1));
            Assert.That(singleDb.Molecules[0].ID, Is.EqualTo(1));
            Assert.That(singleDb.Molecules[0].Name, Is.EqualTo("Glucose"));
            Assert.That(singleDb.Molecules[0].Brut, Is.EqualTo("C6H12O6"));
            Assert.That(singleDb.Molecules[0].Category, Is.EqualTo("Ose"));
        }

        [Test]
        public void LoadMultipleMolecule()
        {
            var multipleDb = Database.Load(Path.Combine(resourcesPath, "multipleMolecule.json"));

            Assert.That(multipleDb, Is.Not.Null);
            Assert.That(multipleDb.Molecules.Count, Is.EqualTo(18));
            Assert.Multiple(() =>
            {
                for (int i = 0; i < multipleDb.Molecules.Count; i++)
                {
                    Assert.That(multipleDb.Molecules[i].ID, Is.EqualTo(i + 1));
                }
            });
        }

        [Test]
        public void SingleFilter()
        {
            var db1 = Database.Load(Path.Combine(resourcesPath, "multipleMolecule.json"));
            var db2 = Database.Load(Path.Combine(resourcesPath, "multipleMolecule.json"));
            var db3 = Database.Load(Path.Combine(resourcesPath, "multipleMolecule.json"));
            var db4 = Database.Load(Path.Combine(resourcesPath, "multipleMolecule.json"));
            db1.Filter("Ose");
            db2.Filter("Acide aminé");
            db3.Filter("Nucléotide");
            db4.Filter("Lipide");

            Assert.That(db1.Molecules.Count, Is.EqualTo(5));
            Assert.That(db2.Molecules.Count, Is.EqualTo(5));
            Assert.That(db3.Molecules.Count, Is.EqualTo(4));
            Assert.That(db4.Molecules.Count, Is.EqualTo(4));
        }

        [Test]
        public void MultipleFilter()
        {
            var db1 = Database.Load(Path.Combine(resourcesPath, "multipleMolecule.json"));
            var db2 = Database.Load(Path.Combine(resourcesPath, "multipleMolecule.json"));
            var db3 = Database.Load(Path.Combine(resourcesPath, "multipleMolecule.json"));
            db1.Filter("Ose", "Acide aminé");
            db2.Filter("Nucléotide", "Lipide");
            db3.Filter("Ose", "Lipide");

            Assert.That(db1.Molecules.Count, Is.EqualTo(10));
            Assert.That(db2.Molecules.Count, Is.EqualTo(8));
            Assert.That(db3.Molecules.Count, Is.EqualTo(9));
        }

        [Test]
        public void WrongFilter()
        {
            var db = Database.Load(Path.Combine(resourcesPath, "multipleMolecule.json"));
            db.Filter("George");

            Assert.That(db.Molecules.Count, Is.EqualTo(0));
        }
    }
}