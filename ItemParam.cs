using System;
using System.Collections.Generic;

namespace Assing3
{

    // This objeect use to store user paremeters of moves
    public class ItemParam
    {
        public const string NW = "NW";
        public const string NC = "NC";
        public const string NE = "NE";
        public const string CW = "CW";
        public const string CC = "CC";
        public const string CE = "CE";
        public const string SW = "SW";
        public const string SC = "SC";
        public const string SE = "SE";

        private int depth;
        private List<int> codes = new List<int>();

        public ItemParam(int x0, List<int> code)
        {
            depth = x0;
            codes = code;
        }

        public ItemParam(int x0)
        {
            depth = x0;

        }

        public void SetCodes(List<int> code)
        {
            codes = code;
        }

        public List<int> GetCodes()
        {
            return codes;
        }

        public int GetDepth()
        {
            return depth;
        }

        public void SetDepth(int dep)
        {
            depth = dep;
        }

        public void AddCoordinates(String cod)
        {
            codes.Add(GetCellNo(cod));
        }

        public void AddCoordinates(int cod)
        {
            codes.Add(cod);
        }

        public String GetAsCodinates(String separator)
        {
            List<String> ss = new List<string>();
            foreach (var c in codes)
            {
                var a = (CellLocation)c;
                ss.Add(a.ToString());

            }
            return string.Join(separator, ss.ToArray());
        }

        private int GetCellNo(string s)
        {
            switch (s)
            {

                case NW:
                    return (int)CellLocation.NW;
                case NC:
                    return (int)CellLocation.NC;
                case NE:
                    return (int)CellLocation.NE;
                case CW:
                    return (int)CellLocation.CW;
                case CC:
                    return (int)CellLocation.CC;
                case CE:
                    return (int)CellLocation.CE;
                case SW:
                    return (int)CellLocation.SW;
                case SC:
                    return (int)CellLocation.SC;
                case SE:
                    return (int)CellLocation.SE;
                default:
                    return 0;

            }
        }

    }

}