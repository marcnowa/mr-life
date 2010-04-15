using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Life.Logic
{
    public enum Neighbourhood
    {
        vonNeumans,
        Moors
    }

    abstract class ISimulationLogic
    {
        private int mapX;
        private int mapY;
        private Neighbourhood neighbourhood;


        protected ISimulationLogic(int mapX, int mapY, Neighbourhood neighbourhood)
        {
            this.mapX = mapX;
            this.mapY = mapY;
            this.neighbourhood = neighbourhood;
        }

        private int checkCell(Cell[,] map, int x, int y)
        {
            if (x < 0 || x >= mapX) return 0;
            if (y < 0 || y >= mapY) return 0;
            if (map[x, y] == Cell.Alive || map[x,y] == Cell.Born) return 1;
            return 0;
        }

        protected int getNaighboursCount(Cell[,] map, int x, int y)
        {
            int naighbours = 0;

            //Neighbourhood.vonNeumans
            naighbours += checkCell(map, x - 1, y)
                            + checkCell(map, x + 1, y)
                            + checkCell(map, x, y - 1)
                            + checkCell(map, x, y + 1);

            //Neighbourhood.Moors
            if (neighbourhood == Neighbourhood.Moors)
            {
                naighbours += checkCell(map, x - 1, y - 1)
                            + checkCell(map, x - 1, y + 1)
                            + checkCell(map, x + 1, y - 1)
                            + checkCell(map, x + 1, y + 1);
            }

            return naighbours;           
        }

        public abstract Cell cellNextState(Cell[,] map, int x, int y);
    }
}
