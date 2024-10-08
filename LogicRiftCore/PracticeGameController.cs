using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicRiftCore
{
    public class PracticeGameController(GameData gameData) : GameController(gameData)
    {
        /// <summary>
        /// Check if the user input is the correct answer
        /// Invoke OnCorrectChoice or OnWrongChoice event according to the input
        /// Change the molecule on display if the choice is correct
        /// </summary>
        /// <param name="input">The user input</param>
        /// <returns>True if the input is correct</returns>
        public override bool ProcessUserInput(string input)
        {
            return false;
        }
    }
}
