using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Start the game by selecting the first molecule on display
        /// </summary>
        public void Start()
        {

        }

        /// <summary>
        /// Generate a set of possible choices, one of the element of the set has to be the correct answer
        /// </summary>
        /// <param name="choicesNumber">The number of desired choices</param>
        /// <returns>an hashset containing the choices</returns>
        public HashSet<string> GenerateChoices(int choicesNumber)
        {
            return null;
        }

        public abstract bool ProcessUserInput(string input);
    }
}
