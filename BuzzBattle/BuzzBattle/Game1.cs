using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BuzzBattle
{
    /// <summary>
    /// Matt I. has the whole squad laughin'
    /// Beep boop bop Justin Cheng Here Botches
    /// Who wrote the song "Radioactive"?
    /// Grunt
    /// THIS ISN"T A QUEEN!! THIS IS A DRAG QUEEN!! - Barry B. Benson
    /// </summary>
    
    //Edits: Matt C - 3/3, 3/4: Matt I - 3/4: Justin - 3/4
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private SpriteFont arial14;
        private SpriteFont gill24;
        private SpriteFont actualGill24;

        private FSMLogic fsm;

        private KeyboardState kb;
        private KeyboardState previousKb;
        private MouseState ms;
        private MouseState previousMs;



        private Player player;

        private EnemyManager enemyManager;
        
        private Hive homeBase;

        private int currentCD;
        private const int waveCD = 180;

        

        Texture2D betterTriangle;
        Texture2D circle;
        Texture2D square;
        Texture2D background;
        Texture2D noRoll;
        Texture2D roll;
        Texture2D menuScreens;
        Texture2D instructions;
        Texture2D logo;
        Texture2D bullet;
        Texture2D hive;

        #region Bee textures
        Texture2D beeW;
        Texture2D beeWD;
        Texture2D beeD;
        Texture2D beeDS;
        Texture2D beeS;
        Texture2D beeSA;
        Texture2D beeA;
        Texture2D beeAW;
        #endregion

        #region Beetle Textures
        Texture2D beetleUp;
        Texture2D beetleLeft;
        Texture2D beetleDown;
        Texture2D beetleRight;
        #endregion
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            arial14 = Content.Load<SpriteFont>("File");
            gill24 = Content.Load<SpriteFont>("Text");
            actualGill24 = Content.Load<SpriteFont>("actualGill24");
            betterTriangle = Content.Load<Texture2D>("betterTriangle");
            square = Content.Load<Texture2D>("square");
            circle = Content.Load<Texture2D>("circle1");
            background = Content.Load<Texture2D>("Assets/Edited Background");
            noRoll = Content.Load<Texture2D>("Assets/honeycomb");
            roll = Content.Load<Texture2D>("Assets/honeydrip");
            menuScreens = Content.Load<Texture2D>("Assets/Beehive");
            instructions = Content.Load<Texture2D>("Assets/instructions");
            logo = Content.Load<Texture2D>("Assets/Buzz Battle Logo");
            bullet = Content.Load<Texture2D>("Assets/Bullet");
            hive = Content.Load<Texture2D>("Assets/hive");

            //Bee Textures
            beeW = Content.Load<Texture2D>("Assets/BeeW");
            beeWD = Content.Load<Texture2D>("Assets/BeeWD");
            beeD = Content.Load<Texture2D>("Assets/BeeD");
            beeDS = Content.Load<Texture2D>("Assets/BeeDS");
            beeS = Content.Load<Texture2D>("Assets/BeeS");
            beeSA = Content.Load<Texture2D>("Assets/BeeSA");
            beeA = Content.Load<Texture2D>("Assets/BeeA");
            beeAW = Content.Load<Texture2D>("Assets/BeeAW");

            //Beetle Textures
            beetleUp = Content.Load<Texture2D>("Assets/Beetle Up");
            beetleRight = Content.Load<Texture2D>("Assets/Beetle Right");
            beetleDown = Content.Load<Texture2D>("Assets/Beetle Down");
            beetleLeft = Content.Load<Texture2D>("Assets/Beetle Left");
            // TODO: use this.Content to load your game content here

            homeBase = new Hive(hive, new Rectangle(GraphicsDevice.Viewport.Width / 2 - 50, GraphicsDevice.Viewport.Height / 2 - 50, 100, 100), 100);
            
            enemyManager = new EnemyManager(
                circle,
                new Rectangle(
                    homeBase.X,
                    homeBase.Y,
                    homeBase.Width,
                    homeBase.Health),
                homeBase,
                GraphicsDevice.Viewport.Width,
                GraphicsDevice.Viewport.Height
                );

            enemyManager.SpawnLocationLeft = new Rectangle(0, GraphicsDevice.Viewport.Height / 2, 75, 75);
            enemyManager.SpawnLocationRight = new Rectangle(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height / 2, 75, 75);
            enemyManager.SpawnLocationTop = new Rectangle(GraphicsDevice.Viewport.Width / 2, 0, 75, 75);
            enemyManager.SpawnLocationBot = new Rectangle(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height, 75, 75);

            player = new Player(beeDS, new Rectangle(50, 50, 75, 75), bullet, homeBase, enemyManager);
            player.MaxX = GraphicsDevice.Viewport.Width;
            player.MaxY = GraphicsDevice.Viewport.Height;

            currentCD = 0;
            fsm = new FSMLogic(player, homeBase, enemyManager, roll, noRoll);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //Exit();

            // TODO: Add your update logic here
            previousKb = kb;
            kb = Keyboard.GetState();
            previousMs = ms;
            ms = Mouse.GetState();
            fsm.Update();

            if(fsm.CState == GameState.GamePlay)
            {
                player.KeyBoardInput(kb, previousKb, ms, previousMs);

                #region Player Sprite Change(WIP)

                //W and WD
                if(player.KbVert.IsKeyDown(Keys.W))
                {
                    player.Sprite = beeW;
                    System.Console.WriteLine("beeW");
                }
                

                //D and DS
                if (player.KbVert.IsKeyDown(Keys.D))
                {
                    player.Sprite = beeD;
                    System.Console.WriteLine("beeD");
                }
                

                //S and SA
                if (player.KbVert.IsKeyDown(Keys.S))
                {
                    player.Sprite = beeS;
                    System.Console.WriteLine("beeS");
                }
                

                //A and AW
                if (player.KbVert.IsKeyDown(Keys.A))
                {
                    player.Sprite = beeA;
                    System.Console.WriteLine("beeA");
                }
                
                #endregion

                #region Enemies
                enemyManager.Spawn(); //spawn the enemies accordingly
                foreach(Enemy enemy in enemyManager.Enemies)
                {
                    if(enemy.Direction == 'T')
                    {
                        enemy.Sprite = beetleDown;
                    }
                    if(enemy.Direction == 'L')
                    {
                        enemy.Sprite = beetleRight;
                    }
                    if(enemy.Direction == 'B')
                    {
                        enemy.Sprite = beetleUp;
                    }
                    if(enemy.Direction == 'R')
                    {
                        enemy.Sprite = beetleLeft;
                    }
                }
                homeBase.PrevHealth = homeBase.Health; //getting the health of the hive from the previous frame (aka the frame before update happens)
                enemyManager.Update(); //move the enemies that have spawned and make them attack & damage the base
                #endregion

                player.Projectiles.UpdateProjectiles();
                /*
                for (int i = 0; i < player.Projectiles.Count; i++)
                {
                    if (player.Projectiles[i].CanMove(homeBase.Pos))
                    {
                        player.Projectiles[i].Move();
                    }
                    else
                    {
                        player.Projectiles.RemoveAt(i);
                    }
                }*/
            }

            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            if(fsm.CState == GameState.GamePlay)
            {
                fsm.Draw(spriteBatch, arial14, background, gill24);
                player.Draw(spriteBatch);
                enemyManager.Draw(spriteBatch);
                spriteBatch.DrawString(actualGill24, "Hive Health: " + homeBase.Health, new Vector2(50, GraphicsDevice.Viewport.Height - 75), Color.Black);
                spriteBatch.DrawString(actualGill24, "      " + enemyManager.WaveManager.currentWave.Name, new Vector2(300, GraphicsDevice.Viewport.Height - 75), Color.Black);
                spriteBatch.DrawString(actualGill24, "Score: " + player.Score, new Vector2(500, GraphicsDevice.Viewport.Height - 75), Color.Black);
                if (homeBase.Health != 0)
                {
                    homeBase.Draw(spriteBatch);
                }

                for (int i = 0; i < player.Projectiles.Count; i++)
                {
                    player.Projectiles[i].Draw(spriteBatch);
                }

                
            }

            else
            {
                fsm.Draw(spriteBatch, arial14, menuScreens, gill24);
                if(fsm.CState == GameState.Instructions)
                {
                    spriteBatch.Draw(instructions, new Rectangle(200, 25, 400, 300), Color.White);
                }

                else if(fsm.CState == GameState.Menu)
                {
                    spriteBatch.Draw(logo, new Rectangle(75, 10, 650, 325), Color.White);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
