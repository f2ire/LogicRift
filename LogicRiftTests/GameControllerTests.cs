using LogicRiftCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicRiftTests
{
    public class GameControllerTests
    {
        PracticeGameController practiceController;
        ChallengeGameController challengeController;
        int onCorrectChoiceEventCount;
        int onWrongChoiceEventCount;
        int onMoleculeDisplayEventCount;

        [SetUp]
        public void Setup()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var testsDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var resourcesPath = Path.Combine(testsDirectory, "Resources");
            var db = Database.Load(Path.Combine(resourcesPath, "multipleMolecule.json"));
            var gameData = new GameData(db);
            challengeController = new ChallengeGameController(gameData, 1);
            practiceController = new PracticeGameController(gameData);
            onCorrectChoiceEventCount = 0;
            onWrongChoiceEventCount = 0;
            onMoleculeDisplayEventCount = 0;
            challengeController.OnCorrectChoice += (s) => { onCorrectChoiceEventCount++; };
            challengeController.OnWrongChoice += (s) => { onWrongChoiceEventCount++; };
            challengeController.OnMoleculeDisplay += (m) => { onMoleculeDisplayEventCount++; };
            practiceController.OnCorrectChoice += (s) => { onCorrectChoiceEventCount++; };
            practiceController.OnWrongChoice += (s) => { onWrongChoiceEventCount++; };
            practiceController.OnMoleculeDisplay += (m) => { onMoleculeDisplayEventCount++; };
        }

        private void AssertEventCount(int correctChoices, int wrongChoices, int moleculesDisplay)
        {
            Assert.Multiple(() =>
            {
                Assert.That(correctChoices == onCorrectChoiceEventCount);
                Assert.That(wrongChoices == onWrongChoiceEventCount);
                Assert.That(moleculesDisplay == onMoleculeDisplayEventCount);
            });
        }

        [Test]
        public void GameStart()
        {
            Molecule molecule = null;
            practiceController.OnMoleculeDisplay += (m) => { molecule = m; };
            practiceController.Start();
            AssertEventCount(0, 0, 1);
            Assert.That(molecule, Is.Not.Null);
            Assert.That(practiceController.GameData.MoleculeOnDisplay.Count, Is.EqualTo(1));
            Assert.That(practiceController.GameData.MoleculeOnDisplay[0], Is.EqualTo(molecule));
            Assert.That(practiceController.GameData.Database.Molecules.Contains(molecule), Is.True);
        }

        [Test]
        public void GenerateSingleChoice()
        {
            Molecule molecule = null;
            practiceController.OnMoleculeDisplay += (m) => { molecule = m; };
            practiceController.Start();
            var choices = practiceController.GenerateAnswers(1);
            Assert.That(choices.Count, Is.EqualTo(1));
            Assert.That(choices.First(), Is.EqualTo(molecule.Name));
        }

        [Test, Repeat(100)]
        public void GenerateMultipleChoices()
        {
            Molecule molecule = null;
            practiceController.OnMoleculeDisplay += (m) => { molecule = m; };
            practiceController.Start();
            var choices = practiceController.GenerateAnswers(3);
            Assert.That(choices.Count, Is.EqualTo(3));
            Assert.That(choices.Contains(molecule.Name));
        }

        [Test]
        public void PracticeGameProcessCorrectInput()
        {
            Molecule molecule = null;
            practiceController.OnMoleculeDisplay += (m) => { molecule = m; };
            practiceController.Start();
            Assert.That(practiceController.ProcessUserInput(molecule.Name), Is.True);
            AssertEventCount(1, 0, 2);
            Assert.That(practiceController.GameData.MoleculeOnDisplay.Count, Is.EqualTo(1));
            Assert.That(practiceController.GameData.Score, Is.EqualTo(1));
            Assert.That(practiceController.GameData.Database.Molecules.Contains(molecule), Is.True);
        }

        [Test]
        public void PracticeGameProcessWrongInput()
        {
            practiceController.Start();
            Assert.That(practiceController.ProcessUserInput("Wrong"), Is.False);
            AssertEventCount(0, 1, 1);
            Assert.That(practiceController.GameData.MoleculeOnDisplay.Count, Is.EqualTo(1));
        }

        [Test]
        public void ChallengeGameProcessCorrectInput()
        {
            Molecule molecule = null;
            challengeController.OnMoleculeDisplay += (m) => { molecule = m; };
            challengeController.Start();
            Assert.That(challengeController.ProcessUserInput(molecule.Name), Is.True);
            AssertEventCount(1, 0, 1);
            Assert.That(challengeController.GameData.MoleculeOnDisplay.Count, Is.EqualTo(0));
            Assert.That(challengeController.GameData.Score, Is.EqualTo(1));
        }

        [Test]
        public void ChallengeGameProcessWrongInput()
        {
            challengeController.Start();
            Assert.That(challengeController.ProcessUserInput("Wrong"), Is.False);
            AssertEventCount(0, 1, 1);
            Assert.That(challengeController.GameData.MoleculeOnDisplay.Count, Is.EqualTo(1));
        }

        [Test]
        public void ChallengeGameIsLost()
        {
            Molecule molecule = null;
            challengeController.OnMoleculeDisplay += (m) => { molecule = m; };
            challengeController.Start();
            Assert.That(challengeController.IsLost(), Is.False);
            molecule.Lifetime = -1;
            Assert.That(challengeController.IsLost(), Is.True);
        }

        [Test]
        public void SmallGameUpdate()
        {
            challengeController.Start();
            challengeController.UpdateGameData(0.08f);
            AssertEventCount(0, 0, 1);
            Assert.That(challengeController.GameData.MoleculeOnDisplay.First().Lifetime, Is.LessThan(100));
        }

        [Test]
        public void NewMoleculeOnDisplay()
        {
            challengeController.Start();
            AssertEventCount(0, 0, 1);
            challengeController.UpdateGameData(0.9f);
            AssertEventCount(0, 0, 1);
            challengeController.UpdateGameData(0.3f);
            AssertEventCount(0, 0, 2);
            challengeController.UpdateGameData(0.9f);
            AssertEventCount(0, 0, 3);
            Assert.That(challengeController.GameData.MoleculeOnDisplay.Count, Is.EqualTo(3));

            foreach (var molecule in challengeController.GameData.MoleculeOnDisplay)
            {
                Assert.That(challengeController.GameData.Database.Molecules.Contains(molecule), Is.True);
            }
        }
    }
}
