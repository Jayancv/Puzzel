using System.Collections.Generic;
using System;

namespace Assing3{

    // This objeect use to store user paremeters to create shapes
    public class Board : IBoard
    {
        private bool done;
        private int won;
        List<int> wings = new List<int>();

        private Cell[,] cells = new Cell[3,3] ;
        private int y ;
        private int x ;


        public Board( )
        {
              cells[0,0] = new Cell(0);
              cells[0,1] = new Cell(0);
              cells[0,2] = new Cell(0);
              cells[1,0] = new Cell(0);
              cells[1,1] = new Cell(0);
              cells[1,2] = new Cell(0);
              cells[2,0] = new Cell(0);
              cells[2,1] = new Cell(0);
              cells[2,2] = new Cell(0);               
        }

        public IBoard Clone()
        {
            Board clone = new Board();
            // clone.cells = (Cell[,]) this.cells.Clone();
            return clone;
        }

        public void SetX(int x0)
        {
            x = x0;
        }
        public int GetX(){
            return x;
        }

        public void SetY(int y0)
        {
            y = y0;
        }
        public int GetY(){
            return y;
        }

        public void SetWon(int y0)
        {
            done = true;
            won = y0;
        }
        public int GetWon(){
            
            return won;
        }

        public bool IsDone(){
            return done;
        }

        public List<int> GetWinings(){
            return wings;
        }

        public bool IsVaildMove( int num){
            return !GetSelectedCell( num ).IsMarked();
        }

        public int ResolveBoard( List<int> cellNum ){

            if(IsDone()){
                return GetWon();
            }
            if( cells[0,0].GetValue()!= 0 && cells[0,0].GetValue()== cells[0,1].GetValue() && cells [0,0].GetValue() == cells[0,2].GetValue()){
                SetWon(cells[0,0].GetValue());
                return GetWon();
            }else if(cells[1,0].GetValue()!= 0 && cells[1,0].GetValue()== cells[1,1].GetValue() && cells [1,0].GetValue() == cells[1,2].GetValue()){
                SetWon(cells[1,0].GetValue());
                return GetWon();
            }else if(cells[2,0].GetValue()!= 0 && cells[2,0].GetValue()== cells[2,1].GetValue() && cells [2,0].GetValue() == cells[2,2].GetValue()){
                SetWon(cells[2,0].GetValue());
                return GetWon();
            }else if(cells[0,0].GetValue()!= 0 && cells[0,0].GetValue()== cells[1,0].GetValue() && cells [0,0].GetValue() == cells[2,0].GetValue()){
                SetWon(cells[0,0].GetValue());
                return GetWon();
            }else if(cells[0,1].GetValue()!= 0 && cells[0,1].GetValue()== cells[1,1].GetValue() && cells [0,1].GetValue() == cells[2,1].GetValue()){
                SetWon(cells[0,1].GetValue());
                return GetWon();
            }else if(cells[0,2].GetValue()!= 0 && cells[0,2].GetValue()== cells[1,2].GetValue() && cells [0,2].GetValue() == cells[2,2].GetValue()){
                SetWon(cells[0,2].GetValue());
                return GetWon();
            }else if(cells[0,0].GetValue()!= 0 && cells[0,0].GetValue()== cells[1,1].GetValue() && cells [0,0].GetValue() == cells[2,2].GetValue()){
                SetWon(cells[0,0].GetValue());
                return GetWon();
            }else if(cells[0,2].GetValue()!= 0 && cells[0,2].GetValue()== cells[1,1].GetValue() && cells [0,2].GetValue() == cells[2,0].GetValue()){
                SetWon(cells[0,2].GetValue());
                return GetWon();
            }


            return 0;
        }

        public bool MarkCell(int player, List<int> cellNum){
            int f =cellNum[0];
            if(IsVaildMove(f)){
               return GetSelectedCell(f).Mark(player);
            }
            return false;
        }

        

        private Cell GetSelectedCell(int num) {

            switch (num) {
              
                case 0:
                    return cells[0,0];
                case 1:
                    return cells[0,1];
                case 2:
                    return cells[0,2];
                case 3:
                    return cells[1,0];
                case 4:
                    return cells[1,1];
                case 5:
                    return cells[1,2];
                case 6:
                    return cells[2,0];
                case 7:
                    return cells[2,1];
                case 8:
                    return cells[2,2];   
                default:
                    return cells[0,0];

            }
        }

    
    }

}