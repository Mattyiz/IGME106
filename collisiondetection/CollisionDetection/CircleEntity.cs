using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Matt Izzo, Collision Detection, This will be where the circle stuff takes place
namespace CollisionDetection
{
    class CircleEntity
    {

        private Texture2D image;
        private Rectangle rect;
        private int radius;


        public int X
        {
            get { return rect.X + radius; }
            set { rect.X = value - radius; }
        }

        public int Y
        {
            get { return rect.Y + radius; }
            set { rect.Y = value - radius; }
        }

        public int Radius
        {
            get { return radius; }
        }


        public CircleEntity(Texture2D image, int x, int y)
        {
            this.image = image;
            rect = new Rectangle(x, y, 50, 50);
            radius = 25;
        }

        public CircleEntity(Texture2D image, int x, int y, int radius)
        {
            this.image = image;
            this.radius = radius;
            rect = new Rectangle(x, y, radius * 2, radius * 2);
        }

        /// <summary>
        /// This tells whether or not the rectangle intersects with another rectangle
        /// </summary>
        /// <param name="other">The other rectangle</param>
        /// <returns>True if the intersect, false otherwise</returns>
        public bool Intersects(CircleEntity other)
        {
            int distance = (this.X - other.X) * (this.X - other.X) + (this.Y - other.Y) * (this.Y - other.Y);
            if (distance <= ((this.Radius + other.Radius) * (this.Radius + other.Radius)))
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
