using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


//Matt I, 2/19, 2/23, 3/1, 3/4
namespace BuzzBattle
{
    /// <summary>
    /// This is the class that handles the player
    /// </summary>
    class Player : GameObject
    {

        //fields
        private int health;
        private int maxHealth;
        public ProjectileManager projectiles;
        private int score;
        private Rectangle initialPos;
        private Texture2D projectileSprite;
        private Hive hive;

        private int playerSpeed = 4;

        private int maxX;
        private int maxY;

        //The following are for adding collisions with enemies

        private EnemyManager enemies;

        //Invinisbility frames for enemy damaging this. Collisions will be added once enemies are implmented
        private int iFrames;


        //Matt Cioni Added Stuff Here
        private KeyboardState kbVert;
        private KeyboardState kbHorz;

        //properties

        /// <summary>
        /// This is the health of the player
        /// </summary>
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Score
        {
            get { return projectiles.Score; }
            set { 
                score = value;
                projectiles.Score = value;
            }
        }

        public ProjectileManager Projectiles
        {
            get { return projectiles; }
        }

        public int MaxHealth
        { 
            get { return maxHealth; }
        }

        public Rectangle InitialPos
        {
            get { return initialPos; }
        }

        public int MaxX
        {
            get { return maxX; }
            set { maxX = value; }
        }

        public int MaxY
        {
            get { return maxY; }
            set { maxY = value; }
        }

        //Matt CIoni Added Stuff Here
        public KeyboardState KbVert
        { 
            get
            {
                return kbVert;
            }
            set
            {
                kbVert = value;
            }
        }

        public KeyboardState KbHorz
        {
            get
            {
                return kbHorz;
            }
            set
            {
                kbHorz = value;
            }
        }
        //constructor

        /// <summary>
        /// The constructor for the player class
        /// </summary>
        /// <param name="sprite">The sprite of the player</param>
        /// <param name="position">The location and size of the player</param>
        /// <param name="projectileSprite">The sprite of the projectile</param>
        public Player(Texture2D sprite, Rectangle position, Texture2D projectileSprite, Hive hive, EnemyManager enemyManager) :base(sprite, position)
        {
            //arbitrarily assigned number
            health = 100;

            maxX = 0;
            maxY = 0;

            projectiles = new ProjectileManager(hive, enemyManager);

            this.projectileSprite = projectileSprite;

            this.hive = hive;

            score = 0;
        }

        //methods

        /// <summary>
        /// This draws the player
        /// </summary>
        /// <param name="sb">The spritebatch that the player is being drawn in</param>
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(sprite, pos, Color.White);
        }


        /// <summary>
        /// This will handle all of the keyboard inputs for the player
        /// </summary>
        /// <param name="kb">The keyboard state</param>
        public void KeyBoardInput(KeyboardState kb, KeyboardState previousKb, MouseState ms, MouseState previousMs)
        {
            //This method will have to be basically completly rewritten when we actually have to add in animations, but it works for now
            //The speed of the player (2) was arbitrarily chosen and will likely need to be updated

            //Matt C made edits 5/4/2020

            //This is for horizontal movement
            if (kb.IsKeyDown(Keys.A))
            {
                KbHorz = kb;
                KbVert = previousKb;
                if(pos.X > 0 )
                {
                    Move(-playerSpeed, 0);
               }
            }
            else if (kb.IsKeyDown(Keys.D))
            {
                KbHorz = kb;
                KbVert = previousKb;
                if (pos.X < maxX - pos.Width)
                {
                    Move(playerSpeed, 0);
                }
            }

            //This is for vertical movement
            if (kb.IsKeyDown(Keys.W))
            {
                KbVert = kb;
                KbHorz = previousKb;
                if (pos.Y > 0)
                {
                    Move(0, -playerSpeed);
                }
            }
            else if (kb.IsKeyDown(Keys.S))
            {
                KbVert = kb;
                KbHorz = previousKb;
                if (pos.Y < maxY - pos.Height)
                {
                    Move(0, playerSpeed);
                }
            }



            // Allows the player to shoot with the left and right mouse buttons and the space
            if (ms.LeftButton == ButtonState.Pressed || ms.RightButton == ButtonState.Pressed || kb.IsKeyDown(Keys.Space))
            {
                if (previousMs.LeftButton != ButtonState.Pressed && previousMs.RightButton != ButtonState.Pressed && previousKb.IsKeyUp(Keys.Space))
                {
                    Attack();
                }
            }
        }

        /// <summary>
        /// This method will check if the player is colliding with another object
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public bool CollidesWith(Rectangle rectangle)
        {
            //This is for if both objects are going to be rectangles.
            //When I wrote the collisions I wasn't sure the shapes so I wrote both just to be safe :)

            /*
            if(pos.Intersects(rectangle))
            {
                return true;
            }else
            {
                return false;
            }
            */

            //This is for if both of them are circles

            int distance = (this.X - rectangle.X) * (this.X - rectangle.X) + (this.Y - rectangle.Y) * (this.Y - rectangle.Y);
            if (distance <= ((this.Width/2 + rectangle.Width/2) * (this.Width/2 + rectangle.Width/2)))
            {
                return true;
            }
            return false;
            
        }

        /// <summary>
        /// Moves the player
        /// </summary>
        /// <param name="x">Horizontal movement</param>
        /// <param name="y">Vertical movement</param>
        public void Move(int x, int y)
        {
            X += x;
            Y += y;

            //This checks if the new position collides with the base
            if (CollidesWith(hive.Pos))
            {
                Move(-x, -y);
            }
        }


        /// <summary>
        /// This is an incomplete method, but it will be for the projectile spawning.
        /// </summary>
        public void Attack()
        {
            projectiles.Add(new Projectile(projectileSprite, pos, Mouse.GetState()));
        }


        public void Reset()
        {
            Health = MaxHealth;
            Score = 0;
            X = InitialPos.X;
            Y = InitialPos.Y;
        }
    }
}
