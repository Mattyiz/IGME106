using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Justin Cheng 3/3/20
namespace BuzzBattle
{
    /// <summary>
    /// This is the class that handles the Enemy
    /// methods are moving the enemies and 
    /// </summary>
    class Enemy : GameObject
    {
        //fields 
        private int speed = 2; //speed of the enemy
        private int enemyAttackCD = 30; // Base attack cooldown of enemy

        private Rectangle target; //a variable to make it easier to code
        public int attackCD; //a timer to delay the enemy attacks
        private bool isTouchingBase;
        private Rectangle position;
        private char direction;

        //properties
        public int Speed { get { return speed;} set { speed = value; } }
        public int AttackCD { get { return attackCD;} set { attackCD = value; } }
        public Rectangle Position { get { return position; } }
        public bool IsTouchingBase { get { return isTouchingBase; } }
        public Texture2D Sprite { get { return sprite; } set { sprite = value; } }
        public char Direction { get { return direction; } set { direction = value; } }
        //constructor
        public Enemy(Texture2D sprite, Rectangle position, Rectangle target, char direction) : base(sprite, position)
        {
            attackCD = enemyAttackCD;
            this.target = target;
            isTouchingBase = false;
            this.direction = direction;
            this.sprite = sprite;
        }

        //methods

        /// <summary>
        /// This draws the enemy
        /// </summary>
        /// <param name="sb">The spritebatch that the  is enemy being drawn in</param>
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(sprite, pos, Color.White);
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

        /// <summary>
        /// Moves the enemy closer to the target
        /// uses vector subtraction
        /// </summary>
        public void Move()
        {
            Vector2 vectorEnemy = new Vector2(pos.X, pos.Y); //The "vector" of the enemy posistion
            Vector2 vectorTarget = new Vector2(target.X, target.Y); //The "vector" of the target posiiton
            Vector2 path = vectorTarget - vectorEnemy;
            if (CheckCollison(target))
            {
                isTouchingBase = true;
                attackCD = enemyAttackCD;
            }
            else
            {
                path.Normalize();
                vectorEnemy += path * speed;
                pos.X = (int)vectorEnemy.X;
                pos.Y = (int)vectorEnemy.Y;
            }

            //debugging
            //Console.WriteLine(pos.X+pos.Width + " " + pos.Y);
            //Console.WriteLine(target.X + " " + target.Y);
            //Console.WriteLine(pos.Contains(target));
        }

        // Tries to attack, only succeeds once the attack cooldown reaches zero
        public bool CanAttack()
        {
            if (attackCD < 1)
            {
                attackCD = enemyAttackCD;
                return true;
            }
            else
            {
                attackCD--;
                return false;
            }
        }
    }
}
