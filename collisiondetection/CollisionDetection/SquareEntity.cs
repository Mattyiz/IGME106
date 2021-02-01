using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Matt Izzo, Collision Detection, This will be where the square stuff takes place
namespace CollisionDetection
{
    class SquareEntity
    {

        private Texture2D image;
        private Rectangle rect;


        public int X
        {
            get { return rect.X; }
            set { rect.X = value; }
        }

        public int Y
        {
            get { return rect.Y; }
            set { rect.Y = value; }
        }

        public int Width
        {
            get { return rect.Width; }
            set { rect.Width = value; }
        }

        public int Height
        {
            get { return rect.Height; }
            set { rect.Height = value; }
        }


        public SquareEntity(Texture2D image, int x, int y)
        {
            this.image = image;
            rect = new Rectangle(x, y, 50, 50);
        }

        public SquareEntity(Texture2D image, int x, int y, int width, int height)
        {
            this.image = image;
            rect = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// This tells whether or not the rectangle intersects with another rectangle
        /// </summary>
        /// <param name="other">The other rectangle</param>
        /// <returns>True if the intersect, false otherwise</returns>
        public bool Intersects (SquareEntity other)
        {
            Rectangle otherRect = new Rectangle(other.X, other.Y, other.Width, other.Height);
            if (rect.Intersects(otherRect))
            {
                return true;
            }
            return false;
        }


        public void Draw(SpriteBatch sb, Color tint)
        {
            sb.Draw(image, rect, tint);
        }

    }
}
