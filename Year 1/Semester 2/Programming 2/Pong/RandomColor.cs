/* Program name: Pong NEM
Project file name: RandomColor.cs
Author: Nigel Maynard
Date: 28/9/22
Language: C#
Platform: Microsoft Visual Studio 2022
Purpose: Class work
Description: Assessment game: Pong.
Known Bugs:
Additional Features:
*/

using System;
using System.Drawing;

namespace Pong_NEM
{
    public class RandomColor
    {
        // Class Variables
        private const int COLORRANGE = 256;
        private Random random;

        // Getter
        // Returns a random color
        public Color GetColor() => Color.FromArgb(random.Next(COLORRANGE), random.Next(COLORRANGE), random.Next(COLORRANGE));


        // Class constructor
        public RandomColor(Random random)
        {
            this.random = random;
        }
    }
}
