using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Matt I, 2/23, 3/1, 3/4
namespace BuzzBattle
{
    /// <summary>
    /// This is the class for the projectile the player shoots
    /// </summary>
    class Projectile: GameObject
    {

        // ========== FIELDS ==========

        private int projectileSpeed = 15;

        private int maxMoveCount = 30;

        private double xPosition;
        private double yPosition;

        private double xVelocity;
        private double yVelocity;

        private double angle;

        private int moveCount;

        private Player player;

        private Enemy enemy;
        // ========== PROPERTIES ==========

        public double Angle
        {
            get
            {
                return angle;
            }
        }

        public bool CanMove
        {
            get
            {
                if (moveCount < maxMoveCount)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        // ========== CONSTRUCTOR ==========

        /// <summary>
        /// The constructor for the player's projectile
        /// </summary>
        /// <param name="sprite">The sprite of the projectile</param>
        /// <param name="position">The position of the projectile</param>
        public Projectile(Texture2D sprite, Rectangle playerLocation, MouseState mouseLocation) : base(sprite, new Rectangle(playerLocation.X, playerLocation.Y, playerLocation.Width/3, playerLocation.Height/3))
        {
            xPosition = playerLocation.X;
            yPosition = playerLocation.Y;

            int mX = mouseLocation.X;
            int mY = mouseLocation.Y;

            double xDistance = mX - xPosition;
            double yDistance = mY - yPosition;

            angle = Math.Atan2(yDistance, xDistance);

            xVelocity = projectileSpeed * Math.Cos(angle);
            yVelocity = projectileSpeed * Math.Sin(angle);

            moveCount = 0;
        }



        // =========== METHODS ===========


        /// <summary>
        /// This draws the projectile
        /// </summary>
        /// <param name="sb">This is the sprite batch it is drawn in</param>
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(sprite, pos, Color.White);
        }

        /// <summary>
        /// This moves the projectile towards the destination
        /// </summary>
        public void Move()
        {
            xPosition += xVelocity;
            yPosition += yVelocity;

            pos.X = (int)Math.Round(xPosition);
            pos.Y = (int)Math.Round(yPosition);

            moveCount++;
        }

        
        /*
        public bool CanMove(Rectangle rectangle)
        {
            if (moveCount > 20)
            {
                return false;
            }

            if (CollidesWith(rectangle))
            {
                return false;
            }

            return true;
        }*/

        /// <summary>
        /// This method will check if the player is colliding with another object
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public bool CollidesWith(Rectangle rectangle)
        {
            //This is for if both objects are going to be rectangles.
            //When I wrote the collisions I wasn't sure the shapes so I wrote both just to be safe :)

            /*if(pos.Intersects(rectangle))
            {
                return true;
            }else
            {
                return false;
            }*/

            //This is for if both of them are circles

            int distance = (this.X - rectangle.X) * (this.X - rectangle.X) + (this.Y - rectangle.Y) * (this.Y - rectangle.Y);
            if (distance <= ((this.Width / 2 + rectangle.Width / 2) * (this.Width / 2 + rectangle.Width / 2)))
            {
                //Attempt at a scoring system
                //if(rectangle == enemy.Pos)
                //{
                //    player.Score += 10;
                //}
                
                return true;
            }
            return false;

        }

    }
}
