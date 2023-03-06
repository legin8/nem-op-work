/* Program name: Pong NEM
Project file name: Paddle.cs
Author: Nigel Maynard
Date: 24/8/22
Language: C#
Platform: Microsoft Visual Studio 2022
Purpose: Class work
Description: Assessment game: Pong.
Known Bugs:
Additional Features:
*/

using System.Drawing;

namespace Pong_NEM
{
    public abstract class Paddle
    {
        // Class Variables
        protected const int PADDLEWIDTH = 20;
        protected Brush brush;
        protected Rectangle formRectangle, scoreBoardRectangle;
        protected int paddlePositionY, paddleWidth, paddleSide;

        // Getter
        public Brush GetBrush => brush;


        // Class Constructor
        public Paddle(Rectangle formRectangle, Rectangle scoreBoardRectangle, RandomColor randomColor)
        {
            this.formRectangle = formRectangle;
            this.scoreBoardRectangle = scoreBoardRectangle;
            paddleWidth = 200;
            paddlePositionY = formRectangle.Bottom / 2;
            brush = new SolidBrush(randomColor.GetColor());
        }


        // Returns the current rectangle
        public Rectangle GetPaddleRectangle => new Rectangle(paddleSide, paddlePositionY, PADDLEWIDTH, paddleWidth);

        // This calls the up and down methods that moves the paddle
        public void MoveCpuPaddle(int upOrDown)
        {
            if (upOrDown == 0) PaddleYUp();
            if (upOrDown == 1) PaddleYDown();
        }

        // This moves paddle up but won't let it go into the score board
        public void PaddleYUp()
        {
            if (paddlePositionY > scoreBoardRectangle.Top) paddlePositionY -= 10;
            if (paddlePositionY < scoreBoardRectangle.Bottom) paddlePositionY = scoreBoardRectangle.Bottom;
        }

        // This moves the paddle down but won't let it go below the screen
        public void PaddleYDown()
        {
            if (paddlePositionY < formRectangle.Bottom - paddleWidth) paddlePositionY += 10;
            if (paddlePositionY > formRectangle.Bottom - paddleWidth) paddlePositionY = formRectangle.Bottom - paddleWidth;
        }
    }
}
