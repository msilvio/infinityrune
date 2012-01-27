using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Infinity_TD
{
    class TileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth = 24;
        public int MapHeight = 24;
        public int[,] Map = new int[24, 24];
        public Random RNG = new Random();

        public TileMap()
        {
            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {
                    thisRow.Columns.Add(new MapCell(0));
                }
                Rows.Add(thisRow);
            }

            //Map = new int[12,16]
            //{
            //{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            //{ 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2 },
            //{ 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2 },
            //{ 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2 },
            //{ 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2 },
            //{ 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2 },
            //{ 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            //{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }        
            //};

            for (int row = 0; row < Map.GetLength(0); row++)
            {
                for (int column = 0; column < Map.GetLength(1); column++)
                {
                    Rows[row].Columns[column].TileID = Map[row, column];
                }
            }
            
        }

        public void initializeMap()
        {
            #region Init_Tiles
            for (int row = 0; row < Rows.Count(); row++)
            {
                for (int column = 0; column < Rows[row].Columns.Count(); column++)
                {
                    if (Rows[row].Columns[column].TileID == 1)
                    {
                        //MainTileList.Add(new MainTile());
                        //MainTileList.Last().tileCoordinates = new Vector2(column, row);
                        //MainTileList.Last().position.X = MainTileList.Last().tileCoordinates.X * 64;
                        //MainTileList.Last().position.Y = MainTileList.Last().tileCoordinates.Y * 64;
                        //MainTileList.Last().area = new Rectangle((int)MainTileList.Last().position.X, (int)MainTileList.Last().position.Y, 64, 64);
                        //Rows[row].Columns[column].TileID = 0;
                    }

                    if (Rows[row].Columns[column].TileID == 3)
                    {
                        //SpawnerList.Add(new EnemySpawner());
                        //SpawnerList.Last().tileCoordinates = new Vector2(column, row);
                        //SpawnerList.Last().position.X = SpawnerList.Last().tileCoordinates.X * 64;
                        //SpawnerList.Last().position.Y = SpawnerList.Last().tileCoordinates.Y * 64;
                        //SpawnerList.Last().area = new Rectangle((int)SpawnerList.Last().position.X, (int)SpawnerList.Last().position.Y, 64, 64);
                        //Rows[row].Columns[column].TileID = 0;
                    }

 
                }
            }
            #endregion
        }

        public int getTileId(Point posicao)
        {
            int x, y;
            x = (int)posicao.X / 32;
            y = (int)posicao.Y / 32;
            return this.Map[y, x];
        }
    }

    class MapRow
    {
        public List<MapCell> Columns = new List<MapCell>();
    }
}

