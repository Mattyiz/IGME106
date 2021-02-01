using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BuzzBattle
{
    //Last Update By: Matt Cioni
    //Last Update: 2/19/2020
    //FSM Update and Draw Handler

    /// <summary>
    /// Enum for the different Game States
    /// </summary>
    public enum GameState
    {
        Menu,
        Options,
        HighScoreView,
        Instructions,
        GamePlay,
        Pause,
        GameOver,
        HighScoreSet
    }

    class FSMLogic
    {
        //GameState Variable
        private GameState cState; //Current State
        private GameState pState; //Previous State

        //Keyboard State
        private KeyboardState kb;
        private KeyboardState prevKb;

        //Mouse State
        private MouseState ms;
        private MouseState prevMs;

        //For Instruction enum: True = option=from-menu path. False = option-from-game path.
        private bool comeFromMenu;

        //Debug Mode Toggle
        private bool debug;

        //Erin Mode
        private bool erinMode;
        //Object reference
        private Player player;
        private ProjectileManager projectileManager;
        private Hive hive;
        private EnemyManager enemyManager;
        
        private Texture2D roll;
        private Texture2D noRoll;
        

        //Buttons
        //Note: No screen has more than three buttons
        private Button button1;
        private Button button2;
        private Button button3;

        //Background rectangle
        private Rectangle backgroundRect;

        public GameState CState
        {
            get
            {
                return cState;
            }
        }

        public bool ErinMode
        {
            get
            {
                return erinMode;
            }

            set
            {
                erinMode = value;
            }
        }

        /// <summary>
        /// Constructor for the FSM. Always starts at Menu
        /// </summary>
        public FSMLogic(Player player, Hive homeBase, EnemyManager enemyManager, Texture2D roll, Texture2D noRoll)
        {
            cState = GameState.Menu;
            this.player = player;
            projectileManager = player.Projectiles;
            this.hive = homeBase;
            this.enemyManager = enemyManager;
            this.noRoll = noRoll;
            backgroundRect = new Rectangle(0,0, 802, 600);
            button1 = new Button(noRoll, roll, new Rectangle(250, 275, 300, 200), "Play");
            button2 = new Button(noRoll, roll, new Rectangle(50, 350, 225, 150), "Options"); 
            button3 = new Button(noRoll, roll, new Rectangle(550, 350, 225, 150), "HighScores");
            debug = false;
            erinMode = false;
        }

        /// <summary>
        /// Updates the GameState
        /// Mouse functions to be added when Buttons is finished
        /// </summary>
        public void Update()
        {
            kb = Keyboard.GetState();
            ms = Mouse.GetState();

            //Debug toggle
            if(kb.IsKeyDown(Keys.Enter) && debug == false)
            {
                debug = true;
                prevKb = kb;
                Console.WriteLine("Debug on");
            }

            if(debug == true && kb.IsKeyDown(Keys.Enter) && !prevKb.IsKeyDown(Keys.Enter))
            {
                debug = false;
                prevKb = kb;
                Console.WriteLine("Debug off");
            }

            switch(cState)
            {
                #region Menu State
                case (GameState.Menu):
                    #region Debugging Via Keyboard
                    //Keyboard Functions

                    //only Use for debugging
                    if (debug == true)
                    {


                        if (kb.IsKeyDown(Keys.Space) && prevKb.IsKeyDown(Keys.Space) == false)
                        {

                            cState = GameState.Instructions;
                            pState = GameState.Menu;
                            comeFromMenu = true;
                        }

                        if (kb.IsKeyDown(Keys.O) && prevKb.IsKeyDown(Keys.O) == false)
                        {
                            cState = GameState.Options;
                            pState = GameState.Menu;
                            comeFromMenu = true;
                        }

                        if (kb.IsKeyDown(Keys.S) && prevKb.IsKeyDown(Keys.S) == false)
                        {
                            cState = GameState.HighScoreView;
                            pState = GameState.Menu;
                            comeFromMenu = true;
                        }
                    }
                    #endregion
                    //Mouse Functions
                    button1.CheckRoll(ms);
                    button1.CheckClick(ms);
                    button1.Label = "PLAY";
                    button2.CheckClick(ms);
                    button2.CheckRoll(ms);
                    button2.Label = "OPTIONS";
                    button2.X = 50;
                    button2.Y = 350;
                    //button3.CheckClick(ms);
                   // button3.CheckRoll(ms);
                   // button3.Label = "HIGHSCORES";

                    if (button1.CheckClick(ms) == true && prevMs.LeftButton != ButtonState.Pressed)
                    {
                        ResetGame();
                        cState = GameState.Instructions;
                        pState = GameState.Menu;
                        comeFromMenu = true;
                    }

                    if (button2.CheckClick(ms) == true && prevMs.LeftButton != ButtonState.Pressed)
                    {
                        cState = GameState.Options;
                        pState = GameState.Menu;
                        comeFromMenu = true;
                    }

                    //if (button3.CheckClick(ms) == true && prevMs.LeftButton != ButtonState.Pressed)
                    //{
                    //    cState = GameState.HighScoreView;
                    //    pState = GameState.Menu;
                    //    comeFromMenu = true;
                    //}
                    prevMs = ms;
                    break;
                #endregion

                #region Option State
                case (GameState.Options):
                    //Escape Key Functions
                    if (kb.IsKeyDown(Keys.Escape) && prevKb.IsKeyDown(Keys.Escape) == false)
                    {

                        if(comeFromMenu == true)
                        {
                            cState = GameState.Menu;
                            pState = GameState.Options;
                        }
                        else
                        {
                            cState = GameState.Pause;
                            pState = GameState.Options;
                        }

                    }

                    //Will be replaced with mouse Functions
                    if(kb.IsKeyDown(Keys.I) && prevKb.IsKeyDown(Keys.I) == false)
                    {
                        cState = GameState.Instructions;
                        pState = GameState.Options;
                    }
                    //Mouse Functions
                    button1.Label = "BACK";
                    button1.CheckClick(ms);
                    button1.CheckRoll(ms);
                    button2.CheckClick(ms);
                    button2.CheckRoll(ms);
                    if (button1.CheckClick(ms) == true && prevMs.LeftButton != ButtonState.Pressed)
                    {
                        if (comeFromMenu == true)
                        {
                            cState = GameState.Menu;
                            pState = GameState.Options;
                        }
                        else
                        {
                            cState = GameState.Pause;
                            pState = GameState.Options;
                        }

                    }

                    button2.Y = 150;
                    button2.X = button1.X + 50;
                    button2.Label = "Erin Mode";
                    if (button2.CheckClick(ms) == true && prevMs.LeftButton != ButtonState.Pressed)
                    {
                        if(ErinMode == true)
                        {
                            erinMode = false;
                            ResetGame();
                        }
                        else
                        {
                            erinMode = true;
                            ResetGame();
                        }
                        
                    }


                    prevMs = ms;
                    prevKb = kb;
                    break;
                #endregion

                #region HighScoreView State
                case (GameState.HighScoreView):
                    //#region Debugging Via Keyboard
                    ////Keyboard functions
                    //if (debug == true)
                    //{
                    //    if (kb.IsKeyDown(Keys.Escape) && prevKb.IsKeyDown(Keys.Escape) == false)
                    //    {
                    //        cState = GameState.Menu;
                    //        pState = GameState.HighScoreView;

                    //    }
                    //}
                    //#endregion
                    ////Mouse Function
                    //button1.Label = "BACK";
                    //button1.CheckClick(ms);
                    //button1.CheckRoll(ms);
                    //if (button1.CheckClick(ms) == true && prevMs.LeftButton != ButtonState.Pressed)
                    //{
                    //    cState = GameState.Menu;
                    //    pState = GameState.HighScoreView;
                    //}

                    //prevMs = ms;
                    //prevKb = kb;
                    break;
                #endregion

                #region Instrctions State
                case (GameState.Instructions):
                    #region Debugging Via Keyboard
                    //Use for debugging
                    if (debug == true)
                    {


                        if (kb.IsKeyDown(Keys.A) && prevKb.IsKeyDown(Keys.A) == false)
                        {
                            if (pState.Equals(GameState.Options))
                            {
                                cState = GameState.Options;
                                pState = GameState.Instructions;
                            }
                            if (pState.Equals(GameState.Menu))
                            {
                                cState = GameState.GamePlay;
                                pState = GameState.Instructions;
                            }
                        }
                    }
                    #endregion
                    //Mouse Function
                    button1.CheckRoll(ms);
                    button1.CheckClick(ms);
                    button1.Label = "FIGHT!";
                    button1.Y = 330;
                    if (button1.CheckClick(ms) == true && prevMs.LeftButton != ButtonState.Pressed)
                    {
                        if (pState.Equals(GameState.Options))
                        {
                           cState = GameState.Options;
                           pState = GameState.Instructions;
                        }
                        if (pState.Equals(GameState.Menu))
                        {
                          cState = GameState.GamePlay;
                          pState = GameState.Instructions;
                        }
                    }

                    prevKb = kb;
                    prevMs = ms;
                    break;
                #endregion

                #region GamePlay State
                case (GameState.GamePlay):
                    #region Debugging Via Keyboard

                    
                        //KeyBoard Function
                        if (kb.IsKeyDown(Keys.Escape) && prevKb.IsKeyDown(Keys.Escape) == false)
                        {
                            cState = GameState.Pause;
                            pState = GameState.GamePlay;
                        }

                        if (kb.IsKeyDown(Keys.P) && prevKb.IsKeyDown(Keys.P) == false)
                        {
                            cState = GameState.GameOver;
                            pState = GameState.GamePlay;
                        }

                    #endregion
                    comeFromMenu = false;
                    button1.Y = 275;
                    if(ErinMode == false)
                    {
                        if (hive.Health <= 0)
                        {
                            cState = GameState.GameOver;

                        }
                        pState = GameState.GamePlay;
                    }
                    else
                    {
                        hive.Health = hive.MaxHealth;
                    }
                    prevMs = ms;
                    prevKb = kb;
                    break;
                #endregion

                #region Pause State
                case (GameState.Pause):
                    //Keyboard Functions
                    #region Debugging Via Keyboard
                    //if (kb.IsKeyDown(Keys.B) && prevKb.IsKeyDown(Keys.B) == false)
                    //{
                    //    cState = GameState.GamePlay;
                    //    pState = GameState.Pause;
                    //    comeFromMenu = false;
                    //}

                    //if(kb.IsKeyDown(Keys.O) && prevKb.IsKeyDown(Keys.O) == false)
                    //{
                    //    cState = GameState.Options;
                    //    pState = GameState.Pause;
                    //    comeFromMenu = false;
                    //}
                    #endregion

                    button1.CheckRoll(ms);
                    button1.CheckClick(ms);
                    button1.Label = "RESUME";
                    button2.CheckClick(ms);
                    button2.CheckRoll(ms);
                    button2.Label = "OPTIONS";
                    button2.X = 50;
                    button2.Y = 350;
                    button3.CheckClick(ms);
                    button3.CheckRoll(ms);
                    button3.Label = "QUIT";
                    
                    //Mouse Functions
                    
                        // If "QUIT" button is clicked:
                    if (button3.CheckClick(ms) == true && prevMs.LeftButton != ButtonState.Pressed)
                    {
                        
                        cState = GameState.Menu;
                        pState = GameState.Pause;
                        ResetGame();
                    }

                    // If "OPTIONS" button is clicked:
                    if (button2.CheckClick(ms) == true && prevMs.LeftButton != ButtonState.Pressed)
                    {
                        cState = GameState.Options;
                        pState = GameState.Pause;
                        
                    }

                    // If "RESUME" button is clicked:
                    if (button1.CheckClick(ms) == true && prevMs.LeftButton != ButtonState.Pressed)
                    {
                        cState = GameState.GamePlay;
                        pState = GameState.Pause;
                        
                    }

                    prevMs = ms;
                    prevKb = kb;
                    break;
                #endregion

                #region GameOver State
                case (GameState.GameOver):
                    #region Debugging Via Keyboard
                    if (debug == true)
                    {
                        ////Keyboard functions
                        if (kb.IsKeyDown(Keys.Space) && prevKb.IsKeyDown(Keys.Space) == false)
                        {
                            cState = GameState.Menu;
                            pState = GameState.GameOver;
                        }
                    }
                    #endregion

                    //Mouse Functions
                    button1.CheckRoll(ms);
                    button1.CheckClick(ms);
                    button1.Label = "CONTINUE";
                    if (button1.CheckClick(ms) == true && prevMs.LeftButton != ButtonState.Pressed)
                    {
                        cState = GameState.Menu;
                        pState = GameState.GameOver;
                        comeFromMenu = false;
                    }

                    prevMs = ms;
                    prevKb = kb;
                    break;
                #endregion

                #region HighScoreSet State
                case (GameState.HighScoreSet):
                    //Mouse Functions
                    //
                    //
                    //
                    //
                    pState = GameState.HighScoreSet;
                    break;
                    #endregion
            }
        }

        public void Draw(SpriteBatch sb, SpriteFont arial14, Texture2D background, SpriteFont gill24)
        {
            sb.Draw(background, backgroundRect, Color.White);
            if(ErinMode == true)
            {
                sb.DrawString(arial14, "Erin Mode Enabled", new Vector2(25, 25), Color.Black);
            }
            switch (cState)
            {
                #region Menu Draw State
                case (GameState.Menu):
                    if (debug == true)
                    {
                        sb.DrawString(arial14, "MENU", new Vector2(50, 50), Color.White);
                        sb.DrawString(arial14, "Press 'Space' to start", new Vector2(50, 75), Color.White);
                        sb.DrawString(arial14, "Press 'O' to go to options", new Vector2(50, 100), Color.White);
                        sb.DrawString(arial14, "Press 'S' to go to see the scores", new Vector2(50, 125), Color.White);
                    }

                    button1.Draw(sb, arial14);
                    button2.Draw(sb, arial14);
                   // button3.Draw(sb, arial14);

                    break;
                #endregion

                #region Options Draw State
                case (GameState.Options):
                    if (debug == true)
                    {
                        sb.DrawString(arial14, "Options", new Vector2(50, 50), Color.White);
                        sb.DrawString(arial14, "Press 'Esc' to go back", new Vector2(50, 75), Color.White);
                        sb.DrawString(arial14, "Press 'I' to go to Instructions", new Vector2(50, 100), Color.White);
                    }
                    button1.Draw(sb, arial14);
                    button2.Draw(sb, arial14);
                    sb.DrawString(gill24, "OPTIONS", new Vector2(225, 50), Color.Black);
                    break;
                #endregion

                #region HighScoreView Draw State
                case (GameState.HighScoreView):
                    //button1.Draw(sb, arial14);
                    //if (debug == true)
                    //{
                    //    sb.DrawString(arial14, "HighScores", new Vector2(50, 50), Color.White);
                    //    sb.DrawString(arial14, "Press 'Esc' to go back", new Vector2(50, 75), Color.White);
                    //}
                    //sb.DrawString(gill24, "High Scores", new Vector2(200, 50), Color.Black);
                    //break;
                #endregion

                #region Instructions Draw State
                case (GameState.Instructions):
                    if (debug == true)
                    {
                        sb.DrawString(arial14, "Instructions", new Vector2(50, 50), Color.White);
                        sb.DrawString(arial14, "Press 'A' to continue", new Vector2(50, 75), Color.White);
                    }
                    button1.Draw(sb, arial14);
                    break;
                #endregion

                #region GamePlay Draw State
                case (GameState.GamePlay):
                    if (debug == true)
                    {
                        sb.DrawString(arial14, "YOU ARE IN GAME", new Vector2(50, 50), Color.White);
                        sb.DrawString(arial14, "Press 'Esc' to pause", new Vector2(50, 75), Color.White);
                        sb.DrawString(arial14, "Press 'P' to go to Game Over", new Vector2(50, 100), Color.White);
                    }

                    if (ErinMode == true)
                    {
                        sb.DrawString(arial14, "Erin Mode Enabled", new Vector2(25, 25), Color.White);
                    }
                    //sb.DrawString(arial14, " " + homeBase.Health, new Vector2(300, 300), Color.Black);
                    break;
                #endregion

                #region Pause Draw State
                case (GameState.Pause):
                    if (debug == true)
                    {
                        sb.DrawString(arial14, "Pause", new Vector2(50, 50), Color.White);
                        sb.DrawString(arial14, "Press 'B' to go back", new Vector2(50, 75), Color.White);
                        sb.DrawString(arial14, "Press 'O' to go to options", new Vector2(50, 100), Color.White);
                    }
                    sb.DrawString(gill24, "PAUSE", new Vector2(270, 50), Color.Black);
                    button1.Draw(sb, arial14);
                    button2.Draw(sb, arial14);
                    button3.Draw(sb, arial14);
                    break;
                #endregion

                #region GameOver Draw State
                case (GameState.GameOver):
                    
                    if (debug == true)
                    {
                        sb.DrawString(arial14, "Game Over", new Vector2(50, 50), Color.White);
                        sb.DrawString(arial14, "Press 'Space' to continue", new Vector2(50, 75), Color.White);
                    }
                    sb.DrawString(gill24, "GAME OVER", new Vector2(170, 50), Color.Black);
                    sb.DrawString(gill24, "FINAL SCORE: " + player.Score, new Vector2(100, 150), Color.Black);

                    button1.Draw(sb, arial14);
                    break;
                #endregion

                #region HighScoreSet Draw State
                case (GameState.HighScoreSet):
                    break;
                    #endregion
            }
        }

        /// <summary>
        /// Resets the game
        /// </summary>
        public void ResetGame()
        {
            // Reset everything involving the player
            player.Health = player.MaxHealth;
            player.Score = 0;
            player.X = player.InitialPos.X;
            player.Y = player.InitialPos.Y;

            // Reset everything involving the projectiles

            projectileManager.Reset();
            /*
            for(int i = 0; i < player.Projectiles.Count; i++)
            {
                player.Projectiles[i] = null;
            }
            */

            // Reset everything invloving the enemies
            enemyManager.Reset();

            // Reset everything involving the home base
            hive.Reset();
        }
    }
}
