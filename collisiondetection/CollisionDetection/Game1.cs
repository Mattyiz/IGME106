using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Matt Izzo, Collision Detection, this is where everything is drawn
namespace CollisionDetection
{

    enum GameState
    {
        Square,
        Circle
    }


    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D image;
        private SquareEntity squarePlayer;
        private List<SquareEntity> squareObsticles;
        private Random ran;

        private Texture2D imageCircle;
        private CircleEntity circlePlayer;
        private List<CircleEntity> circleObsticles;

        private GameState state;
        private SpriteFont arial20;

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

            ran = new Random();

            state = GameState.Square;

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

            // TODO: use this.Content to load your game content here
            
            image = Content.Load<Texture2D>("square");

            squarePlayer = new SquareEntity(image, 50, 50);

            squareObsticles = new List<SquareEntity>();
            for(int i = 0; i < 10; i++)
            {
                SquareEntity obsticle = new SquareEntity(image,
                    ran.Next(GraphicsDevice.Viewport.Width),
                    ran.Next(GraphicsDevice.Viewport.Height),
                    ran.Next(5, 50),
                    ran.Next(5, 50));

                

                squareObsticles.Add(obsticle);
            }
            
            imageCircle = Content.Load<Texture2D>("circle");

            circlePlayer = new CircleEntity(imageCircle, 50, 50);

            circleObsticles = new List<CircleEntity>();
            for(int i = 0; i < 10; i++)
            {
                CircleEntity obsticle = new CircleEntity(imageCircle,
                    ran.Next(GraphicsDevice.Viewport.Width),
                    ran.Next(GraphicsDevice.Viewport.Height),
                    ran.Next(5, 50));

                

                circleObsticles.Add(obsticle);
            }

            arial20 = Content.Load<SpriteFont>("Arial20");

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            KeyboardState kbState = Keyboard.GetState();
            

            switch (state){
                case GameState.Square:
                    //Left
                    if (kbState.IsKeyDown(Keys.A))
                    {
                        squarePlayer.X = squarePlayer.X - 5;
                    }

                    //Right
                    if (kbState.IsKeyDown(Keys.D))
                    {
                        squarePlayer.X = squarePlayer.X + 5;

                    }

                    //Up
                    if (kbState.IsKeyDown(Keys.W))
                    {
                        squarePlayer.Y = squarePlayer.Y - 5;

                    }

                    //Down
                    if (kbState.IsKeyDown(Keys.S))
                    {
                        squarePlayer.Y = squarePlayer.Y + 5;
                    }


                    //Switch
                    if (kbState.IsKeyDown(Keys.D2))
                    {
                        state = GameState.Circle;
                    }
                    break;

                case GameState.Circle:
                    //Left
                    if (kbState.IsKeyDown(Keys.A))
                    {
                        circlePlayer.X = circlePlayer.X - 5;
                    }

                    //Right
                    if (kbState.IsKeyDown(Keys.D))
                    {
                        circlePlayer.X = circlePlayer.X + 5;

                    }

                    //Up
                    if (kbState.IsKeyDown(Keys.W))
                    {
                        circlePlayer.Y = circlePlayer.Y - 5;

                    }

                    //Down
                    if (kbState.IsKeyDown(Keys.S))
                    {
                        circlePlayer.Y = circlePlayer.Y + 5;
                    }


                    //Switch
                    if (kbState.IsKeyDown(Keys.D1))
                    {
                        state = GameState.Square;
                    }

                    break;

            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            bool drawn = false;
            
            switch (state){
                case GameState.Square:
                    for (int i = 0; i < squareObsticles.Count; i++)
                    {
                        if (squarePlayer.Intersects(squareObsticles[i]))
                        {
                            squarePlayer.Draw(spriteBatch, Color.Red);
                            squareObsticles[i].Draw(spriteBatch, Color.Red);
                            drawn = true;
                        }
                        else
                        {
                            squareObsticles[i].Draw(spriteBatch, Color.White);
                        }
                
                    }

                    if (!drawn)
                    {
                        squarePlayer.Draw(spriteBatch, Color.Blue);
                    }

                    spriteBatch.DrawString(arial20,
                        "Intersect",
                        new Vector2(30, 400),
                        Color.White);


                    break;

                    case GameState.Circle:
                        for (int i = 0; i < circleObsticles.Count; i++)
                        {
                            if (circlePlayer.Intersects(circleObsticles[i]))
                            {
                                circlePlayer.Draw(spriteBatch, Color.Red);
                                circleObsticles[i].Draw(spriteBatch, Color.Red);
                                drawn = true;
                            }
                            else
                            {
                                circleObsticles[i].Draw(spriteBatch, Color.White);
                            }
                
                        }

                        if (!drawn)
                        {
                            circlePlayer.Draw(spriteBatch, Color.Blue);
                        }

                        spriteBatch.DrawString(arial20,
                            "Circle-Circle",
                            new Vector2(30, 400),
                            Color.White);

                        break;
            }
            
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
