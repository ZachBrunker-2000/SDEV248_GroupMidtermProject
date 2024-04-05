/*
Authors: Ryan Robinson, Renee Guldi, Zach Brunker
Date Created: 4/4/2024
Last Modified:
Description: Class and set of functions created to handle the players inventory
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MysteriesOfEmberwick
{
    public class Inventory
    {

        public Inventory()
        {
            LoadInventory();
        }
        
         ~Inventory()
        {
            EmptyInventory();
        }

        // Name of text file that will contain player's inventory when game isn't running
        string inventoryFile = "Inventory.txt";


        // Used to store inventory while game is running
        List<string> inventoryItems =  new List<string>();

        // Loads the list of inventory items with items from the text file
        public void LoadInventory()
        {
            // If the file doesn't exist then the function will exit
            if (!File.Exists(inventoryFile))
            {
                return;
            }

            // loads the list with inventory items in the text file
            using (StreamReader sr = File.OpenText(inventoryFile))
            {
                string? temp = sr.ReadLine();
                
                while(temp != null)
                {
                    inventoryItems.Add(temp);
                }
            }

            // Deletes the inventory file after it is empty
            File.Delete(inventoryFile);
        }

        // Empty inventory is called to empty the list into a text file for long term storage
        public void EmptyInventory()
        {
            // Create a new inventory file if the file doesn't exist
            if(!File.Exists(inventoryFile))
            {
                File.Create(inventoryFile);
            }

            // Loads the text file with each item from the inventoryItems
            using (StreamWriter sw = new StreamWriter(inventoryFile))
            {
                for(int i = 0; i < inventoryItems.Count; i++)
                {
                    sw.WriteLine(inventoryItems[i]);
                }
            }
        }

        // Is called to add an item into the players inventory
        public void PickUpItem(string item)
        {
            // ToLower is used to make sure everything added is lower case
            // This will make it easier for the use item function
            inventoryItems.Add(item.ToLower());
            Console.WriteLine($"You picked up {item}!");
        }

        // is called to display the players inventory
        public void DisplayInventory()
        {
            int i = 0;
            foreach(string item in inventoryItems)
            {
                
                // ToUpper is used just for astetics of the menu
                Console.WriteLine($"{i + 1}.{item.ToUpper()} \n");
                i++;
            }
        }

        // is called when the player uses an item. Currently just deletes the item from their inventory
        public void UseItem()
        {
            int itemNum;
            DisplayInventory();

            Console.WriteLine("Please enter the number next to the item you would like to use.");
            itemNum = Actions.GetPlayerNumberInput();

            foreach(string item in inventoryItems)
            {
                
                if(item == inventoryItems[itemNum - 1])
                {
                    Console.WriteLine($"You used: {item}");
                    inventoryItems.Remove(item);
                    return;
                }
            }
        }


    }
}