using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Matt I + Justin, 2/19
namespace BuzzBattle
{
    /// <summary>
    /// This is the parent for everything
    /// </summary>
    abstract class GameObject
    {
        //fields
        protected Rectangle pos; //This contains the location and the size
        protected Texture2D sprite;

        //properties

        /// <summary>
        /// Gets and sets the X position of the object
        /// </summary>
        public int X
        {
            get { return pos.X; }
            set { pos.X = value; }
        }

        /// <summary>
        /// Gets and sets the Y position of the object
        /// </summary>
        public int Y
        {
            get { return pos.Y; }
            set { pos.Y = value; }
        }

        /// <summary>
        /// Gets and sets the width of the object
        /// </summary>
        public int Width
        {
            get { return pos.Width; }
            set { pos.Width = value; }
        }

        /// <summary>
        /// Gets and sets the height of the object
        /// </summary>
        public int Height
        {
            get { return pos.Height; }
            set { pos.Height = value; }
        }

        /// <summary>
        /// Recturns the position rectangle
        /// </summary>
        public Rectangle Pos
        {
            get { return pos; }
        }

        public Texture2D Sprite
        {
            get
            {
                return sprite;
            }

            set
            {
                sprite = value;
            }
        }


        //constructor

        /// <summary>
        /// Creates a Game Object
        /// </summary>
        /// <param name="sprite">The sprite of the object</param>
        /// <param name="position">The position and size of the object</param>
        public GameObject(Texture2D sprite, Rectangle position){
            this.sprite = sprite;
            pos = position;
        }


        //methods

        /// <summary>
        /// Draws the object
        /// </summary>
        /// <param name="sb">The SpriteBatch the object is in</param>
        public abstract void Draw(SpriteBatch sb);
    }
}
