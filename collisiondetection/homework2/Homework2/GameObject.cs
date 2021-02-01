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
    /// This is the parent for the player and the SLUGMAS
    /// </summary>
    class GameObject
    {

        protected Texture2D image;
        protected Rectangle pos;

        /// <summary>
        /// The image
        /// </summary>
        public Texture2D Image
        {
            get { return image; }
        }

        /// <summary>
        /// The rectangle
        /// </summary>
        public Rectangle Pos
        {
            get { return pos; }
        }

        /// <summary>
        /// X coordinate of the rectangle
        /// </summary>
        public int X
        {
            get { return pos.X; }
            set { pos.X = value; }
        }

        /// <summary>
        /// Y coordinate of the rectangle
        /// </summary>
        public int Y
        {
            get { return pos.Y; }
            set { pos.Y = value; }
        }

        /// <summary>
        /// Width of the rectangle
        /// </summary>
        public int Width
        {
            get { return pos.Width; }
            set { pos.Width = value; }
        }

        /// <summary>
        /// Height of the rectangle
        /// </summary>
        public int Height
        {
            get { return pos.Height; }
            set { pos.Height = value; }
        }

        /// <summary>
        /// The game object
        /// </summary>
        /// <param name="image">Game object's image</param>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        public GameObject(Texture2D image, int x, int y)
        {
            this.image = image;
            pos = new Rectangle(x, y, image.Width, image.Height);
        }

        /// <summary>
        /// The draw method
        /// </summary>
        /// <param name="sb">The sprite batch</param>
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(image, pos, Color.White);
        }

    }
}
