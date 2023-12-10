using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class Table
    {
        public static void Generate(string[] moves)
        {
            Console.WriteLine("Help table:");
            var headerRow = new string[moves.Length + 1];
            headerRow[0] = "v PC\\User >";
            Array.Copy(moves, 0, headerRow, 1, moves.Length);
            var table = new ConsoleTable(headerRow);
            for (int i = 0; i < moves.Length; i++)
            {
                var rowValues = new string[moves.Length + 1];
                rowValues[0] = moves[i];

                for (int j = 0; j < moves.Length; j++)
                {
                    rowValues[j + 1] = GameRules.GetGameResultState(j, i, moves);
                }

                table.AddRow(rowValues);
            }
            table.Configure(o => o.EnableCount = false);
            table.Write(Format.MarkDown);
        }
    }
}
