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
        Reproducing
    }

    public class Population
    {
        private Cell[,] map;
        private int mapSize;
        private Random randomGenerator;

        public Population(int mapSize)
        {
            map = new Cell[mapSize, mapSize];
            this.mapSize = mapSize;
            randomGenerator = new Random();

            RandomState();
        }

        private void RandomState()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = (Cell)randomGenerator.Next(3);
                }
            }
        }

        private Color GetColor(Cell cell)
        {
            switch (cell)
            {
                case Cell.Dead:
                    return Color.White;
                case Cell.Alive:
                    return Color.Black;
                case Cell.Reproducing:
                    return Color.Red;

                default:
                    return Color.White;
            }
        }



        public void NextState()
        {
            RandomState();
        }

        public Bitmap GetCurrentImage()
        {
            Bitmap bmp = new Bitmap(mapSize, mapSize);
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Color color = GetColor(map[i, j]);
                    bmp.SetPixel(i, j, color);
                }
            }
            return bmp;
        }
    }
}
