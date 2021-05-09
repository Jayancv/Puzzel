using System.Collections.Generic;
using System;

namespace Assing3{

    // This objeect use to indicate basic operations
    public interface IBoard
    {

        public void SetWon(int y0);

        public int GetWon();

        public bool IsDone();

        public bool IsVaildMove( int num);

        public int ResolveBoard( List<int> cellNum );

        public bool MarkCell(int player, List<int> cellNum);

        // public bool Mark(int player, List<int> cellNum);

        public IBoard Clone();

        public List<int> GetWinings();

        public bool IsWiningMove(int player, List<int> cellNum);
    
    }

}