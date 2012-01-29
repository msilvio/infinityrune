using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Infinity_TD_Library;

namespace Infinity_TD
{
    public sealed class PlayingState : BaseGameState, IPlayingState
    {
        MouseState previousState;
        SpriteFont font;
        Random rand;
        Interface hud = new Interface();
        Texture2D enemyTexture;

        TileMap tileMap;

        public Texture2D stageTexture;

        EnemyManager enemyManager;
        List<Tower> towers = new List<Tower>();

        float timeWaveGenerate;
        float elapsedTimeGenerator;

        public PlayingState(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IPlayingState), this);
            rand = new Random();
        }

        public void verifyEndGame()
        {
            if (Infinity_TD.GameManager.currentWave > Infinity_TD.GameManager.totalWaves)
            {
                Infinity_TD.GameManager.currentLevel++;
                Infinity_TD.GameManager.currentWave = 0;
            }
        }

        public void initializeLevel()
        {
            OurGame.soundManager.playSong();

            switch (Infinity_TD.GameManager.currentLevel)
            {
                case 0:
                    timeWaveGenerate = 10.0f;
                    break;
                case 1:
                    stageTexture = Content.Load<Texture2D>("");
                    timeWaveGenerate = 5.0f;
                    ReinitializeMap(1);
                    break;
                case 2:
                    stageTexture = Content.Load<Texture2D>("");
                    ReinitializeMap(2);
                    break;
                case 3:
                    //Deserto
                    stageTexture = Content.Load<Texture2D>("");
                    OurGame.soundManager.soundLoad("Desert Song");
                    ReinitializeMap(3);
                    break;
                case 4:
                    stageTexture = Content.Load<Texture2D>("");
                    ReinitializeMap(4);
                    break;
                case 5:
                    stageTexture = Content.Load<Texture2D>("");
                    ReinitializeMap(5);
                    break;
                case 6:
                    stageTexture = Content.Load<Texture2D>("");
                    ReinitializeMap(6);
                    break;
                case 7:
                    stageTexture = Content.Load<Texture2D>("");
                    ReinitializeMap(7);
                    break;
                case 8:
                    if (Infinity_TD.GameManager.hard == false)
                    {
                        Infinity_TD.GameManager.currentLevel = 1;
                        Infinity_TD.GameManager.hard = true;
                        ReinitializeMap(1);

                    }
                    else
                    {
                        stageTexture = Content.Load<Texture2D>("");
                    }
                    break;

            }
        }

        public void ReinitializeMap(int levelID)
        {
            tileMap = new TileMap(levelID);
            tileMap.initializeMap();

        }

        public void generateTower(Tiles.EmptyTile emptyTile)
        {
            towers.Add(Tower.getTower<LightningTower>(Game, 10.0f, tileMap.EmptyTileList[emptyTile.index].position, 0.14f));
        }

        protected override void LoadContent()
        {
            for (int i = 0; i < 3; i++)
            {
                RuneManager.InsertRune(i, 3);
            }
            enemyTexture = Content.Load<Texture2D>("Graphics/Enemy/_Robo1");
            MapArrays.mapListInit();
            tileMap = new TileMap(0);
            tileMap.initializeMap();
            hud.InitializeInterface(this.Content);

            foreach (Infinity_TD.Tiles.Waypoint waypoint in tileMap.WaypointList)
            {
                waypoint.teste = Content.Load<Texture2D>("Graphics/Stuff/Cursor1");
            }

            stageTexture = Content.Load<Texture2D>(@"Graphics\Scenes\floresta");
            font = Content.Load<SpriteFont>("Fonts/menu_font");

            enemyManager = new EnemyManager();

            //for (int i = 0; i < 4; ++i)
            //{
            //    enemyManager.Add(new Enemy(tileMap.SpawnPointList[0].position, enemyTexture));
            //}

            //enemyManager.generateEnemiesWave(tileMap.SpawnPointList[0].position, Content, new EnemyWave(Infinity_TD.GameManager.currentLevel));

            font = Content.Load<SpriteFont>("Fonts/hud_font");

            initializeLevel();

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            hud.UpdateInterface(gameTime, OurGame.mouseRec, previousState);

            if (Input.WasPressed(0, InputHandler.ButtonType.Back, Keys.Escape))
                GameManager.PushState(OurGame.OptionsMenuState.Value);

            if (Input.WasPressed(0, InputHandler.ButtonType.Start, Keys.Enter))
                GameManager.PushState(OurGame.PausedState.Value); // push our paused state onto the stack

            #region UpdateEmptyTiles

            foreach (Tiles.EmptyTile emptyTile in tileMap.EmptyTileList)
            {
                if (emptyTile.area.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
                {
                    if ((hud.currentTower != Combinator.Tower.INVALID) && (Mouse.GetState().LeftButton == ButtonState.Pressed) && (emptyTile.full == false))
                    {
                        generateTower(emptyTile);
                        emptyTile.full = true;
                        hud.currentTower = Combinator.Tower.INVALID;
                        hud.altMouseTex = null;
                    }
                }
            }

            #endregion


            UpdateEnemies(gameTime);

            foreach (Tower tower in towers)
            {
                tower.Update(gameTime);

                HandleCollision(tower, gameTime);
            }

            elapsedTimeGenerator += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (elapsedTimeGenerator > timeWaveGenerate)
            {
                enemyManager.generateEnemiesWave(tileMap.SpawnPointList[0].position, Content, new EnemyWave(Infinity_TD.GameManager.currentLevel));
                elapsedTimeGenerator -= timeWaveGenerate;
            }

            previousState = Mouse.GetState();
            base.Update(gameTime);
        }

        private void UpdateEnemies(GameTime gameTime)
        {
            enemyManager.Update(gameTime, tileMap);

            int drops = enemyManager.Drops;
            if (drops > 0)
            {
                while (drops != 0)
                {
                    //RuneManager.
                    //runeManager.InsertRune(, 1);

                    --drops;
                }
            }
        }

        private void HandleCollision(Tower tower, GameTime gameTime)
        {
            List<Enemy> enemies = enemyManager.Collide(tower);
            if (enemies != null)
            {
                Enemy nearEnemy = null;
                float maxDistance = 1000.0f;
                foreach (Enemy enemy in enemies)
                {
                    float actualDinstance = Vector2.Distance(enemy.Position, tower.Position);
                    if (maxDistance > actualDinstance)
                    {
                        maxDistance = actualDinstance;
                        nearEnemy = enemy;
                    }
                }
                tower.FireToEnemy(nearEnemy, tower.Position, Content.Load<Texture2D>(@"Graphics\Stuff\cursor2"));
            }

            foreach (Shot shot in tower.Shots)
            {
                foreach (Enemy enemy in enemyManager.Enemies)
                {
                    if (enemy.BoundRect.Intersects(shot.BoundRect))
                    {
                        enemy.onCollision(shot);
                    }
                }

            }
        }

        public override void Draw(GameTime gameTime)
        { 
            OurGame.SpriteBatch.Draw(stageTexture, Vector2.Zero, Color.White);
            enemyManager.Draw(OurGame.SpriteBatch);
            hud.DrawInterface(OurGame.SpriteBatch);

            foreach (Tower tower in towers)
            {
                tower.Draw(OurGame.SpriteBatch);
            }

            OurGame.SpriteBatch.DrawString(font, tileMap.WaypointList[6].position.ToString() + tileMap.WaypointList[6].DirectionList[0].ToString(), Vector2.Zero, Color.White);

            base.Draw(gameTime);
        }

        protected override void StateChanged(object sender, EventArgs e)
        {
            base.StateChanged(sender, e);

            if (GameManager.State != this.Value)
            {
                Visible = true;
                Enabled = false;
            }
        }
    }
}