using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework2
{
    /// <summary>
    /// The SLUGMAS
    /// </summary>
    class Collectible : GameObject
    {

        private bool active;

        /// <summary>
        /// This is about the slugma's activity
        /// </summary>
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        /// <summary>
        /// The slugma's constructor
        /// </summary>
        /// <param name="image">Slugma himself</param>
        /// <param name="x">Slugma's X</param>
        /// <param name="y">Slugma's Y</param>
        public Collectible(Texture2D image, int x, int y) : base(image, x, y)
        {

            active = true;

        }

        /// <summary>
        /// Checks if Slugma is currently colliding with the player
        /// </summary>
        /// <param name="check">The player</param>
        /// <returns>True if they are touching, false otherwise</returns>
        public bool CheckCollision(GameObject check)
        {
            if (active && pos.Intersects(check.Pos))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Draws slugma
        /// </summary>
        /// <param name="sb">The sprite batch</param>
        public override void Draw(SpriteBatch sb)
        {
            if (active)
            {
                base.Draw(sb);
            }
        }

    }
}
