using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicRiftCore
{
    public abstract class GameController(GameData gameData)
    {
        public GameData GameData { get; } = gameData;

        public event Action<string> OnCorrectChoice;
        public event Action<string> OnWrongChoice;
        public event Action<Molecule> OnMoleculeDisplay;

        protected void OnCorrectChoiceEvent(string choice)
        {
            OnCorrectChoice?.Invoke(choice);
        }

        protected void OnWrongChoiceEvent(string choice)
        {
            OnWrongChoice?.Invoke(choice);
        }

        protected void OnMoleculeDisplayEvent(Molecule molecule)
        {
            OnMoleculeDisplay?.Invoke(molecule);
        }

        /// <summary>
        /// Start the game by selecting the first molecule on display
        /// </summary>
        public void Start()
        {
            if (GameData.Database.Molecules.Count == 0)
            {
                throw new InvalidOperationException("No molecules available to start the game.");
            }
            GenerateNewMoleculeOnDisplay();

        }

        protected void NextMoleculeOnDisplay()
        {
            if (GameData.MoleculeOnDisplay.Count == 0)
            {
                throw new InvalidOperationException("Not molecule anymore avalaible on display");
            }
            else
            {
                GameData.MoleculeOnDisplay.RemoveAt(0);
                GenerateNewMoleculeOnDisplay();
            }
        }

        protected void GenerateNewMoleculeOnDisplay(int position = -1)
        {
            if (position < -1 || position > GameData.MoleculeOnDisplay.Count)
            {
                throw new InvalidOperationException("Index can't be negative or bigger than the size of the list");
            }
            Random random = new Random();
            int randomNumber = random.Next(GameData.Database.Molecules.Count);
            Molecule newMolecule = GameData.Database.Molecules[randomNumber];
            if (position == -1)
            {
                GameData.MoleculeOnDisplay.Add(newMolecule);
            }
            else
            {
                gameData.MoleculeOnDisplay.Insert(position, newMolecule);
            }
            OnMoleculeDisplay?.Invoke(newMolecule);
        }
        /// <summary>
        /// Generate a set of possible choices, one of the element of the set has to be the correct answer
        /// </summary>
        /// <param name="choicesNumber">The number of desired choices</param>
        /// <returns>an hashset containing the choices</returns>
        public HashSet<string> GenerateAnswers(int choicesNumber)
        {
            if (GameData.Database.Molecules.Count == 0)
            {
                throw new InvalidOperationException("No molecules available to start the game.");
            }
            else if (choicesNumber <= 0) 
            {
                throw new InvalidOperationException("Number of choices has to be atleast 1.");
            }
            Random random = new Random();
            HashSet<string> moleculeNames = new HashSet<string>();
            moleculeNames.Add(GameData.MoleculeOnDisplay[0].Name);

            while (moleculeNames.Count < choicesNumber)
            {
                int number = random.Next(GameData.Database.Molecules.Count);
                string moleculeName = GameData.Database.Molecules[number].Name;
                if (!moleculeNames.Contains(moleculeName))
                {
                    moleculeNames.Add(moleculeName);
                }
            }
            return moleculeNames;
        }

        public abstract bool ProcessUserInput(string input);
    }
}
