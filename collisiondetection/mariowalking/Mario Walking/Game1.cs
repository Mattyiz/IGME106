using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Mario_Walking
{
    // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
    // PRACTICE EXERCISE:  Enums are typically declared here!
    enum MarioState
    {
        FaceLeft,
        FaceRight,
        WalkLeft,
        WalkRight
    }

    // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private MarioState state;

        // Texture and drawing
        private Texture2D spriteSheet;  // The single image with all of the animation frames
        private Vector2 marioLoc;       // Mario's location on the screen

        // Animation
        private int frame;              // The current animation frame
        private double timeCounter;     // The amount of time that has passed
        private double fps;             // The speed of the animation
        private double timePerFrame;    // The amount of time (in fractional seconds) per frame

        // Constants for "source" rectangle (inside the image)
        private const int WalkFrameCount = 3;       // The number of frames in the animation
        private const int MarioRectOffsetY = 116;   // How far down in the image are the frames?
        private const int MarioRectHeight = 72;     // The height of a single frame
        private const int MarioRectWidth = 44;      // The width of a single frame

        // Constructor
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
            // Sets up the mario location
            marioLoc = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            // Initialize
            fps = 10.0;
            timePerFrame = 1.0 / fps;

            state = MarioState.FaceRight;

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

            // Load the single spritesheet
            spriteSheet = Content.Load<Texture2D>("Mario");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Handles animation for you
            UpdateAnimation(gameTime);

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            // PRACTICE EXERCISE: Add your finite state machine code (switch statement) here!
            // - Be sure to check the finite state machine's state first
            // - Then check for specific transitions inside each state (may require keyboard input)

            KeyboardState kb = Keyboard.GetState();

            switch (state){
                //This is for Mario facing right
                case MarioState.FaceRight:
                    //If he turns around
                    if (kb.IsKeyDown(Keys.Left)){
                        state = MarioState.WalkLeft;
                    }
                    //If he starts walking right
                    else if (kb.IsKeyDown(Keys.Right))
                    {
                        state = MarioState.WalkRight;
                    }
                    break;

                //This is for Mario facing left
                case MarioState.FaceLeft:
                    //If he starts moving left
                    if (kb.IsKeyDown(Keys.Left))
                    {
                        state = MarioState.WalkLeft;
                    }
                    //If he turns around
                    else if (kb.IsKeyDown(Keys.Right))
                    {
                        state = MarioState.WalkRight;
                    }
                    break;

                //This is for Mario walking right
                case MarioState.WalkRight:
                    //Checks to see if he stopped moving right
                    if (!kb.IsKeyDown(Keys.Right))
                    {
                        state = MarioState.FaceRight;
                    }
                    break;

                //This is for Mario walking left
                case MarioState.WalkLeft:
                    //Checks to see if he stopped moving left
                    if (!kb.IsKeyDown(Keys.Left))
                    {
                        state = MarioState.FaceLeft;
                    }
                    break;
            }


            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            
            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Begin the sprite batch
            spriteBatch.Begin();

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            // PRACTICE EXERCISE: Check the finite state machine state here to
            // determine how exactly to draw Mario
            //DrawMarioWalking(SpriteEffects.None); // You may alter/remove this line

            switch (state){
                //Facing Right
                case MarioState.FaceRight:
                    DrawMarioStanding(SpriteEffects.None);
                    break;

                //Facing left
                case MarioState.FaceLeft:
                    DrawMarioStanding(SpriteEffects.FlipHorizontally);
                    break;

                //Walking right
                case MarioState.WalkRight:
                    DrawMarioWalking(SpriteEffects.None);
                    marioLoc.X = marioLoc.X + 1;
                    break;

                //Walking left
                case MarioState.WalkLeft:
                    DrawMarioWalking(SpriteEffects.FlipHorizontally);
                    marioLoc.X = marioLoc.X - 1;
                    break;
            }


            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

            // End the sprite batch
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Updates mario's animation as necessary
        /// </summary>
        /// <param name="gameTime">Time information</param>
        private void UpdateAnimation(GameTime gameTime)
        {
            // Handle animation timing
            // - Add to the time counter
            // - Check if we have enough "time" to advance the frame
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeCounter >= timePerFrame)
            {
                frame += 1;                     // Adjust the frame

                if (frame > WalkFrameCount)     // Check the bounds
                    frame = 1;                  // Back to 1 (since 0 is the "standing" frame)

                timeCounter -= timePerFrame;    // Remove the time we "used"
            }
        }

        /// <summary>
        /// Draws only the left-most frame of mario, which is him standing
        /// </summary>
        /// <param name="flipSprite">
        /// Enum values for flipping the sprite horizontally
        /// and or vertically
        /// </param>
        private void DrawMarioStanding(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(
                spriteSheet,                    // - The texture to draw
                marioLoc,                       // - The location to draw on the screen
                new Rectangle(                  // - The "source" rectangle
                    0,                          //   - This rectangle specifies
                    MarioRectOffsetY,        //	   where "inside" the texture
                    MarioRectWidth,           //     to get pixels (We don't want to
                    MarioRectHeight),         //     draw the whole thing)
                Color.White,                    // - The color
                0,                              // - Rotation (none currently)
                Vector2.Zero,                   // - Origin inside the image (top left)
                1.0f,                           // - Scale (100% - no change)
                flipSprite,                     // - Can be used to flip the image
                0);                             // - Layer depth (unused)
        }

        /// <summary>
        /// Draws mario running, based on the current FRAME field
        /// which is changed by the code in Update
        /// </summary>
        /// <param name="flipSprite">
        /// Enum values for flipping the sprite horizontally
        /// and or vertically
        /// </param>
        private void DrawMarioWalking(SpriteEffects flipSprite)
        {
            spriteBatch.Draw(
                spriteSheet,                    // - The texture to draw
                marioLoc,                       // - The location to draw on the screen
                new Rectangle(                  // - The "source" rectangle
                    frame * MarioRectWidth,     //   - This rectangle specifies
                    MarioRectOffsetY,           //	   where "inside" the texture
                    MarioRectWidth,             //     to get pixels (We don't want to
                    MarioRectHeight),           //     draw the whole thing)
                Color.White,                    // - The color
                0,                              // - Rotation (none currently)
                Vector2.Zero,                   // - Origin inside the image (top left)
                1.0f,                           // - Scale (100% - no change)
                flipSprite,                     // - Can be used to flip the image
                0);                             // - Layer depth (unused)
        }
    }
}
