/* Program name: Pong NEM
Project file name: Menu.cs
Author: Nigel Maynard
Date: 26/9/22
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
    public class Menu
    {
        // Class Variables
        private const string MENUTEXT = "Press Esc Pause/Menu",
            NEWGAMETEXT = "Press N for a New Game",
            RESTARTGAMETEXT = "Press R to Restart",
            RESUMETEXT = "Press Esc To Resume";
        private Font fontMainScreen, fontMenuScreen;

        // Getters
        public string GetMenuText => MENUTEXT;
        public string GetNewGameText => NEWGAMETEXT;
        public string GetRestartGameText => RESTARTGAMETEXT;
        public string GetResumeText => RESUMETEXT;
        // This is the 2 fonts with different sizes
        public Font GetFontMainScreen => fontMainScreen;
        public Font GetFontMenuScreen => fontMenuScreen;


        // Class Constructor
        public Menu()
        {
            fontMainScreen = new Font("Ariel", 14, FontStyle.Bold);
            fontMenuScreen = new Font("Ariel", 30, FontStyle.Bold);
        }
    }
}
