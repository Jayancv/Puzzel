using System.Collections.Generic;
using System;

namespace Assing3{

    // This objeect use to store user paremeters to create shapes
    public class ItemParam
    {
        private int y ;
        private int x ;
        private int depth;
        private List<int> codes =  new List<int>(); 


        public ItemParam( int x0,int y0)
        {
            x=x0;
            y=y0;
        }

        public ItemParam( int x0,List<int> code)
        {
            depth=x0;
            codes=code;
        }

        public ItemParam( int x0 )
        {
            depth=x0;
            
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

        public void SetCodes(List<int> code){
            codes =  code;
        }

        public List<int> GetCodes(){
            return codes;
        }

        public int GetDepth(){
            // if(String.IsNullOrEmpty(codes) ){
            //     return 0;
            // }
            // return codes.Length;
            return depth;
        }

        public void SetDepth(int dep){
            depth = dep; 
        }

        public void AddCoordinates(int cod){
            codes.Add(cod);
        }
    
    }

}