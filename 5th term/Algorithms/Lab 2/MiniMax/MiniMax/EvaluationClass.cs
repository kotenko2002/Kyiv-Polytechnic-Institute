using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMax
{
    public static class EvaluationClass
    {
        public static string EvaluationCriteria(char symbol)
            => $"{symbol}{symbol}{symbol}";
        
        public static int F(char[,] board)
        {
            int playerPoints = 0, computerPoints = 0;
            string strArray = Additional.ConvertArrayToStringSequence(board);

            if(strArray.Contains(EvaluationCriteria('X')))
                playerPoints += 10;
            if (strArray.Contains(EvaluationCriteria('O')))
                computerPoints += 5;

            return computerPoints - playerPoints;
        }
    }
}
