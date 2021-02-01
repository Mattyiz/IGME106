using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Homework2
{
    class Player : GameObject
    {

        private int levelScore;
        private int totalScore;


        //These are for drawing the character
        private int frame;
        private double timeCounter;
        private double fps;
        private double timePerFrame;

        private const int WalkFrameCount = 2;
        private const int RectOffsetY = 0;
        private const int RectHeight = 35;
        private const int RectWidth = 35;

        private PlayerState pState;

        /// <summary>
        /// The level's score
        /// </summary>
        public int LevelScore
        {
            get { return levelScore; }
            set { levelScore = value; }
        }

        /// <summary>
        /// The total score
        /// </summary>
        public int TotalScore
        {
            get { return totalScore; }
            set { totalScore = value; }
        }

        /// <summary>
        /// The player's constructor
        /// </summary>
        /// <param name="image">The player</param>
        /// <param name="x">Their X</param>
        /// <param name="y">Theiy Y</param>
        public Player(Texture2D image, int x, int y) :base(image, x, y)
        {
            levelScore = 0;
            totalScore = 0;

            fps = 10.0;
            timePerFrame = 2.0 / fps;

            Width = RectWidth;
            Height = RectHeight;
        }

        /// <summary>
        /// The Draw method
        /// </summary>
        /// <param name="sb">The sprite batch</param>
        /// <param name="pState">The player's direction</param>
        public void Draw(SpriteBatch sb, PlayerState pState)
        {

            //So this really ugly switch statement will just decide whether or not the player is walking or standing.
            switch (pState)
            {
                //Facing down
                case PlayerState.FaceDown:
                    DrawStanding(sb, 0);
                    break;

                //Facing up
                case PlayerState.FaceUp:
                    DrawStanding(sb, 6);
                    break;

                //Facing right
                case PlayerState.FaceRight:
                    DrawStanding(sb, 3);
                    break;

                //Facing left
                case PlayerState.FaceLeft:
                    DrawStanding(sb, 9);
                    break;

                //Walking up
                case PlayerState.WalkUp:
                    DrawWalking(sb, 6);
                    break;

                //Walking down
                case PlayerState.WalkDown:
                    DrawWalking(sb, 0);
                    break;

                //Walking right
                case PlayerState.WalkRight:
                    DrawWalking(sb, 3);
                    break;

                //Walking left
                case PlayerState.WalkLeft:
                    DrawWalking(sb, 9);
                    break;

                //Walking left up
                case PlayerState.WalkLeftUp:
                    DrawWalking(sb, 6);
                    break;

                //Walking left down
                case PlayerState.WalkLeftDown:
                    DrawWalking(sb, 0);
                    break;

                //Walking right
                case PlayerState.WalkRightUp:
                    DrawWalking(sb, 6);
                    break;

                //Walking left
                case PlayerState.WalkRightDown:
                    DrawWalking(sb, 0);
                    break;
            }
        }

        /// <summary>
        /// Updating the walking animation
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public void UpdateAnimation(GameTime gameTime)
        {
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeCounter >= timePerFrame)
            {
                frame += 1;

                if (frame > WalkFrameCount)
                    frame = 1;

                timeCounter -= timePerFrame;
            }
        }

        /// <summary>
        /// Draws the standing sprite
        /// </summary>
        /// <param name="sb">Sprite batch</param>
        /// <param name="direction">The direction they face</param>
        private void DrawStanding(SpriteBatch sb, int direction)
        {
            sb.Draw(
                image,
                new Vector2(X, Y),
                new Rectangle(
                    direction * RectWidth,
                    RectOffsetY,
                    RectWidth,
                    RectHeight),
                Color.White,
                0,
                Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0);
        }

        /// <summary>
        /// Draws the walking animation
        /// </summary>
        /// <param name="sb">The sprite batch</param>
        /// <param name="direction">The direction they're facing</param>
        private void DrawWalking(SpriteBatch sb, int direction)
        {
            sb.Draw(
                image,
                new Vector2(X, Y),
                new Rectangle(
                    (direction + frame) * RectWidth,
                    RectOffsetY,
                    RectWidth,
                    RectHeight),
                Color.White,
                0,
                Vector2.Zero,
                1.0f,
                SpriteEffects.None,
                0);
        }

    }
}
