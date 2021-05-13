using System;

namespace Assing3
{

    // This objeect use to store primary cell data
    public class Cell
    {
        private int value;


        public Cell(int x0)
        {
            value = x0;
        }


        public void SetValue(int y0)
        {
            value = y0;
        }
        public int GetValue()
        {
            return value;
        }

        public bool IsMarked()
        {
            return value != 0;
        }

        public bool Mark(int x)
        {
            SetValue(x);
            return true;
        }

        public Cell Clone()
        {
            Cell clone = (Cell)this.MemberwiseClone();
            return clone;
        }


    }

}