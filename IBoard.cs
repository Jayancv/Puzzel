using System.Collections.Generic;
using System;

namespace Assing3{

    // This objeect use to indicate basic operations of boards
    public interface IBoard
    {

        void SetWon(int y0);

        int GetWon();

        bool IsDone();

        bool IsVaildMove( int num);

        int ResolveBoard( List<int> cellNum );

        bool MarkCell(int player, List<int> cellNum);

        IBoard Clone();

        List<int> GetWinings();

        bool IsWiningMove(int player, List<int> cellNum);
        
    }

}