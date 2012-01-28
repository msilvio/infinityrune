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
        public List<Tiles.EmptyTile> EmptyTileList = new List<Tiles.EmptyTile>();
        public List<Tiles.RoadTile> RoadTileList = new List<Tiles.RoadTile>();
        public List<Tiles.BlockedTile> BlockedTileList = new List<Tiles.BlockedTile>();
        public List<Tiles.Waypoint> WaypointList = new List<Tiles.Waypoint>();
        public List<Tiles.SpawnPoint> SpawnPointList = new List<Tiles.SpawnPoint>();
        public List<Nexus> NexusList = new List<Nexus>();
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

            //Map = new int[24,24]
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

        //INDEX DOS TILES:
        // TILE VAZIO (PARA AS TORRES) -- 1
        // ESTRADA -- 2
        // TILE BLOQUEADO -- SEM TORRES -- 3
        // WAYPOINT 1 -- 4
        // WAYPOINT 2 -- 5
        // WAYPOINT 3 -- 6
        // ENTRADA -- 7
        // NEXUS -- 8
   

        public void initializeMap()
        {
            #region Init_Tiles
            for (int row = 0; row < Rows.Count(); row++)
            {
                for (int column = 0; column < Rows[row].Columns.Count(); column++)
                {
                    if (Rows[row].Columns[column].TileID == 1)
                    {
                        EmptyTileList.Add(new Tiles.EmptyTile());
                        EmptyTileList.Last().position.X = column * 32;
                        EmptyTileList.Last().position.Y = row * 32;
                        EmptyTileList.Last().area = new Rectangle((int)EmptyTileList.Last().position.X, (int)EmptyTileList.Last().position.Y, 32, 32);
                        Rows[row].Columns[column].TileID = 0;
                    }

                    if (Rows[row].Columns[column].TileID == 2)
                    {
                        RoadTileList.Add(new Tiles.RoadTile());
                        RoadTileList.Last().position.X = column * 32;
                        RoadTileList.Last().position.Y = row * 32;
                        RoadTileList.Last().area = new Rectangle((int)RoadTileList.Last().position.X, (int)RoadTileList.Last().position.Y, 32, 32);
                        Rows[row].Columns[column].TileID = 0;
                    }

                    if (Rows[row].Columns[column].TileID == 3)
                    {
                        BlockedTileList.Add(new Tiles.BlockedTile());
                        BlockedTileList.Last().position.X = column * 32;
                        BlockedTileList.Last().position.Y = row * 32;
                        BlockedTileList.Last().area = new Rectangle((int)BlockedTileList.Last().position.X, (int)BlockedTileList.Last().position.Y, 32, 32);
                        Rows[row].Columns[column].TileID = 0;
                    }

                    if (Rows[row].Columns[column].TileID == 4)
                    {
                        WaypointList.Add(new Tiles.Waypoint());
                        WaypointList.Last().position.X = column * 32;
                        WaypointList.Last().position.Y = row * 32;
                        WaypointList.Last().area = new Rectangle((int)WaypointList.Last().position.X, (int)WaypointList.Last().position.Y, 32, 32);
                        WaypointList.Last().index = 1;
                        Rows[row].Columns[column].TileID = 0;
                    }

                    if (Rows[row].Columns[column].TileID == 5)
                    {
                        WaypointList.Add(new Tiles.Waypoint());
                        WaypointList.Last().position.X = column * 32;
                        WaypointList.Last().position.Y = row * 32;
                        WaypointList.Last().area = new Rectangle((int)WaypointList.Last().position.X, (int)WaypointList.Last().position.Y, 32, 32);
                        WaypointList.Last().index = 2;
                        Rows[row].Columns[column].TileID = 0;
                    }

                    if (Rows[row].Columns[column].TileID == 6)
                    {
                        WaypointList.Add(new Tiles.Waypoint());
                        WaypointList.Last().position.X = column * 32;
                        WaypointList.Last().position.Y = row * 32;
                        WaypointList.Last().area = new Rectangle((int)WaypointList.Last().position.X, (int)WaypointList.Last().position.Y, 32, 32);
                        WaypointList.Last().index = 3;
                        Rows[row].Columns[column].TileID = 0;
                    }

                    if (Rows[row].Columns[column].TileID == 7)
                    {
                        SpawnPointList.Add(new Tiles.SpawnPoint());
                        SpawnPointList.Last().position.X = column * 32;
                        SpawnPointList.Last().position.Y = row * 32;
                        SpawnPointList.Last().area = new Rectangle((int)SpawnPointList.Last().position.X, (int)SpawnPointList.Last().position.Y, 32, 32);
                        Rows[row].Columns[column].TileID = 0;
                    }

                    if (Rows[row].Columns[column].TileID == 8)
                    {
                        NexusList.Add(new Nexus());
                        NexusList.Last().position.X = column * 32;
                        NexusList.Last().position.Y = row * 32;
                        NexusList.Last().area = new Rectangle((int)NexusList.Last().position.X, (int)NexusList.Last().position.Y, 32, 32);
                        Rows[row].Columns[column].TileID = 0;
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

