/* Program name: Pong NEM
Project file name: Ball.cs
Author: Nigel Maynard
Date: 25/9/22
Language: C#
Platform: Microsoft Visual Studio 2022
Purpose: Class work
Description: Assessment game: Pong.
Known Bugs:
Additional Features:
*/

using System;
using System.Drawing;
using System.Media;

namespace Pong_NEM
{
    public class Ball
    {
        // Class Variables
        private const int BALLSIZE = 20;

        private Rectangle formRectangle, scoreBoardRectangle;
        private Brush brush;
        private Score playerScore, cpuScore;
        private Paddle playerPaddle, cpuPaddle;
        private SoundPlayer playerSound = new SoundPlayer(Properties.Resources.fart);
        private Random random;

        private int ballSpeedX, ballSpeedY;
        private bool ballXGoUp = true, ballYGoUp = true, isReset = false;
        private int ballPositionX, ballPositionY;

        // Gets and Sets
        public Brush GetBrush => brush;

        // Returns a random number
        private int GetRandomInt => random.Next(11, 20);

        // Returns the current ball rectangle
        public Rectangle GetBall() => new Rectangle(ballPositionX, ballPositionY, BALLSIZE, BALLSIZE);


        // Class Constructor
        public Ball(Rectangle clientRectangle, Rectangle formRectangle, Rectangle scoreBoardRectangle,
            Score playerScore, Score cpuScore, Paddle playerPaddle, Paddle cpuPaddle, RandomColor randomColor,
            Random random)
        {
            this.formRectangle = formRectangle;
            this.scoreBoardRectangle = scoreBoardRectangle;
            this.playerScore = playerScore;
            this.cpuScore = cpuScore;
            this.playerPaddle = playerPaddle;
            this.cpuPaddle = cpuPaddle;
            this.random = random;

            ballPositionX = clientRectangle.Width / 2;
            ballPositionY = clientRectangle.Height / 2;
            ballSpeedX = GetRandomInt;
            ballSpeedY = GetRandomInt;
            brush = new SolidBrush(randomColor.GetColor());
        }


        // This will call Methods in ball Class to check and move Ball
        public void UpdateBall()
        {
            if (isReset)
            {
                ResetBall();
            }
            else
            {
                MoveBall();
                SideBounce();
            }

            // This Will move the player paddle under the conditions
            if (ballPositionX > formRectangle.Width / 2)
            {
                if (ballPositionY <= cpuPaddle.GetPaddleRectangle.Bottom)
                {
                    cpuPaddle.MoveCpuPaddle(0);
                }
                else
                {
                    cpuPaddle.MoveCpuPaddle(1);
                }
            }
        }

        // This Moves the Ball
        private void MoveBall()
        {
            // X axis
            if (ballXGoUp) ballPositionX += ballSpeedX;
            if (!ballXGoUp) ballPositionX -= ballSpeedX;

            // Y axis
            if (ballYGoUp) ballPositionY += ballSpeedY;
            if (!ballYGoUp) ballPositionY -= ballSpeedY;
        }

        // This will bounce and reassign the ball location for the bounce.
        private void SideBounce()
        {
            // Right side Score and Reset
            if (ballPositionX >= formRectangle.Right - BALLSIZE)
            {
                ballXGoUp = false;
                ballPositionX = formRectangle.Right - BALLSIZE;
                isReset = true;
                playerScore.CurrentScore++;
                playerScore.HasScored = true;
                ballSpeedX = GetRandomInt;

            }

            // Left side Score and Reset
            if (ballPositionX <= formRectangle.Left)
            {
                ballXGoUp = true;
                ballPositionX = formRectangle.Left;
                isReset = true;
                cpuScore.CurrentScore++;
                cpuScore.HasScored = true;
                ballSpeedX = GetRandomInt;
            }


            // Cpu Paddle Bounce
            if (ballPositionX >= cpuPaddle.GetPaddleRectangle.Left - BALLSIZE && ballPositionX <= cpuPaddle.GetPaddleRectangle.Right - BALLSIZE)
            {
                if (ballPositionY >= cpuPaddle.GetPaddleRectangle.Top - BALLSIZE && ballPositionY <= cpuPaddle.GetPaddleRectangle.Bottom - BALLSIZE)
                {
                    ballXGoUp = false;
                    ballPositionX = cpuPaddle.GetPaddleRectangle.Left - BALLSIZE;
                    ballSpeedX = GetRandomInt;
                    Console.Beep(4000, 200);
                }
            }

            // Player Paddle Bounce
            if (ballPositionX <= playerPaddle.GetPaddleRectangle.Right && ballPositionX >= playerPaddle.GetPaddleRectangle.Left)
            {
                if (ballPositionY >= playerPaddle.GetPaddleRectangle.Top && ballPositionY <= playerPaddle.GetPaddleRectangle.Bottom)
                {
                    ballXGoUp = true;
                    ballPositionX = playerPaddle.GetPaddleRectangle.Right;
                    ballSpeedX = GetRandomInt;
                    Console.Beep(4000, 200);
                }
            }


            // Top Bounce
            if (ballPositionY >= formRectangle.Bottom - BALLSIZE)
            {
                ballYGoUp = false;
                ballPositionY = formRectangle.Bottom - BALLSIZE;
                ballSpeedY = GetRandomInt;
                Console.Beep();
            }
            // Bottom Bounce
            if (ballPositionY <= scoreBoardRectangle.Bottom)
            {
                ballYGoUp = true;
                ballPositionY = scoreBoardRectangle.Bottom;
                ballSpeedY = GetRandomInt;
                Console.Beep();
            }
        }

        // This is called to reset the ball position
        public void ResetBall()
        {
            ballPositionX = formRectangle.Width / 2;
            ballPositionY = formRectangle.Height / 2;
            isReset = false;
            playerSound.Play();
        }
    }
}
