using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicRiftCore
{
    public class ChallengeGameController(GameData gameData, float moleculeApparitionTime) : GameController(gameData)
    {
        public float MoleculeApparitionTime { get; } = moleculeApparitionTime; // Time between each molecule apparition in seconds

        /// <summary>
        /// Check if the user input is the correct answer
        /// Invoke OnCorrectChoice or OnWrongChoice event according to the input
        /// </summary>
        /// <param name="input">The user input</param>
        /// <returns>True if the input is correct</returns>
        public override bool ProcessUserInput(string input)
        {
            return false;
        }

        /// <summary>
        /// Check if one of the molecule on display have a lifetime less or equals than 0
        /// </summary>
        /// <returns>True if the game is lost</returns>
        public bool IsLost()
        {
            return false;
        }

        /// <summary>
        /// Move all molecules on display
        /// Add a new melocule on display every <see cref="MoleculeApparitionTime"/> seconds
        /// </summary>
        /// <param name="deltaTime">The time ellapsed between the last update, in seconds</param>
        public void UpdateGameData(float deltaTime)
        {

        }
    }
}
