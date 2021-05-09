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
                board = GetColned(vBoard, board);

                for (int i = 1; i < depth - 1; i++)
                {
                    VirtualBoard vBoard1 = new VirtualBoard(dashB);
                    vBoard1.SetLevel(i + 1);
                    board = GetColned(vBoard1, board);
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

                if (board.IsDone())
                {
                    Console.WriteLine("DONE " + (CellLocation)parm.GetX() + " PLAYER " + player + " COUNT " + count);
                    Console.WriteLine("V DONE");
                }

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
                count = count + 1;

            }


            Console.WriteLine("-----");

            Console.WriteLine("Winner (Larger Boards) = {0}, Value = {1}", board.GetWon(), string.Join(",", board.GetWinings().ToArray()));
            Console.WriteLine("Player = {0}, Value = {1}", 1, string.Join(",", dashB.GetX().ToArray().Reverse()));
            Console.WriteLine("Player = {0}, Moves = {1}", 0, string.Join(",", dashB.GetY().ToArray().Reverse()));

            List<String> winingMoves = new List<string>();
            foreach (var parm in moves[board.GetWon()])
            {
                var param = parm.GetCodes();
                bool rr = board.IsWiningMove(board.GetWon(), parm.GetCodes());
                if (rr)
                {
                    winingMoves.Add(parm.GetAsCodinates());
                    // Console.WriteLine("Key = {0}", parm.GetAsCodinates());
                }
            }
            Console.WriteLine("Winner = {0}, Value = {1}", board.GetWon(), string.Join(",", winingMoves.ToArray()));


            Console.WriteLine("-----");


        }

        static IBoard GetColned(VirtualBoard vBoard, IBoard board)
        {


            vBoard.AddBoard(0, 0, board.Clone());
            vBoard.AddBoard(0, 1, board.Clone());
            vBoard.AddBoard(0, 2, board.Clone());
            vBoard.AddBoard(1, 0, board.Clone());
            vBoard.AddBoard(1, 1, board.Clone());
            vBoard.AddBoard(1, 2, board.Clone());
            vBoard.AddBoard(2, 0, board.Clone());
            vBoard.AddBoard(2, 1, board.Clone());
            vBoard.AddBoard(2, 2, board.Clone());

            return vBoard;
        }



    }
}
