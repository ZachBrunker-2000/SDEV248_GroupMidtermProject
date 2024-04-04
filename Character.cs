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
    public class Character(string name)
    {
        string _name = name;

        public string Name
        {
            get => _name;

            set
            {
                if(value != "")
                {
                    _name = value;
                }
            }

        }

    }
}