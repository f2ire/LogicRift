using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicRiftCore
{
    public enum GameMode
    {
        Practice = 0,
        Challenge = 1,
    }
    public class GameController(GameData gameData)
    {
        public GameData GameData { get; set; } = gameData;
        public GameMode GameMode { get; set; }

        public bool IsCorrect(string input)
        {
            return true;
        }

        public void UpdateGameData()
        {

        }


        public bool isLose()
        {
            return false; 
        }
    }


}
