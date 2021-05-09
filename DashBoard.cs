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
        public Dashboard(int s)
        {
            x = new int[s];
            y = new int[s];
        }

        public void Update(int l, int p)
        {
            if (p == 1)
            {

                x[l] = x[l] + 1;
            }
            else
            {
                y[l] = y[l] + 1;
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
    }

}