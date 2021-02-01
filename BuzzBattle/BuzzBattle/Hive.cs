using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Justin Cheng 3/3/2020

namespace BuzzBattle
{
    /// <summary>
    /// The class for the hive/homebase.
    /// NOT A BASE CLASS BUT A CLASS FOR THE BASE
    /// </summary>
    class Hive : GameObject
    {
        //fields
        private int health;
        private int maxHealth;
        private int prevHealth;

        //properties
        public int Health { get { return health; } set { health = value; } }
        public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
        public int PrevHealth { get { return prevHealth; } set { prevHealth = value; } }

        //constructor
        public Hive(Texture2D sprite, Rectangle position, int maxHealth) : base(sprite, position)
        {
            this.maxHealth = maxHealth;
            health = this.maxHealth;
            prevHealth = health;
        }

        //methods

        /// <summary>
        /// This draws the homebase
        /// </summary>
        /// <param name="sb">The spritebatch that the base is being drawn in</param>
        public override void Draw(SpriteBatch sb)
        {
            if (prevHealth > health)
            {
                sb.Draw(sprite, pos, Color.Red);
            }
            else
            {
                sb.Draw(sprite, pos, Color.White);
            }
        }

        /// <summary>
        /// Checks if the enemy has collided with another object. Must give in the rectangle component of other object
        /// </summary>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public bool CheckCollison(Rectangle rectangle)
        {
            int distance = (this.X - rectangle.X) * (this.X - rectangle.X) + (this.Y - rectangle.Y) * (this.Y - rectangle.Y);
            if (distance <= ((this.Width / 2 + rectangle.Width / 2) * (this.Width / 2 + rectangle.Width / 2)))
            {
                return true;
            }
            return false;
        }

        /*
        public void TakeDamage(Enemy enemy)
        {
            if (enemy.CheckCollison(pos))
            {
                if (health > 0)
                {
                    if (enemy.CanAttack())
                    {
                        health -= 10;
                    }
                }
            }
        }*/

        public void Reset()
        {
            health = this.maxHealth;
        }
    }
}
