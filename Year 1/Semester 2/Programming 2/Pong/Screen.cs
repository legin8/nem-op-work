/* Program name: Pong NEM
Project file name: Screen.cs
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
using System.Windows.Forms;

namespace Pong_NEM
{
    public class Screen
    {
        // Class Variables
        private Graphics bufferGraphics;
        private Ball ball;
        private Paddle playerPaddle, cpuPaddle;
        private Score playerScore, cpuScore;
        private ScoreBoard scoreBoard;
        private Menu menu;
        private Controller controller;
        private Rectangle formRectangle;
        private HighScore highScore;
        private int pauseTimer;
        private bool pauseTimerDone, isEndOfGame;
        private string winnerName;


        // Class Constructor
        public Screen(Graphics bufferGraphics, Ball ball, Paddle playerPaddle, Paddle cpuPaddle, Score playerScore, Score cpuScore,
            ScoreBoard scoreBoard, Rectangle formRectangle, Menu menu, Controller controller, HighScore highScore)
        {
            this.bufferGraphics = bufferGraphics;
            this.ball = ball;
            this.playerPaddle = playerPaddle;
            this.cpuPaddle = cpuPaddle;
            this.playerScore = playerScore;
            this.cpuScore = cpuScore;
            this.scoreBoard = scoreBoard;
            this.formRectangle = formRectangle;
            this.menu = menu;
            this.controller = controller;
            this.highScore = highScore;
            pauseTimer = 0;
            pauseTimerDone = true;
            isEndOfGame = false;
        }


        // Calls everything to be put on Screen during a match
        public void DisplayScreen(bool isPaused)
        {
            if (playerScore.GetScore == controller.GetENDGAMECONDITION || cpuScore.GetScore == controller.GetENDGAMECONDITION && pauseTimerDone) isEndOfGame = true;
            if (!isEndOfGame && !isPaused) playRound();
            if (!isEndOfGame && isPaused) menuScreen();
            if (isEndOfGame) winnerOfGame();
        }

        // displays and runs the game
        private void playRound()
        {
            // This is only run when we want the ball to move
            if (!playerScore.HasScored && !cpuScore.HasScored) ball.UpdateBall();

            bufferGraphics.Clear(Control.DefaultBackColor);

            // Ball
            bufferGraphics.FillEllipse(ball.GetBrush, ball.GetBall());
            // Score Board
            bufferGraphics.FillRectangle(scoreBoard.GetScoreBoardBrush, scoreBoard.GetScoreBoardRectangle);
            // Names and scores on Score Board
            bufferGraphics.DrawString(playerScore.GetName, playerScore.GetFont, Brushes.Black, new Point(playerScore.GetNameXPosition, playerScore.GetNameOfYPosition)); // player name
            bufferGraphics.DrawString(playerScore.CurrentScore.ToString(), playerScore.GetFont, Brushes.Black, new Point(playerScore.GetNameXPosition, playerScore.GetScoreOfYPosition)); // player score
            bufferGraphics.DrawString(cpuScore.GetName, cpuScore.GetFont, Brushes.Black, new Point(cpuScore.GetNameXPosition, cpuScore.GetNameOfYPosition)); // cpu name
            bufferGraphics.DrawString(cpuScore.CurrentScore.ToString(), cpuScore.GetFont, Brushes.Black, new Point(cpuScore.GetNameXPosition, cpuScore.GetScoreOfYPosition)); // cpu score
            bufferGraphics.DrawString(menu.GetMenuText, menu.GetFontMainScreen, Brushes.Black, formRectangle.Width / 3, formRectangle.Height / 16); // menu
            // Paddles
            bufferGraphics.FillRectangle(playerPaddle.GetBrush, playerPaddle.GetPaddleRectangle); // Player Paddle
            bufferGraphics.FillRectangle(cpuPaddle.GetBrush, cpuPaddle.GetPaddleRectangle); // Cpu Paddle

            pausesScreenScore();
        }

        // This pauses the game once a point is scored
        private void pausesScreenScore()
        {
            if (playerScore.HasScored || cpuScore.HasScored)
            {
                if (playerScore.HasScored) bufferGraphics.DrawString($"{pauseTimer}1 point to {playerScore.GetName}", playerScore.GetFont, Brushes.Black, formRectangle.Width / 2, formRectangle.Height / 2);
                if (cpuScore.HasScored) bufferGraphics.DrawString($"{pauseTimer}1 point to {cpuScore.GetName}", playerScore.GetFont, Brushes.Black, formRectangle.Width / 2, formRectangle.Height / 2);
                pauseTimer++;
                pauseTimerDone = false;

                if (pauseTimer > 20)
                {
                    playerScore.HasScored = false;
                    cpuScore.HasScored = false;
                    pauseTimer = 0;
                    pauseTimerDone = true;
                }
            }
        }

        // Displays the winner of the Game
        private void winnerOfGame()
        {
            if (playerScore.GetScore == controller.GetENDGAMECONDITION) winnerName = playerScore.GetName;
            if (cpuScore.GetScore == controller.GetENDGAMECONDITION) winnerName = cpuScore.GetName;

            bufferGraphics.Clear(Control.DefaultBackColor);
            bufferGraphics.DrawString($"Winner is {winnerName}.", cpuScore.GetFont, Brushes.Black, new Point(formRectangle.Width / 3, formRectangle.Height / 2));
            pauseTimer++;

            if (pauseTimer > 20)
            {
                pauseTimer = 0;
                controller.IsPlayHighScore = true;
            }
        }

        // Displays the menu screen
        private void menuScreen()
        {
            bufferGraphics.Clear(Control.DefaultBackColor);
            bufferGraphics.DrawString(menu.GetResumeText, menu.GetFontMenuScreen, Brushes.Black, formRectangle.Width / 3, formRectangle.Height / 7);
            bufferGraphics.DrawString(menu.GetNewGameText, menu.GetFontMenuScreen, Brushes.Black, formRectangle.Width / 3, formRectangle.Height / 4);
            bufferGraphics.DrawString(menu.GetRestartGameText, menu.GetFontMenuScreen, Brushes.Black, formRectangle.Width / 3, formRectangle.Height / 3);
        }

        // Displays this game and the last 4 games results
        public void HighScores()
        {
            string[] arr = highScore.HighScoreArr;
            bufferGraphics.Clear(Control.DefaultBackColor);
            bufferGraphics.DrawString(arr[0], menu.GetFontMenuScreen, Brushes.Black, formRectangle.Width / 3, formRectangle.Height / 7);
            bufferGraphics.DrawString(arr[1], menu.GetFontMenuScreen, Brushes.Black, formRectangle.Width / 3, (formRectangle.Height / 7) + 50);
            bufferGraphics.DrawString(arr[2], menu.GetFontMenuScreen, Brushes.Black, formRectangle.Width / 3, (formRectangle.Height / 7) + 100);
            bufferGraphics.DrawString(arr[3], menu.GetFontMenuScreen, Brushes.Black, formRectangle.Width / 3, (formRectangle.Height / 7) + 150);
            bufferGraphics.DrawString(arr[4], menu.GetFontMenuScreen, Brushes.Black, formRectangle.Width / 3, (formRectangle.Height / 7) + 200);
            bufferGraphics.DrawString(menu.GetNewGameText, menu.GetFontMenuScreen, Brushes.Black, formRectangle.Width / 3, (formRectangle.Height / 7) + 300);
        }
    }
}
