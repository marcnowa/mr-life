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

        private Brush GetBrush(Cell cell)
        {
            switch (cell)
            {
                case Cell.Dead:
                    return Brushes.White;
                case Cell.Alive:
                    return Brushes.Black;
                case Cell.Reproducing:
                    return Brushes.Red;

                default:
                    return Brushes.White;
            }
        }



        public void NextState()
        {
            RandomState();
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
