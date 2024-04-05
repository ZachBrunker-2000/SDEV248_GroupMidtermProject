/*
Authors: Ryan Robinson, Renee Guldi, Zach Brunker
Date Created: 4/4/2024
Last Modified:
Description: Class and set of functions to handle the players action commands
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;

namespace MysteriesOfEmberwick
{
    public class Actions : Character
    {
        public static List<string> mapLocations =  new List<string>();

        string level = string.Empty;


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

        public static int GetPlayerNumberInput()
        {
            int userInput;

            int.TryParse(Console.ReadLine(), out userInput);

            return userInput;
        }


        public static void GetPlayerWalk()
        {
            Console.WriteLine("Which way would you like to go?");
            Console.WriteLine("Please Enter: Forward, Back, Goto");

            string playerInput = GetPlayerStringInput();

            

            switch(playerInput.ToLower())
            {
            case "forward":
                NextLocation();
                break;

            case "back":
                curLocation = lastLocation;
                Console.WriteLine($"You went back to {curLocation}");
                break;

            case "goto":
                displayLocations();
                Console.WriteLine("Please enter the number next to the location you would like to go.");
                GotoLocation(GetPlayerNumberInput());
                break;

            default:
                Console.WriteLine("Please Enter: Forward, back, or goto");
                GetPlayerWalk();
                break;

            }
        }

        public static void NextLocation()
        {
            int i = 0;
            foreach(string item in mapLocations)
            {
                if(mapLocations[i] == curLocation)
                {
                    lastLocation = curLocation;
                    curLocation = mapLocations[i+1];
                    Console.WriteLine($"You are now at: {curLocation}");
                    return;
                }
                i++;
            }
        }

        public static void GotoLocation(int locationNum)
        {
            lastLocation = curLocation;
            int i = 0;
            foreach (string item in mapLocations)
            {
                if (mapLocations[i] == mapLocations[locationNum-1])
                {
                    curLocation = mapLocations[i];
                    Console.WriteLine($"You are now at: {curLocation}");
                    return;
                }
                i++;
            }
            
        }

        static void displayLocations()
        {
            int i = 0;
            foreach(string item in mapLocations)
            {
                Console.WriteLine($"{i + 1}.{item.ToUpper()} \n");
                i++;
            }
        }

    }
}