using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assing3
{
    class Dashboard : Mediator
    {
        int[] x;
        int[] y;
        int depth;

        List<int> xLarageBoards = new List<int>();
        List<int> yLarageBoards = new List<int>();

        public Dashboard(int s)
        {
            depth = s;
            x = new int[s];
            y = new int[s];
        }

        public void Update(int level, int player)
        {
            if (player == 1)
            {

                x[level] = x[level] + 1;
            }
            else
            {
                y[level] = y[level] + 1;
            }
        }

        public void AddWiningBoards(int level, int player, int board)
        {
            if (depth - 1 == level)
            {
                if (player == 1)
                {

                    xLarageBoards.Add(board);
                }
                else
                {
                    yLarageBoards.Add(board);
                }
            }
        }

        public int[] GetX()
        {
            return x;
        }
        public int[] GetY()
        {
            return y;
        }

        public String GetLargeWinings(int player)
        {
            if (player == 1)
            {
                ItemParam param = new ItemParam(3);
                foreach (var p in xLarageBoards)
                {
                    param.AddCoordinates(p);
                }
                return param.GetAsCodinates(",");
            }
            else if (player == 2)
            {
                ItemParam param = new ItemParam(3);
                foreach (var p in yLarageBoards)
                {
                    param.AddCoordinates(p);
                }
                return param.GetAsCodinates(",");
            }
            return "";
        }
    }

}