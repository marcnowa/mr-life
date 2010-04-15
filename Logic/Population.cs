using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Life.Logic
{
    public enum Cell
    {
        Dead,
        Alive,
        Born
    }

    public class Population
    {
        private Cell[,] map;
        private Cell[,] tmpMap;
        private Cell[,] unActiveMap;
        private int mapSize;
        private Random randomGenerator;
        private ISimulationLogic simulationLogic;
        public Population(int mapSize)
        {
            map = new Cell[mapSize, mapSize];
            unActiveMap = new Cell[mapSize, mapSize];
            this.mapSize = mapSize;
            randomGenerator = new Random();
            simulationLogic = new Coral(mapSize, mapSize, Neighbourhood.Moors);
//            RandomState();
            CenterState();

        }


        private void CenterState()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = Cell.Dead;
                }
            }


            int delta = 200;
            int _modi = 1;
            int _modj = 2;
            for (int i = mapSize/2 - delta; i < mapSize/2 + delta; i++)
            {
                for (int j = mapSize/2 - delta; j < mapSize/2 + delta; j++)
                {
                    if ((i % _modi) == 0 && (j % _modj) ==0) map[i, j] = Cell.Born;
                }
            }
        }


        private void RandomState()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = (Cell)randomGenerator.Next(2);
                }
            }
        }



        private void getNextState()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    unActiveMap[i, j] = simulationLogic.cellNextState(map, i, j);
                }
            }
        }

        private Brush GetBrush(Cell cell)
        {
            switch (cell)
            {
                case Cell.Dead:
                    return Brushes.White;
                case Cell.Alive:
                    return Brushes.Black;
                case Cell.Born:
                    return Brushes.Red;

                default:
                    return Brushes.White;
            }
        }



        public void NextState()
        {
            getNextState();

            tmpMap = map;
            map = unActiveMap;
            unActiveMap = tmpMap;
        }

        public Bitmap GetCurrentImage()
        {
            return GetCurrentImage(1, new Point(0, 0));
        }

        public Bitmap GetCurrentImage(int cellSize, Point upperLeftCorner)
        {
            Bitmap bmp = new Bitmap(mapSize, mapSize);
            Graphics gbmp = Graphics.FromImage(bmp);
            int size = mapSize / cellSize;

            for (int i = upperLeftCorner.X; i < size+upperLeftCorner.X; i++)
            {
                for (int j = upperLeftCorner.Y; j < size+upperLeftCorner.Y; j++)
                {
                    
                    Brush b = GetBrush(map[i, j]);
                    
                    gbmp.FillRectangle(b, new Rectangle(i*cellSize, j*cellSize, cellSize, cellSize));
                }
            }

            return bmp;
        }
    }
}
