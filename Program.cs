/*
Authors: Ryan Robinson, Renee Guldi, Zach Brunker
Date Created: 4/4/2024
Last Modified:
Description: Main Program of the Mysteries of Emberwick game
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MysteriesOfEmberwick
{
    // Program class to contain the main function where the code will be executed
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
            

            Actions.mapLocations.Add("Estate entrance");
            Actions.mapLocations.Add("Fountain");
            Actions.mapLocations.Add("HedgeMaze Manor");
            Actions.mapLocations.Add("Dining room");

            Console.WriteLine("Hello and welcome to the town of Emberwick.\n What is your name Detective?\n");
            string input = Console.ReadLine() ?? string.Empty;

            Character player = new Character();
            player.SetName(input);
            player.SetLocation("Estate entrance");
            
            Console.WriteLine($"It's great to have you on the case Detective {player.GetName()}");
            
            Inventory inventory = new Inventory();

            Console.WriteLine("Here is a flashlight.");
            Console.WriteLine("Enter Flashlight to pick up the flashlight.");

            inventory.PickUpItem(Actions.GetPlayerStringInput());

            Console.WriteLine("The way ahead is Dark. \nDo you have an item you would like to use?");
            
            inventory.UseItem();


            


            Console.WriteLine("Now that you are at the Estate entrance,\n");
            Actions.GetPlayerWalk();

            Actions.GetPlayerWalk();

            Actions.GetPlayerWalk();

            }
            catch(ArgumentException msg)
            {
                Console.WriteLine(msg);
            }
            catch(IOException msg)
            {
                Console.WriteLine(msg);
            }
        }
    }
}