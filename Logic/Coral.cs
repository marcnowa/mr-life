using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Life.Logic
{
    class Coral: ISimulationLogic
    {
        public Coral(int mapX, int mapY, Neighbourhood neighbourhood):base(mapX,mapY,neighbourhood) {}

        
        public override Cell cellNextState(Cell[,] map, int x, int y)
        {
            int nCount = base.getNaighboursCount(map, x, y);


            if (map[x,y] == Cell.Alive || map[x,y]==Cell.Born){
                if (nCount > 3) return Cell.Alive;
            }

            if (map[x, y] == Cell.Dead)
            {
                if (nCount == 3) return Cell.Born;
            }
            return Cell.Dead;
        }
    }
}
