/* Program name: Pong NEM
Project file name: Form1.cs
Author: Nigel Maynard
Date: 24/8/22
Language: C#
Platform: Microsoft Visual Studio 2022
Purpose: Class work
Description: Assessment game: Pong.
Known Bugs:
Additional Features:
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pong_NEM
{
    public partial class Form1 : Form
    {
        // Class Variables
        private Random random;
        private Graphics graphics;
        private Bitmap bufferImage;
        private Graphics bufferGraphics;
        public Controller controller;


        // Class Form Constructor
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            graphics = CreateGraphics();
            bufferImage = new Bitmap(Width, Height);
            bufferGraphics = Graphics.FromImage(bufferImage);
            controller = new Controller(bufferGraphics, random, ClientRectangle);
        }


        // Event handler for timer, prints the screen once it gets to the last line.
        private void timer1_Tick(object sender, EventArgs e)
        {
            bufferGraphics.FillRectangle(Brushes.Black, 0, 0, Width, Height);
            controller.RunGame();
            graphics.DrawImage(bufferImage, 0, 0);
        }

        // Event handler for keydown events, moving paddle and reset/ new game
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) controller.MovePaddleUp(0);
            if (e.KeyCode == Keys.Down) controller.MovePaddleDown(1);

            if (e.KeyCode == Keys.Escape) controller.PauseGame();
            if (e.KeyCode == Keys.N || e.KeyCode == Keys.R) controller = new Controller(bufferGraphics, random, ClientRectangle);
        }
    }
}
