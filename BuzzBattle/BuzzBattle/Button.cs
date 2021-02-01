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
    //Matt Cioni
    //Button class for GUI elements

    public enum State
    {
        RollOver,
        NoROllOver
    }
    class Button
    {
        //Fields
        Texture2D noRoll;
        Texture2D roll;
        Rectangle pos;

        State cState;

        private string label;

        //X-Position property
        public int X
        {
            get
            {
                return pos.X;
            }

            set
            {
                pos.X = value; ;
            }
        }

        //Y-Position property
        public int Y
        {
            get
            {
                return pos.Y;
            }

            set
            {
                pos.Y = value;
            }
        }

        //Width property
        public int Width
        {
            get
            {
                return pos.Width;
            }

            set
            {
                pos.Width = value;
            }
        }

        //Height property
        public int Height
        {
            get
            {
                return pos.Height;
            }

            set
            {
                pos.Height = value;
            }
        }

        //Rectangle property
        public Rectangle Pos
        {
            get
            {
                return pos;
            }
        }

        public string Label
        {
            get
            {
                return label;
            }

            set
            {
                label = value;
            }
        }

        /// <summary>
        /// Button constructor
        /// </summary>
        /// <param name="noRoll">Texture to print when button is not rolled over</param>
        /// <param name="roll">Texture to print when button is rolled over</param>
        /// <param name="pos">Rectangle for position and size of button</param>
        public Button(Texture2D noRoll, Texture2D roll, Rectangle pos, string label)
        {
            cState = State.NoROllOver;
            this.noRoll = noRoll;
            this.roll = roll;
            this.pos = pos;
            this.label = label;
        }

        /// <summary>
        /// Checks if the mouse rolls over the button
        /// </summary>
        /// <param name="ms">Mouse State to pass in</param>
        /// <returns>True if rolled over, false if not</returns>
        public void CheckRoll(MouseState ms)
        {
            if (pos.Contains(ms.Position))
            {
                Console.WriteLine("rolled");
                cState = State.RollOver;
            }
            else
            {
                Console.WriteLine("unrolled");
                cState = State.NoROllOver;
            }
        }

        /// <summary>
        /// Checks if the button is pressed
        /// </summary>
        /// <param name="ms">Mouse state</param>
        /// <returns>True if clicked, false if not</returns>
        public bool CheckClick(MouseState ms)
        {
            if(cState == State.RollOver)
            {
                if(ms.LeftButton == ButtonState.Pressed)
                {
                    
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Overridden draw method
        /// </summary>
        /// <param name="sb">SpriteBatch</param>
        /// <param name="texture">Texture to draw</param>
        public void Draw(SpriteBatch sb, SpriteFont font)
        {
            if(cState == State.RollOver)
            {
                //Small Button
                if(this.Width * this.Height < 60000)
                {
                    sb.Draw(roll, pos, Color.White);
                    sb.DrawString(font, " " + label, new Vector2(X + (Width / 2) - 55, Y + (Height / 2) - 45), Color.White);
                }

                //Large Button
                else
                {
                    sb.Draw(roll, pos, Color.White);
                    sb.DrawString(font, " " + label, new Vector2(X + (Width / 2) - 25, Y + (Height / 2) - 60), Color.White);
                }
            }

            else
            {
                if (this.Width * this.Height < 60000)
                {
                    sb.Draw(noRoll, pos, Color.White);
                    sb.DrawString(font, " " + label, new Vector2(X + (Width / 2) - 55, Y + (Height / 2) - 20), Color.Black);
                }

                else
                {
                    sb.Draw(noRoll, pos, Color.White);
                    sb.DrawString(font, " " + label, new Vector2(X + (Width / 2) - 25, Y + (Height / 2) - 20), Color.Black);
                }
                
            }
        }
    }
}
