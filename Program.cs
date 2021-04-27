using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Assing3
{
    public enum CellLocation{
        NW,
        NC ,
        NE ,
        CW ,
        CC ,
        CE ,
        SW ,
        SC ,
        SE 
    }
    class Program
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

        
        static void Main(string[] args)
        {
            int depth = 0 ;
    
            // Read argument 1
            String arg1 = Console.ReadLine();

            // Argument 2 processing, Split by ;
            String[] strlist2 = arg1.Split(",", StringSplitOptions.RemoveEmptyEntries); 

            List<ItemParam> data = new List<ItemParam>();
            foreach (var line in strlist2)
            {
                // Split 2nd argument elemet data by ,
                String[] lineData = line.Split(".", StringSplitOptions.RemoveEmptyEntries); 
                depth = lineData.Length ;
                // Assume always 1 st data line is column headers and all names are uppercase
            
                    // Validator validateHandler = new Validator();
                    // ValidError error = validateHandler.ValidateUserParams(lineData[indexShape].Trim(),
                    //                                   lineData[indexLength].Trim(),
                    //                                   lineData[indexX].Trim(),
                    //                                   lineData[indexY].Trim(),
                    //                                   lineData[indexPoints].Trim() );
                    // if(!error.IsValid()){
                    //     Console.WriteLine("Validation failed : Parameter set "+lineNo+" : " + error.GetReason());
                    //     return;
                    // }

                    // Create ItemParam objects to store parameters
                    var itemParameter = new ItemParam(depth );
                    foreach (var codi in lineData)
                    {
                        itemParameter.AddCoordinates(GetCellNo(codi));

                    }
                    data.Add(itemParameter);
                
                
            }
            Console.WriteLine( data.Count);



            // Setup boards
            IBoard board = new Board();
            if(depth ==1){
                board = new Board()  ;
            }else if (depth > 1){
                VirtualBoard vBoard = new VirtualBoard();
                board = new Board();
                board = GetColned (vBoard, board);

                for (int i = 1; i < depth-1 ; i++) 
                {
                   VirtualBoard vBoard1 = new VirtualBoard();
                   board = GetColned (vBoard1, board);
                }
            }
            

            // VirtualBoard vBoard = new VirtualBoard();
            var dictionary = new Dictionary<int, List<int>>();
            dictionary.Add(1,new List<int>());
            dictionary.Add(2,new List<int>());

            var moves = new Dictionary<int, List<String>>();
            moves.Add(1,new List<String>());
            moves.Add(2,new List<String>());


            int player = 1;
            int count = 1 ;
            foreach (var parm in data)
            {
                // Board b = board.GetSelectedBoard(parm.GetX());
                var param = parm.GetCodes();
                bool m = board.MarkCell(player, parm.GetCodes());
                board.ResolveBoard(param);
                if(board.IsDone()){
                      Console.WriteLine( "DONE "+(CellLocation)parm.GetX()+" PLAYER "+player +" COUNT "+count);
                      dictionary[player].Add(parm.GetX());

                }

                if(board.IsDone()){
                       Console.WriteLine( "V DONE");
                }
                if(m){   // if move success

                    // moves[player].Add(param);

                    if(player ==1){
                       player =2; 
                    }else{
                        player = 1;
                    }

                }
                count = count+1;

            }
            
            // Console.WriteLine(moves[vBoard.GetWon()].Values.ToList() );
            // Console.WriteLine(dictionary[1].Values.ToList());
             Console.WriteLine("-----");

             Console.WriteLine("Key = {0}, Value = {1}", board.GetWon(),string.Join(",", board.GetWinings().ToArray())  );
            // Console.WriteLine("Key = {0}, Value = {1}", 1, string.Join(",", dictionary[1].ToArray()) );
            // Console.WriteLine("Key = {0}, Value = {1}", 2, string.Join(",", dictionary[2].ToArray()) );
             Console.WriteLine("-----");





        }

        static IBoard GetColned(VirtualBoard vBoard,IBoard board){

        
            vBoard.AddBoard(0,0,board.Clone());
            vBoard.AddBoard(0,1,board.Clone());
            vBoard.AddBoard(0,2,board.Clone());
            vBoard.AddBoard(1,0,board.Clone());
            vBoard.AddBoard(1,1,board.Clone());
            vBoard.AddBoard(1,2,board.Clone());
            vBoard.AddBoard(2,0,board.Clone());
            vBoard.AddBoard(2,1,board.Clone());
            vBoard.AddBoard(2,2,board.Clone());

            return vBoard;
        }

        static int GetCellNo  (string s )
        {
            switch (s) {
              
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
