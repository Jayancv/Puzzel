using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Assing3
{
    public enum CellLocation
    {
        NW,
        NC,
        NE,
        CW,
        CC,
        CE,
        SW,
        SC,
        SE
    }
    class Program
    {

        static void Main(string[] args)
        {
            int depth = 0;

            // Read argument 1
            //String arg1 = Console.ReadLine();
            String arg1 = "NW.NW.NW,NC.NW.NW,NC.NW.NW,NW.NW.CC,NW.SW.SW,NW.NW.SE,CW.SW.SW,NW.CC.NW,SW.SW.SW,NW.CC.CC,NC.SW.SW,NW.CC.SE,CC.SW.SW,NW.SE.NW,SC.SW.SW,NW.SE.CC,NE.SW.SW,NW.SE.SE,CE.SW.SW,CW.NW.NW,SE.SW.SW,CW.NW.CC,NW.SW.CC,CW.NW.SE,CW.SW.CC,CW.CC.NW,SW.SW.CC,CW.CC.CC,NC.SW.CC,CW.CC.SE,CC.SW.CC,CW.SE.NW,SC.SW.CC,CW.SE.CC,NE.SW.CC,CW.SE.SE,CE.SW.CC,SW.NW.NW,SE.SW.CC,SW.NW.CC,NW.SW.SE,SW.NW.SE,CW.SW.SE,SW.CC.NW,SW.SW.SE,SW.CC.CC,NC.SW.SE,SW.CC.SE,CC.SW.SE,SW.SE.NW,SC.SW.SE,SW.SE.CC,NE.SW.SE,SW.SE.SE";
            arg1 = "NW.NW.CC,NW.NC.CC,NW.NW.NW,NW.NE.CC,NW.NW.SE,NW.CE.CC,NW.CW.CC,NW.SE.CC,NW.CW.NW,NW.CC.CC,NW.CW.SE,NW.CC.NW,NW.CC.SE,NW.CE.NW,NW.SW.CC,NW.CE.SE,NW.SW.NW,NW.SE.SE,NW.SW.SE,CW.NC.CC,SW.SW.SE,CW.NE.CC,CW.NW.NW,CW.CC.NW,CW.NW.SE,CW.CC.CC,CW.SW.CC,CW.CE.NW,CW.SW.NW,CW.CE.SE,CW.SW.SE,CW.CE.CC,CW.CW.SE,CW.SE.CC,CW.CW.CC,CW.SW.NE,CW.CW.NW,CW.NE.SE,SW.NW.CC,SW.NC.CC,SW.NW.NW,SW.NE.CC,SW.NW.SE,SW.CE.CC,SW.CW.CC,SW.SE.CC,SW.CW.NW,SW.CC.CC,SW.CW.SE,SW.CC.NW,SW.CC.SE,SW.CE.NW,SW.SW.CC,SW.CE.SE,SW.SW.NW,SW.SE.SE,CW.NW.CC";
            //arg1 = "SW.SE,NC.CC,NW.NW,NE.CC,NW.SE,CE.CC,CW.CC,SE.CC,CW.NW,CC.CC,CW.SE,CC.NW,CC.SE,CE.NW,SW.CC,CE.SE,CC.CC,SW.NW,SE.SE,NW.CC";
            // Argument 2 processing, Split by ;
            String[] strlist2 = arg1.Split(",", StringSplitOptions.RemoveEmptyEntries);

            List<ItemParam> data = new List<ItemParam>();
            foreach (var line in strlist2)
            {
                // Split 2nd argument elemet data by ,
                String[] lineData = line.Split(".", StringSplitOptions.RemoveEmptyEntries);
                depth = lineData.Length;
                // Assume always 1 st data line is column headers and all names are uppercase

                //TODO Add validations

                // Create ItemParam objects to store parameters
                var itemParameter = new ItemParam(depth);
                foreach (var codi in lineData)
                {
                    itemParameter.AddCoordinates(codi);

                }
                data.Add(itemParameter);

            }
            Console.WriteLine("Input count : " + data.Count);


            // Dashboard of winners
            Dashboard dashB = new Dashboard(depth);

            // Setup boards
            IBoard board = new Board(dashB);
            if (depth > 1)
            {
                VirtualBoard vBoard = new VirtualBoard(dashB);
                vBoard.SetLevel(1);
                board = new Board(dashB);
                board = vBoard.GetColned(vBoard, board);

                for (int i = 1; i < depth - 1; i++)
                {
                    VirtualBoard vBoard1 = new VirtualBoard(dashB);
                    vBoard1.SetLevel(i + 1);
                    board = vBoard1.GetColned(vBoard1, board);
                }
            }


            // Valid moves 
            var moves = new Dictionary<int, List<ItemParam>>();
            moves.Add(1, new List<ItemParam>());
            moves.Add(2, new List<ItemParam>());


            int player = 1;
            int count = 1;
            foreach (var parm in data)
            {
                // Board b = board.GetSelectedBoard(parm.GetX());
                var param = parm.GetCodes();
                bool success = board.MarkCell(player, parm.GetCodes());
                board.ResolveBoard(param);

                if (success)
                {   // if move success

                    moves[player].Add(parm);  // Ass to sucess move

                    // change players
                    if (player == 1)
                    {
                        player = 2;
                    }
                    else
                    {
                        player = 1;
                    }

                }
                else
                {
                    Console.WriteLine("--False move--" + count);
                }
                count = count + 1;

            }


            Console.WriteLine("-----");

            Console.WriteLine("Winner (Larger Boards) = {0}, Value = {1}", board.GetWon()==0 ? "No winner":board.GetWon(), string.Join(",", dashB.GetLargeWinings(board.GetWon())));
            Console.WriteLine("Player = {0}, Value = {1}", 1, string.Join(",", dashB.GetX().ToArray().Reverse()));
            Console.WriteLine("Player = {0}, Moves = {1}", 0, string.Join(",", dashB.GetY().ToArray().Reverse()));

            List<String> winingMoves = new List<string>();
            if (board.GetWon() != 0)
            {
                foreach (var parm in moves[board.GetWon()])
                {
                    var param = parm.GetCodes();
                    bool rr = board.IsWiningMove(board.GetWon(), parm.GetCodes());
                    if (rr)
                    {
                        winingMoves.Add(parm.GetAsCodinates("."));
                        // Console.WriteLine("Key = {0}", parm.GetAsCodinates());
                    }
                }
                Console.WriteLine("Winner = {0}, Value = {1}", board.GetWon(), string.Join(",", winingMoves.ToArray()));

            }
            Console.WriteLine("-----");

        }
   
    }
}
