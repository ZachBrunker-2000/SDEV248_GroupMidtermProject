/*
Authors: Ryan Robinson, Renee Guldi, Zach Brunker
Date Created: 4/4/2024
Last Modified:
Description: Class and set of functions to handle the players action commands
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MysteriesOfEmberwick
{
    public class Actions
    {
        
        // a function to get a key press from the user
        public static bool WaitForKeyPress(string message)
        {
            // creates a console key variable
            ConsoleKey key;

            
            Console.WriteLine($"{message} \n");

            // gets the key press from the user
            key = Console.ReadKey(true).Key;

            // checks if the user hit the enter key if not then false is returned
            if(key == ConsoleKey.Enter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Gets the user input
        public static string GetPlayerStringInput()
        {
            string userInput = Console.ReadLine() ?? string.Empty;

            return userInput;
        
        }

    }
}