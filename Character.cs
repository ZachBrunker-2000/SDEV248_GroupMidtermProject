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
    public class Character
    { 
        public Character(){
           
        }
        private string name = string.Empty;

        protected static string curLocation = string.Empty;

        protected static string lastLocation = string.Empty;

        public string GetName()
        {
            return name;
        }

        public void SetName(string newName)
        {
            if(newName != string.Empty && newName != null)
            {
                this.name = newName;
            }
            else
            {
                throw new ArgumentException("Invalid name");
            }
        }
       
        
        public string getLocation()
        {
            return curLocation;
        }

        public void SetLocation(string newLocation)
        {
            curLocation = newLocation;
        }

        public string GetLastLocation()
        {
            return lastLocation;
        }

        public void SetLastLocation(string newLastLocation)
        {
            lastLocation = newLastLocation;
        }

        




    }
}