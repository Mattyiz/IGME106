using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Homework2
{

    //The direction that the player is facing
    enum PlayerState
    {
        FaceLeft,
        FaceRight,
        FaceUp,
        FaceDown,
        WalkLeft,
        WalkRight,
        WalkUp,
        WalkDown,
        WalkLeftUp,
        WalkLeftDown,
        WalkRightUp,
        WalkRightDown
    }

    //This is for the game state
    enum GameState
    {
        Menu,
        Game,
        GameOver
    }

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private PlayerState pState; //Direction the play faces
        private GameState gState; //Game state

        private Player player; //The player
        private List<Collectible> collectibles; //The collectables
        private int level; //The level
        private double timer; //The timer
        private KeyboardState kb; //Keyboard state
        private KeyboardState previousKb; //The previous keyboard state

        private SpriteFont arial36; //Big font
        private SpriteFont arial20; //Smaller font

        private Texture2D spriteSheet; //Player's sprite
        private Texture2D slugma; //Slugma
        private Random ran; //Randomizer for slugma's locations


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

            collectibles = new List<Collectible>();

            ran = new Random();


            pState = PlayerState.FaceDown;
            gState = GameState.Menu;

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

            spriteSheet = Content.Load<Texture2D>("PokemonTrainer");
            slugma = Content.Load<Texture2D>("Slugma");

            arial36 = Content.Load < SpriteFont>("Arial36");
            arial20 = Content.Load<SpriteFont>("Arial20");


            player = new Player(spriteSheet, 0, 0);

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

            player.UpdateAnimation(gameTime);

            kb = Keyboard.GetState();

            switch(gState)
            {
                //For the menu
                case GameState.Menu:
                    if (SingleKeyPress(Keys.Enter)){
                        gState = GameState.Game;
                        ResetGame();
                    }
                    break;

                    //For the game
                case GameState.Game:
                    previousKb = kb;
                    timer = timer - gameTime.ElapsedGameTime.TotalSeconds;
                    
                    //This is a really ugly switch statement for the player's direction and movement
                    switch (pState){
                        //This is for facing up
                        case PlayerState.FaceUp:
                            //If he starts walking left
                            if (kb.IsKeyDown(Keys.Left)){
                                pState = PlayerState.WalkLeft;
                            }
                            //If he starts walking right
                            else if (kb.IsKeyDown(Keys.Right))
                            {
                                pState = PlayerState.WalkRight;
                            }
                            //This is if he starts walking up
                            else if (kb.IsKeyDown(Keys.Up))
                            {
                                pState = PlayerState.WalkUp;
                            }
                            //This is if he starts walking down
                            else if (kb.IsKeyDown(Keys.Down))
                            {
                                pState = PlayerState.WalkDown;
                            }
                            break;

                        //This is for facing down
                        case PlayerState.FaceDown:
                            //If he starts walking left
                            if (kb.IsKeyDown(Keys.Left)){
                                pState = PlayerState.WalkLeft;
                            }
                            //If he starts walking right
                            else if (kb.IsKeyDown(Keys.Right))
                            {
                                pState = PlayerState.WalkRight;
                            }
                            //This is if he starts walking up
                            else if (kb.IsKeyDown(Keys.Up))
                            {
                                pState = PlayerState.WalkUp;
                            }
                            //This is if he starts walking down
                            else if (kb.IsKeyDown(Keys.Down))
                            {
                                pState = PlayerState.WalkDown;
                            }
                            break;

                        //This is for facing right
                        case PlayerState.FaceRight:
                            //If he starts walking left
                            if (kb.IsKeyDown(Keys.Left)){
                                pState = PlayerState.WalkLeft;
                            }
                            //If he starts walking right
                            else if (kb.IsKeyDown(Keys.Right))
                            {
                                pState = PlayerState.WalkRight;
                            }
                            //This is if he starts walking up
                            else if (kb.IsKeyDown(Keys.Up))
                            {
                                pState = PlayerState.WalkUp;
                            }
                            //This is if he starts walking down
                            else if (kb.IsKeyDown(Keys.Down))
                            {
                                pState = PlayerState.WalkDown;
                            }
                            break;

                        //This is for facing left
                        case PlayerState.FaceLeft:
                            //If he starts walking left
                            if (kb.IsKeyDown(Keys.Left)){
                                pState = PlayerState.WalkLeft;
                            }
                            //If he starts walking right
                            else if (kb.IsKeyDown(Keys.Right))
                            {
                                pState = PlayerState.WalkRight;
                            }
                            //This is if he starts walking up
                            else if (kb.IsKeyDown(Keys.Up))
                            {
                                pState = PlayerState.WalkUp;
                            }
                            //This is if he starts walking down
                            else if (kb.IsKeyDown(Keys.Down))
                            {
                                pState = PlayerState.WalkDown;
                            }
                            break;

                        //This is for walking Up
                        case PlayerState.WalkUp:
                            //Checks to see if he stopped moving up
                            if (!kb.IsKeyDown(Keys.Up))
                            {
                                pState = PlayerState.FaceUp;
                            }
                            //If he moves left and up
                            else if (kb.IsKeyDown(Keys.Left)){
                                pState = PlayerState.WalkLeftUp;
                            }
                            //If he moves right and up
                            else if (kb.IsKeyDown(Keys.Right)){
                                pState = PlayerState.WalkRightUp;
                            }
                            MovePlayer(0, -2);
                            break;

                        //This is for walking down
                        case PlayerState.WalkDown:
                            //Checks to see if he stopped moving down
                            if (!kb.IsKeyDown(Keys.Down))
                            {
                                pState = PlayerState.FaceDown;
                            }
                            //If he moves left and down
                            else if (kb.IsKeyDown(Keys.Left)){
                                pState = PlayerState.WalkLeftDown;
                            }
                            //If he moves right and down
                            else if (kb.IsKeyDown(Keys.Right)){
                                pState = PlayerState.WalkRightDown;
                            }
                            MovePlayer(0, 2);
                            break;

                        //This is for walking right
                        case PlayerState.WalkRight:
                            //Checks to see if he stopped moving right
                            if (!kb.IsKeyDown(Keys.Right))
                            {
                                pState = PlayerState.FaceRight;
                            }
                            //If he moves right and up
                            else if (kb.IsKeyDown(Keys.Up)){
                                pState = PlayerState.WalkRightUp;
                            }
                            //If he moves right and down
                            else if (kb.IsKeyDown(Keys.Down)){
                                pState = PlayerState.WalkRightDown;
                            }
                            MovePlayer(2, 0);
                            break;

                        //This is for walking left
                        case PlayerState.WalkLeft:
                            //Checks to see if he stopped moving left
                            if (!kb.IsKeyDown(Keys.Left))
                            {
                                pState = PlayerState.FaceLeft;
                            }
                            //If he moves left and up
                            else if (kb.IsKeyDown(Keys.Up)){
                                pState = PlayerState.WalkLeftUp;
                            }
                            //If he moves left and down
                            else if (kb.IsKeyDown(Keys.Down)){
                                pState = PlayerState.WalkLeftDown;
                            }
                            MovePlayer(-2, 0);
                            break;

                        //This is for walking right up
                        case PlayerState.WalkRightUp:
                            //Checks to see if he stopped moving right
                            if (!kb.IsKeyDown(Keys.Right))
                            {
                                pState = PlayerState.WalkUp;
                            }
                            //Checks to see if he stopped moving up
                            else if (!kb.IsKeyDown(Keys.Up))
                            {
                                pState = PlayerState.WalkRight;
                            }
                            MovePlayer(2, -2);
                            break;

                        //This is for walking left up
                        case PlayerState.WalkLeftUp:
                            //Checks to see if he stopped moving left
                            if (!kb.IsKeyDown(Keys.Left))
                            {
                                pState = PlayerState.WalkUp;
                            }
                            //Checks to see if he stopped moving up
                            else if (!kb.IsKeyDown(Keys.Up))
                            {
                                pState = PlayerState.WalkLeft;
                            }
                            MovePlayer(-2, -2);
                            break;

                        //This is for walking right down
                        case PlayerState.WalkRightDown:
                            //Checks to see if he stopped moving right
                            if (!kb.IsKeyDown(Keys.Right))
                            {
                                pState = PlayerState.WalkDown;
                            }
                            //Checks to see if he stopped moving down
                            else if (!kb.IsKeyDown(Keys.Down))
                            {
                                pState = PlayerState.WalkRight;
                            }
                            MovePlayer(2, 2);
                            break;

                        //This is for walking left down
                        case PlayerState.WalkLeftDown:
                            //Checks to see if he stopped moving left
                            if (!kb.IsKeyDown(Keys.Left))
                            {
                                pState = PlayerState.WalkDown;
                            }
                            //Checks to see if he stopped moving down
                            else if (!kb.IsKeyDown(Keys.Down))
                            {
                                pState = PlayerState.WalkLeft;
                            }
                            MovePlayer(-2, 2);
                            break;
                    }

                    //Checks each slugma for collision with teh player
                    for(int i = 0; i < collectibles.Count; i++)
                    {
                        if (collectibles[i].CheckCollision(player))
                        {
                            collectibles[i].Active = false;
                            player.LevelScore++;
                            player.TotalScore++;
                        }
                    }

                    //Checks to see if you lose
                    if(timer <= 0 && player.LevelScore < collectibles.Count/2)
                    {
                        gState = GameState.GameOver;
                    }
                    //Checks to see if you move on to the next level
                    else if(timer <= 0)
                    {
                        NextLevel();
                    }
                    

                    break;

                //This is for game overs
                case GameState.GameOver:
                    if (SingleKeyPress(Keys.Enter))
                    {
                        gState = GameState.Menu;
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
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            switch(gState)
            {
                //Draws the menu
                case GameState.Menu:
                    spriteBatch.DrawString(arial36, "SLUGMA COLLECTOR", new Vector2(125, 50), Color.Black);
                    spriteBatch.DrawString(arial20, "Press ENTER to start the game. \nRun around and collcet all the Slugma's!", new Vector2(50, 125), Color.Black);
                    break;

                //Draws the game
                case GameState.Game:
                    player.Draw(spriteBatch, pState);

                    for(int i = 0; i < collectibles.Count; i++)
                    {
                        collectibles[i].Draw(spriteBatch);
                    }

                    spriteBatch.DrawString(arial20, "Level: " + level, new Vector2(20, 20), Color.Black);
                    spriteBatch.DrawString(arial20, "Level Score: " + player.LevelScore, new Vector2(20, 50), Color.Black);
                    spriteBatch.DrawString(arial20, String.Format("{0:0.00}", timer), new Vector2(20, 80), Color.Black);

                    break;

                //Draws the game over
                case GameState.GameOver:
                    spriteBatch.DrawString(arial36, "GAME OVER", new Vector2(125, 50), Color.Red);
                    spriteBatch.DrawString(arial20, "Total Score: " + player.TotalScore, new Vector2(50, 125), Color.Black);
                    spriteBatch.DrawString(arial20, "You made it to level  " + level, new Vector2(50, 155), Color.Black);
                    spriteBatch.DrawString(arial20, "Press ENTER to restart", new Vector2(50, 185), Color.Black);

                    break;

            }


            spriteBatch.End();


            base.Draw(gameTime);
        }


        /// <summary>
        /// Makes the next level happen
        /// </summary>
        private void NextLevel()
        {
            level = level + 1;
            timer = 12.0;
            player.LevelScore = 0;
            player.X = GraphicsDevice.Viewport.Width / 2;
            player.Y = GraphicsDevice.Viewport.Height / 2;

            collectibles.Clear();

            //For some reason this doesn't always add all of the collectibles it should, because of that I added a buffer to the game over requirments. That way you can still progress if it doesn't draw all the slugma's it should
            for (int i = 0; i <= (3 + level*3); i++)
            {
                collectibles.Add(
                    new Collectible(
                        slugma,
                        ran.Next(
                            0,
                            GraphicsDevice.Viewport.Width - slugma.Width),
                        ran.Next(
                            0,
                            GraphicsDevice.Viewport.Width - slugma.Height)));

            }

        }

        /// <summary>
        /// Resets the game
        /// </summary>
        private void ResetGame()
        {
            level = 0;
            player.TotalScore = 0;
            NextLevel();
        }

        /// <summary>
        /// This moves the player to the other end of the screen
        /// </summary>
        /// <param name="objToWarp">The player</param>
        private void ScreenWrap(GameObject objToWarp)
        {
            if(objToWarp.X + objToWarp.Width >= GraphicsDevice.Viewport.Width)
            {
                objToWarp.X = 0;
            }

            if (objToWarp.Y + objToWarp.Height >= GraphicsDevice.Viewport.Height)
            {
                objToWarp.Y = 0;
            }

            if (objToWarp.X < 0)
            {
                objToWarp.X = GraphicsDevice.Viewport.Width - objToWarp.Width;
            }

            if (objToWarp.Y < 0)
            {
                objToWarp.Y = GraphicsDevice.Viewport.Height - objToWarp.Height;
            }
        }

        /// <summary>
        /// This checks to see if there is only one frame of the key being pressed
        /// </summary>
        /// <param name="key">The key it is checking</param>
        /// <returns>True if the key was pressed for only one frame</returns>
        private bool SingleKeyPress(Keys key)
        {
            if (kb.IsKeyDown(key) && !previousKb.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Moves the player
        /// </summary>
        /// <param name="amountX">The amount the x changes by</param>
        /// <param name="amountY">The amount the y changes by</param>
        public void MovePlayer( int amountX, int amountY)
        {
            player.X = player.X + amountX;
            player.Y = player.Y + amountY;
            ScreenWrap(player);
        }

    }
}
