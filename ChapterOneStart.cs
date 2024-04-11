using UnityEngine;
using UnityEngine.UI;

public class ChapterOneStart : MonoBehaviour
{
    public Text displayText;
    public InputField nameInputField;
    public InputField playerInputField;
    public InputField playerTravelField;
    public InputField playerInvestigateField;
    public InputField playerQuestionField;
    public InputField PlayerInventoryField;
    public InputField PlayerAccuseField;
    private string playerName;
    private string currentLocation;

    public void Start()
    {
        // Display initial text
        displayText.text = "<color=grey><i>You awake at night to a loud knock on the door.</i></color>" +
            "\n<color=grey><i>Upon answering the door you are greeted by an officer looking to request your help.</i></color>" +
            "\n \n<color=blue>(Officer Bradley): Hello sir I am officer bradley. I currently work for Mister and Missus Acker.</color>" +
            "\n<color=blue>(Officer Bradley): At around 10:00 tonight their daughter had gone missing and were hoping to request your help with the matter.</color>" +
            "\n \n<color=grey><i>You agree to help the officer in his search for he missing girl.</i></color>" +
            "\n \n<color=blue>(Officer Bradley): By the way detective I never got your name.</color>" +
            "\n \n<color=grey><i>In your daze you realize you never told him your name... What was it again?</i></color>" +
            "\n \n<i>============================================================================================================================</i>";

        // Add listener to the input field for when the user enters their name
        nameInputField.onEndEdit.AddListener(SubmitName);
    }

    // Called when the user submits their name
    void SubmitName(string name)
    {
        playerName = name;

        // Concatenate the new text with the existing text
        displayText.text += "\n\n<color=blue>Well </color><i>" + playerName + "</i><color=blue> it's nice to have you onboard.</color>";

        // Save the player's name (you may want to use PlayerPrefs or another method to save it)
        PlayerPrefs.SetString("PlayerName", playerName);

        // Remove the listener for name submission
        nameInputField.onEndEdit.RemoveListener(SubmitName);

        // Call AfterSubmitName to display the next set of text
        AfterSubmitName();
    }

    // Method to display the next set of text after the name is submitted
    void AfterSubmitName()
    {
        // Append the new text to the existing text
        displayText.text += "\n<color=grey><i>The officer takes you to the largest house in the town and fills you in on the situation.</i></color>\n" +
            "\n<color=blue>At around</color> <color=yellow>10:00</color> <color=blue>the window in young Abigail's room was shattered.</color>\n" +
            "\n<color=blue>The guards on duty say that nobody was seen entering or leaving the estate but when we went to check on Abigail she was gone.</color>\n" +
            "\n<color=blue>Mr. Acker has also informed me that while you try to solve the case you will not only have complete access to the manor but full cooperation as well.</color>\n" +
            "\n<color=grey><i>You stand at the entrance of the manor wondering where to begin.</i></color>\n" +
            "\n<i>============================================================================================================================</i>\n";

        currentLocation = "";

        PlayerInput();
    }

    void PlayerInput()
    {
        displayText.text += "\n<color=grey><i>What would you like to do?   (Enter the number corresponding with your answer)</i></color>\n" +
            "\n<color=grey><i>1. Travel (10 minutes)</i></color>\n" +
            "\n<color=grey><i>2. Investigate (30 minutes)</i></color>\n" +
            "\n<color=grey><i>3. Question (10 minutes per person)</i></color>\n" +
            "\n<color=grey><i>4. Check Inventory</i></color>\n" +
            "\n<color=grey><i>5. Accuse</i></color>\n";

        // Add listener to the input field for when the user enters their choice
        playerInputField.onEndEdit.AddListener(SubmitChoice);
    }

    // Called when the user submits their choice
    void SubmitChoice(string choice)
    {
        int selectedOption;
        if (int.TryParse(choice, out selectedOption))
        {
            switch (selectedOption)
            {
                case 1:
                    // Call method for traveling
                    Travel();
                    break;
                case 2:
                    // Call method for investigation
                    Investigate();
                    break;
                case 3:
                    // Call method for questioning
                    Question();
                    break;
                case 4:
                    // Call method for checking inventory
                    CheckInventory();
                    break;
                case 5:
                    // Call method for accusing
                    Accuse();
                    break;
                default:
                    displayText.text += "\n<color=red>Invalid option. Please enter a number between 1 and 5.</color>";
                    break;
            }
        }
        else
        {
            displayText.text += "\n<color=red>Invalid input. Please enter a number.</color>";
        }

    }

    void Travel()
    {
        playerInputField.onEndEdit.RemoveListener(SubmitChoice);

        displayText.text += "\n<color=grey><i>You decide to move to a different area, but what area is yet to be determined</i></color>\n" +
            "\n<color=grey><i>A. Outside</i></color>\n" +
            "\n<color=grey><i>B. Guard booth</i></color>\n" +
            "\n<color=grey><i>C. Main hall</i></color>\n" +
            "\n<color=grey><i>D. Abigail's room</i></color>\n" +
            "\n<color=grey><i>E. Parents room</i></color>\n" +
            "\n<color=grey><i>F. Study</i></color>\n" +
            "\n<color=grey><i>G. Living Room</i></color>\n" +
            "\n<color=grey><i>H. Storage Closet</i></color>\n" +
            "\n<color=grey><i>I. Kitchen</i></color>\n" +
            "\n<color=grey><i>J. Bathroom</i></color>\n" +
            "\n<color=grey><i>K. Cancel  (Does not consume time)</i></color>\n";

        playerTravelField.onEndEdit.AddListener(TravelChoice);
    }

    void TravelChoice(string gotolocation)
    {
        // Remove the listener for TravelChoice
        playerTravelField.onEndEdit.RemoveListener(TravelChoice);

        // Convert the input to uppercase to handle both uppercase and lowercase input
        gotolocation = gotolocation.ToUpper();

        // Check if the player entered a valid location
        switch (gotolocation)
        {
            case "A":
                // Set the current location to "Outside" and perform any other necessary actions
                currentLocation = "Outside";
                displayText.text += "\n<color=grey><i>You moved outside.</i></color>\n";
                PlayerInput();
                // Implement logic for what happens when the player travels to "Outside"
                // You can add more cases for other locations
                break;
            case "B":
                // Set the current location to "Guard booth" and perform any other necessary actions
                currentLocation = "Guard booth";
                displayText.text += "\n<color=grey><i>You moved to the guards booth outside.</i></color>\n";
                PlayerInput();
                // Implement logic for what happens when the player travels to "Guard booth"
                break;
            case "C":
                // Set the current location to "Guard booth" and perform any other necessary actions
                currentLocation = "Main hall";
                displayText.text += "\n<color=grey><i>You moved to the main hallway.</i></color>\n";
                PlayerInput();
                // Implement logic for what happens when the player travels to "Guard booth"
                break;
            case "D":
                // Set the current location to "Guard booth" and perform any other necessary actions
                currentLocation = "Abigails room";
                displayText.text += "\n<color=grey><i>You moved to Abigails room.</i></color>\n";
                PlayerInput();
                // Implement logic for what happens when the player travels to "Guard booth"
                break;
            case "E":
                // Set the current location to "Guard booth" and perform any other necessary actions
                currentLocation = "Parents room";
                displayText.text += "\n<color=grey><i>You moved to the parents room.</i></color>\n";
                PlayerInput();
                // Implement logic for what happens when the player travels to "Guard booth"
                break;
            case "F":
                // Set the current location to "Guard booth" and perform any other necessary actions
                currentLocation = "Study";
                displayText.text += "\n<color=grey><i>You moved to the study.</i></color>\n";
                PlayerInput();
                // Implement logic for what happens when the player travels to "Guard booth"
                break;
            case "G":
                // Set the current location to "Guard booth" and perform any other necessary actions
                currentLocation = "Living Room";
                displayText.text += "\n<color=grey><i>You moved the living room.</i></color>\n";
                PlayerInput();
                // Implement logic for what happens when the player travels to "Guard booth"
                break;
            case "H":
                // Set the current location to "Storage" and perform any other necessary actions
                currentLocation = "Storage";
                displayText.text += "\n<color=grey><i>You moved to the storage closet.</i></color>\n";
                PlayerInput();
                // Implement logic for what happens when the player travels to "Guard booth"
                break;
            case "I":
                // Set the current location to "Guard booth" and perform any other necessary actions
                currentLocation = "Kitchen";
                displayText.text += "\n<color=grey><i>You moved to the kitchen.</i></color>\n";
                PlayerInput();
                // Implement logic for what happens when the player travels to "Guard booth"
                break;
            case "J":
                // Set the current location to "Guard booth" and perform any other necessary actions
                currentLocation = "Bathroom";
                displayText.text += "\n<color=grey><i>You moved to the bathroom.</i></color>\n";
                PlayerInput();
                // Implement logic for what happens when the player travels to "Guard booth"
                break;
            // Add more cases for other locations
            case "K":
                // If the player cancels, simply call PlayerInput to display the options again
                PlayerInput();
                return; // Exit the method to avoid further execution
            default:
                // If the player enters an invalid location, display an error message and prompt again
                displayText.text += "\n<color=red>Invalid location. Please enter a valid option.</color>";
                // Add back the listener for TravelChoice
                playerTravelField.onEndEdit.AddListener(TravelChoice);
                return; // Exit the method to avoid further execution
        }

        // Perform any additional actions specific to the chosen location
        // For example, you might want to update the displayText to reflect the new location
    }


    void Investigate()
{
    // Add code for investigation
    playerInputField.onEndEdit.RemoveListener(SubmitChoice);

    if (currentLocation == "Outside")
    {
        playerInvestigateField.onEndEdit.AddListener(OutsideInvestigate);
        displayText.text += "\n<color=grey><i>You look around the outside area of the manor and find a few interesting areas. What would you like to check out?</i></color>\n" +
        "\n<color=grey><i>A. Outside Abigail's room.</i></color>\n" +
        "\n<color=grey><i>B. The manors outer walls</i></color>\n" +
        "\n<color=grey><i>C. The torn fabric</i></color>\n" +
        "\n<color=grey><i>D. The gardens</i></color>\n" +
        "\n<color=grey><i>E. Back</i></color>\n";
    }

    else if (currentLocation == "Guards booth")
    {
        playerInvestigateField.onEndEdit.AddListener(GuardsBoothInvestigate);
        // Update the text specific to the Guards booth here
        displayText.text += "\n<color=grey><i>You enter the guards booth at the entrance of the estate. The smell of coffee fills the air</i></color>\n" +
            "<color=grey><i>What would you like to investigate</i></color>\n" +
        "\n<color=grey><i>A. The guards lockers.</i></color>\n" +
        "\n<color=grey><i>B. The Table</i></color>\n" +
        "\n<color=grey><i>C. The note on the door</i></color>\n" +
        "\n<color=grey><i>D. Back</i></color>\n";
    }

    else if (currentLocation == "Main hall")
    {
        playerInvestigateField.onEndEdit.AddListener(MainHallInvestigate);
        displayText.text += "\n<color=grey><i>You enter the main hallway and a few things catch your eye. Now where to begin.</i></color>\n" +
            "\n<color=grey><i>A. The mud on the floor</i></color>\n" +
            "\n<color=grey><i>B. The pictures</i></color>\n" +
            "\n<color=grey><i>C. The walls</i></color>\n" +
            "\n<color=grey><i>D. Back</i></color>\n";
    }

    else if (currentLocation == "Abigails room")
    {
        playerInvestigateField.onEndEdit.AddListener(AbigailsInvestigate);
        displayText.text += "\n<color=grey><i>You enter the victims room. Its relativly clean but it does appear that there was a struggle. What should i check first?</i></color>\n" +
        "\n<color=grey><i>A. The Candlestick</i></color>\n" +
        "\n<color=grey><i>B. The window</i></color>\n" +
        "\n<color=grey><i>C. The Closet</i></color>\n" +
        "\n<color=grey><i>D. Abigail's Diary</i></color>\n" +
        "\n<color=grey><i>E. Back</i></color>\n";
    }

    else if (currentLocation == "Parents room")
    {
        playerInvestigateField.onEndEdit.AddListener(ParentsRoomInvestigate);
        displayText.text += "\n<color=grey><i>You ask the Acker's to show you their room. They agree and lead you inside.</i></color>\n" +
            "<color=grey><i>Itsa very tidy room with a large safe next to the bed. They're in too much shock to remember the combination. Where to look first</i></color>\n" +
        "\n<color=grey><i>A. The safe</i></color>\n" +
        "\n<color=grey><i>B. The Bookshelf</i></color>\n" +
        "\n<color=grey><i>C. The nightstand</i></color>\n" +
        "\n<color=grey><i>D. Back</i></color>\n";
    }

    else if (currentLocation == "Study")
    {
        playerInvestigateField.onEndEdit.AddListener(StudyInvestigate);
        displayText.text += "\n<color=grey><i>You approach a large open room with books that stretch from wall to wall with a sofa and a table near a fire pit. It appears to be a study</i></color>\n" +
            "<color=grey><i>Something in here may help</i></color>\n" +
        "\n<color=grey><i>A. The northern bookshelf</i></color>\n" +
        "\n<color=grey><i>B. The eastern bookshelf</i></color>\n" +
        "\n<color=grey><i>C. The southern bookshelf</i></color>\n" +
        "\n<color=grey><i>D. The western bookshelf</i></color>\n" +
        "\n<color=grey><i>E. The table and chair</i></color>\n" +
        "\n<color=grey><i>F. Back</i></color>\n";
    }
    else if (currentLocation == "Living Room")
    {
        playerInvestigateField.onEndEdit.AddListener(LivingRoomInvestigate);
        displayText.text += "\n<color=grey><i>You walk into the living room. Its a large open space with several chairs and a fireplace. Seems cozy.</i></color>\n" +
            "<color=grey><i>I wonder if anything in here is of any use.</i></color>\n" +
        "\n<color=grey><i>A. The fireplace.</i></color>\n" +
        "\n<color=grey><i>B. The chairs</i></color>\n" +
        "\n<color=grey><i>C. Back</i></color>\n";
    }
    else if (currentLocation == "Storage") 
    {
        playerInvestigateField.onEndEdit.AddListener(StorageInvestigate);
        displayText.text += "\n<color=grey><i>The maid lets you into the storage closet to look around. The closet itself is bigger than your room at home. Might as well look around</i></color>\n" +
        "\n<color=grey><i>A. The chemicals</i></color>\n" +
        "\n<color=grey><i>B. The cleaning equipment</i></color>\n" +
        "\n<color=grey><i>C. The oils</i></color>\n" +
        "\n<color=grey><i>D. Back</i></color>\n";
    }
    else if (currentLocation == "Kitchen") 
    { playerInvestigateField.onEndEdit.AddListener(KitchenInvestigate);
        displayText.text += "\n<color=grey><i>You enter the kitchen and everything seems fine. The butler seems a bit stressed though. Can't hurt to look around right?</i></color>\n" +
        "\n<color=grey><i>A. The Utinsels</i></color>\n" +
        "\n<color=grey><i>B. The Table</i></color>\n" +
        "\n<color=grey><i>C. Back</i></color>\n";
    }
    else if (currentLocation == "Bathroom") 
    { playerInvestigateField.onEndEdit.AddListener(BathRoomInvestigate);
        displayText.text += "\n<color=grey><i>This bathroom is b=very luxurious. Might be bigger than my house. The maid seems confused. Need to look around.</i></color>\n" +
        "\n<color=grey><i>A. The sink</i></color>\n" +
        "\n<color=grey><i>B. The Bathtub</i></color>\n" +
        "\n<color=grey><i>C. The Mirror</i></color>\n" +
        "\n<color=grey><i>D. Back</i></color>\n";
    }
    else if (currentLocation == "Secret") 
    { playerInvestigateField.onEndEdit.AddListener(SecretInvestigate);
        displayText.text += "\n<color=grey><i>I cant believe such a thing was hidden behind a closet. I wonder what we'll find</i></color>\n" +
            "\n<color=grey><i> You use the oil you found from the storage room to light the lantern taken from the garden.</i></color>\n" +
            "\n<color=grey><i>With the lantern lit a long descent darkness is uncovered. Its a basement that stretches at least 40 meters downward.</i></color>\n" +
            "\n<color=grey><i>You and everyone else enter the room expecting the worst, but to your surprise you find Abigail unconscious in the corner.</i></color>\n" +
            "<color=grey><i>She appears to be tied in the same rope that was missing from the storage closet, and her mouth was covered by the rag that was missing.</i></color>\n" +
            "<color=grey><i>Everyone rushes over to check on Abigail. The maid says that she is alive but she will most likely be unconscious for a while.</i></color>\n" +
            "\n<color=grey><i>Who could have done this? Time is running out I need to find a clue.</i></color>\n" +
        "\n<color=grey><i>A. Abigail</i></color>\n" +
        "\n<color=grey><i>B. Strange note.</i></color>\n" +
        "\n<color=grey><i>C. Back</i></color>\n";
    }
}

void OutsideInvestigate(string InvestOut)
{
    InvestOut = InvestOut.ToUpper();

    switch (InvestOut)
    {
        case "A":
            displayText.text += "\n<color=grey><i>You look at the area outside Abigail's room, and find that the broken glass is on the outside.</i></color>" +
                "\n<color=grey><i>This would indicate that someone left through the window</i></color>\n" +
                "\n<color=yellow><i>Broken Glass</i></color> <color=grey><i>has been added to your inventory.</i></color>\n";
            playerInvestigateField.onEndEdit.RemoveListener(OutsideInvestigate);
            Investigate();
            break;
        case "B":
            displayText.text += "\n<color=grey><i>You look around the walls but dont find anything that would suggest an entrance or an escape.</i></color>\n";
            playerInvestigateField.onEndEdit.RemoveListener(OutsideInvestigate);
            Investigate();
            break;
        case "C":
            displayText.text += "\n<color=grey><i>You notice a piece of fabric stuck on a piece of broken glass. Its course.</i></color>\n" +
                "\n<color=yellow><i>Torn Fabric</i></color> <color=grey><i> has been added to your inventory.</i></color>\n";
            playerInvestigateField.onEndEdit.RemoveListener(OutsideInvestigate);
            Investigate();
            break;
        case "D":
            displayText.text += "\n<color=grey><i>You walk over to the garden you saw on your way in</i></color>\n" +
                "\n<color=grey><i>Nothing sticks out but you notice that one of the unlit lanterns are loose. May come in handy later</i></color>\n" +
                "\n<color=yellow><i>Lantern</i></color> <color=grey><i> has been added to your inventory.</i></color>\n";
                playerInvestigateField.onEndEdit.RemoveListener(OutsideInvestigate);
            Investigate();
            break;
        case "E":
            displayText.text += "\n<color=grey><i>You decided to do something else.</i></color>\n";
            playerInvestigateField.onEndEdit.RemoveListener(OutsideInvestigate);
            PlayerInput();
            break;
          default:
            displayText.text = += “\n<color=grey><i>Please choose a valid option.</i></color>\n”
		        break;
    }


    }

void GuardsBoothInvestigate(string InvestGuard) {
    InvestGuard = InvestGuard.ToUpper();
    Switch (InvestGuard)
        {
        case “A”:
            displayText.text = “\n<color=grey><i>You navigate the guard’s locker area.</i></color>\n” +
            “\n<color=grey><i>You notice a shred of torn fabric from an officer’s uniform. It has no identifying markers.</i></color>\n” +
            “\n<color=yellow><i>Shred of officer’s uniform</i></color><color=grey><i> added to inventory.</i></color>\n”;
            playerInvestigateField.onEndEdit.RemoveListener(GuardsBoothInvestigate);
            Investigate();
            break;
        case “B”:
        		displayText.text = “\n<color=grey><i>You head to the table where officers congregate.</i></color>\n” +
        “\n<color=grey><i>You find Officer Abraham’s badge, an empty coffee cup, and a letter of resignation next to it.</i></color>\n” +
        “\n<color=yellow><i>Officer Abraham’s badge and resignation letter</i></color><color=grey><i> added to inventory.</i></color>\n”;
        playerInvestigateField.onEndEdit.RemoveListener(GuardsBoothInvestigate);
        Investigate();
        break;
        case “C”:
          	displayText.text = “\n<color=grey><i>You observe the note taped to the door.</i></color>\n” +
          “\n<color=grey><i>The note states:  </i></color>\n” +
          “\n<color=black><i> “Officer Bradley is a chicken” </i></color>\n”;
          playerInvestigateField.onEndEdit.RemoveListener(GuardsBoothInvestigate);
          Investigate();
        break;
        case “D”:
        	displayText.text += "\n<color=grey><i>You decided to do something else.</i></color>\n";
        playerInvestigateField.onEndEdit.RemoveListener(GuardsBoothInvestigate);
        PlayerInput();
        break;
        
        default:
        displayText.text = += “\n<color=grey><i>Please choose a valid option. </i></color>\n”
        		break;
	}
    }

void MainHallInvestigate(string InvestHall)
    {
    InvestHall= InvestHall.ToUpper();
	  switch (InvestHall)
	  {
      case “A”:
      		displayText.text = “\n<color=grey><i>You observe the muddied footprints all over the main hall floor.</i></color>\n” +
          “\n<color=grey><i>You should ask the maid when these appeared.</i></color>\n” +
          “\n<color=grey><i>Maybe look somewhere else. </i></color>\n”;
          playerInvestigateField.onEndEdit.RemoveListener(MainHallInvestigate);
          Investigate();
          break;
    case “B”:
    		displayText.text = “\n<color=grey><i>You look at the family pictures posted on the walls lining the hall..</i></color>\n” +
        “\n<color=grey><i>The family looks happy in their portraits lining the hall.</i></color>\n” +
        “\n<color=grey><i>Nothing out of the ordinary here.</i></color>\n”;
        playerInvestigateField.onEndEdit.RemoveListener(MainHallInvestigate);
        Investigate();
        Break;
    case “C”:
      	displayText.text = “\n<color=grey><i>You observe the walls of the hall.</i></color>\n” +
        “\n<color=grey><i>Knocking on the hall wall, it sounds oddly hollow.</i></color>\n” +
        “\n<color=grey><i>I will have to see if there is something behind here later.</i></color>\n”;
        playerInvestigateField.onEndEdit.RemoveListener(MainHallInvestigate);
        Investigate();
        Break;
    case “D”:
      	displayText.text += "\n<color=grey><i>You decided to do something else.</i></color>\n";
        playerInvestigateField.onEndEdit.RemoveListener(MainHallInvestigate);
        PlayerInput();
        break;
    
    default:
        displayText.text = += “\n<color=grey><i>Please choose a valid option. </i></color>\n”
    		break;
	}
    }


void AbigailsInvestigate(string InvestAbigal)
    {
	InvestAbigal = InvestAbigal.ToUpper();
	Switch (InvestAbigal)
	{
	Case “A”:
		displayText.text = “\n<color=grey><i>You pick up the candlestick on Abigail’s bed-side table.</i></color>\n” +
“\n<color=grey><i> </i></color>\n” +
“\n<color=grey><i> </i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(AbigailsInvestigate);
Investigate();
Break;
Case “B”:
		displayText.text = “\n<color=grey><i>You observe the broken window, there doesn’t seem to be glass inside the victim’s bedroom.</i></color>\n” +
“\n<color=grey><i>You peer outside to the front of the manner from within Abigail’s bedroom.</i></color>\n” +
“\n<color=grey><i>Strange there’s no glass inside.</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(AbigailsInvestigate);
Investigate();
Break;
Case “C”:
	displayText.text = “\n<color=grey><i>You check in Abigail’s closet</i></color>\n” +
“\n<color=grey><i>You knock on the wall inside the closet, it sounds hollow as well.</i></color>\n”;
If (playerInventory = Lantern && SecretLeverDiscovered = yes) 
{
“\n<color=grey><i>You look up and see the secret lever.</i></color>\n” + “\n<color=grey><i>You reach up and pull the lever..</i></color>\n”;
“\n<color=grey><i>Do you enter the secret room?</i></color>\n”;
}
“\n<color=grey><i>You don’t see any way to open the wall at this time.</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(AbigailsInvestigate);
Investigate();
Break;
Case “D”:
	displayText.text = “\n<color=grey><i>You pick up Abigail’s diary, neatly tucked in a drawer at her desk.</i></color>\n” +
“\n<color=grey><i>Skimming through the pages to gain insight fast, you read an entry from two weeks ago: </i></color>\n” +
“\n<color=orange><i>(Abigail’s Diary): It feels like someone has been watching me at night. I don’t feel safe in this house. </i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(AbigailsInvestigate);
Investigate();
Break;
Case “E”:
	displayText.text += "\n<color=grey><i>You decided to do something else.</i></color>\n";
playerInvestigateField.onEndEdit.RemoveListener(AbigailsInvestigate);
PlayerInput();
break;
Default:
displayText.text = += “\n<color=grey><i>Please choose a valid option. </i></color>\n”
		Break;
	}
    }

    void ParentsRoomInvestigate(string InvestParent)
    {
	InvestParent = InvestParent.ToUpper();
	Switch (InvestParent)
	{
	Case “A”:
		displayText.text = “\n<color=grey><i>You decide to check the family safe.</i></color>\n” +
“\n<color=grey><i></i></color>\n” +
“\n<color=grey><i> </i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(ParentsRoomInvestigate);
Investigate();
Break;
Case “B”:
		displayText.text = “\n<color=grey><i>You wander towards the bookshelves in the room.</i></color>\n” +
“\n<color=grey><i>You skim the books for anything out of the ordinary. The Acker’s seem very organized with their literature.</i></color>\n” +
“\n<color=grey><i>You don’t find anything suspicious. </i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(ParentsRoomInvestigate);
Investigate();
Break;
Case “C”:
	displayText.text = “\n<color=grey><i>You decide to check out Mr. and Mrs. Acker’s nightstands. </i></color>\n” +
“\n<color=grey><i>You do not find anything of interest in either of their drawers. </i></color>\n” +
“\n<color=grey><i>Check out something else?</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(ParentsRoomInvestigate);
Investigate();
Break;
Case “D”:
	displayText.text += "\n<color=grey><i>You decided to do something else.</i></color>\n";
playerInvestigateField.onEndEdit.RemoveListener(ParentsRoomInvestigate);
PlayerInput();
break;
Default:
displayText.text = += “\n<color=grey><i>Please choose a valid option. </i></color>\n”
		Break;
	}
    }

    void StudyInvestigate(string InvestStudy)
    {
	InvestStudy = InvestStudy.ToUpper();
	Switch (InvestStudy)
	{
	Case “A”:
		displayText.text = “\n<color=grey><i>You head towards the northern facing bookshelf.</i></color>\n” +
“\n<color=grey><i>You notice similar organization as the books in the Acker’s bedroom.</i></color>\n” +
“\n<color=grey><i>Nothing seems misplaced here.</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(StudyInvestigate);
Investigate();
Break;
Case “B”:
		displayText.text = “\n<color=grey><i>You head towards the eastern facing bookshelf.</i></color>\n” +
“\n<color=grey><i>You notice similar organization as the books in the Acker’s bedroom.</i></color>\n” +
“\n<color=grey><i>Nothing seems misplaced here. </i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(StudyInvestigate);
Investigate();
Break;
Case “C”:
	displayText.text = “\n<color=grey><i>You head towards the southern facing bookshelf.</i></color>\n” +
“\n<color=grey><i>You notice similar organization as the books in the Acker’s bedroom.</i></color>\n” +
“\n<color=grey><i>Nothing seems to be misplaced here.</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(StudyInvestigate);
Investigate();
Break;
Case “D”:
	displayText.text = “\n<color=grey><i>You head towards the western facing bookshelf.</i></color>\n” +
“\n<color=grey><i>You notice similar organization as the books in the Acker’s bedroom.</i></color>\n” +
“\n<color=grey><i>Nothing seems to be misplaced here.</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(StudyInvestigate);
Investigate();
Break;
Case “E”:
	displayText.text = “\n<color=grey><i>You observe the table and chair in the corner.</i></color>\n” +
“\n<color=grey><i>A pile of mail sits on a small table. Inside is an invoice for the construction of the house. Although the paper says there are more rooms than the Ackers requested in the original build plans for the manor.</i></color>\n” +
“\n<color=grey><i>This may come in handy when questioning Mr. Acker further.</i></color>\n” +
“\n<color=yellow><i>Invoice</i></color><color=grey><i> added to inventory.</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(StudyInvestigate);
Investigate();
Break;
Case “F”:
	displayText.text += "\n<color=grey><i>You decided to do something else.</i></color>\n";
playerInvestigateField.onEndEdit.RemoveListener(StudyInvestigate);
PlayerInput();
break;

Default:
displayText.text = += “\n<color=grey><i>Please choose a valid option. </i></color>\n”
		Break;
	}
    }

    void LivingRoomInvestigate(string InvestLiving)
    {
	InvestLiving = InvestLiving.ToUpper();
	Switch (InvestLiving)
	{
	Case “A”:
		displayText.text = “\n<color=grey><i>You head towards the fireplace.</i></color>\n” +
“\n<color=grey><i>You notice a piece of charred paper within the fireplace, not fully burnt when the flames had died. You read what you can:</i></color>\n” +
“\n<color=grey><i>(Burnt Note): *illegible* please hide Abigail Acker in the discussed *illegible*. </i></color>\n” +
“\n<color=grey><i>This might come in handy.</i></color>\n” +
“\n<color=yellow><i>Burnt Note </i></color><color=grey><i>has been added to your inventory:</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(LivingRoomInvestigate);
Investigate();
Break;
Case “B”:
		displayText.text = “\n<color=grey><i>You check out the chairs in the room. </i></color>\n” +
“\n<color=grey><i>Nothing particularly catches your eye</i></color>\n” +
“\n<color=grey><i>You look around the room again. </i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(LivingRoomInvestigate);
Investigate();
Break;
Case “C”:
	displayText.text += "\n<color=grey><i>You decided to do something else.</i></color>\n";
playerInvestigateField.onEndEdit.RemoveListener(LivingRoomInvestigate);
PlayerInput();
break;
Default:
displayText.text = += “\n<color=grey><i>Please choose a valid option. </i></color>\n”
		Break;
	}
    }

    void StorageInvestigate(string InvestStore)
    {
	InvestStore = InvestStore.ToUpper();
	Switch (InvestStore)
	{
	Case “A”:
		displayText.text = “\n<color=grey><i>There are some chemicals on one of the shelves that catch your eye.</i></color>\n” +
“\n<color=grey><i>The maid said something about managing the storage inventory.</i></color>\n” +
“\n<color=grey><i>She might have insight.</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(StorageInvestigate);
Investigate();
Break;
Case “B”:
		displayText.text = “\n<color=grey><i>The wall is lined with hanging cleaning instruments.</i></color>\n” +
“\n<color=grey><i>Nothing seems out of the ordinary there.</i></color>\n” +
“\n<color=grey><i>You look around the storage room again.</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(StorageInvestigate);
Investigate();
Break;
Case “C”:
	displayText.text = “\n<color=grey><i>You notice a bottle of lantern oil on the shelf with all the other oils.</i></color>\n” +
“\n<color=grey><i>This might come in handy later.</i></color>\n” +
“\n<color=yellow><i>Lantern Oil</i></color><color=grey><i> added to inventory</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(StorageInvestigate);
Investigate();
Break;
Case “D”:
	displayText.text += "\n<color=grey><i>You decided to do something else.</i></color>\n";
playerInvestigateField.onEndEdit.RemoveListener(StorageInvestigate);
PlayerInput();
break;
Default:
displayText.text = += “\n<color=grey><i>Please choose a valid option. </i></color>\n”
		Break;
	}
    }

    void KitchenInvestigate(string InvestKitchen)
    {
	InvestKitchen= InvestKitchen.ToUpper();
	Switch (InvestKitchen)
	{
	Case “A”:
		displayText.text = “\n<color=grey><i>You open the utinesal’s drawer - the Butler references seeing a strange fiber on the blade of one of the knives.</i></color>\n” +
“\n<color=grey><i>You notice some tan fibers on a knife in the drawer. The Butler keeps an eye on the kitchen, this maybe important to the case.</i></color>\n” +
“\n<color=yellow><i>Rope Fibers</i></color><color=grey><i> added to Inventory</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(KitchenInvestigate);
Investigate();
Break;
Case “B”:
		displayText.text = “\n<color=grey><i>You head towards the kitchen table - The Butler adds that one of his rags has seemingly disappeared</i></color>\n” +
“\n<color=grey><i>You are unsure how he could tell one is missing. </i></color>\n” +
“\n<color=grey><i>You look around the room again, strange that a rag went missing.</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(KitchenInvestigate);
Investigate();
Break;
Case “C”:
	displayText.text += "\n<color=grey><i>You decided to do something else.</i></color>\n";
playerInvestigateField.onEndEdit.RemoveListener(KitchenInvestigate);
PlayerInput();
break;
Default:
displayText.text = += “\n<color=grey><i>Please choose a valid option. </i></color>\n”
		Break;
	}
    }

    void BathRoomInvestigate(string InvestBath)
    {
	InvestBath= InvestBath.ToUpper();
	Switch (InvestBath)
	{
	Case “A”:
		displayText.text = “\n<color=grey><i>You observe the sink area.</i></color>\n” +
“\n<color=grey><i>It’s oddly clean,</i></color>\n” +
“\n<color=grey><i>You look around the bathroom again.</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(BathRoomInvestigate);
Investigate();
Break;
Case “B”:
		displayText.text = “\n<color=grey><i>You pull back the curtain around the clawfoot bathtub.</i></color>\n” +
“\n<color=grey><i>Seems ordinary enough. </i></color>\n” +
“\n<color=grey><i>You look around the bathroom again.</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(BathRoomInvestigate);
Investigate();
Break;
Case “C”:
	displayText.text = “\n<color=grey><i>You pull on the mirror to check for a medicine cabinet, and to your surprise it opens.</i></color>\n” +
“\n<color=grey><i>You notice bandages missing from their space, the maid said she did inventory this morning.</i></color>\n” +
“\n<color=grey><i>Checking for wounds on suspects might be useful to consider..</i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(BathRoomInvestigate);
Investigate();
Break;
Case “D”:
	displayText.text += "\n<color=grey><i>You decided to do something else.</i></color>\n";
playerInvestigateField.onEndEdit.RemoveListener(BathRoomInvestigate);
PlayerInput();
break;
Default:
displayText.text = += “\n<color=grey><i>Please choose a valid option. </i></color>\n”
		Break;
	}
    }

    void SecretInvestigate(string InvestSecret)
    {
	InvestSecret= InvestSecret.ToUpper();
	Switch (InvestSecret)
	{
	Case “A”:
		displayText.text = “\n<color=grey><i></i></color>\n” +
“\n<color=grey><i> </i></color>\n” +
“\n<color=grey><i> </i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(SecretInvestigate);
Investigate();
Break;
Case “B”:
		displayText.text = “\n<color=grey><i></i></color>\n” +
“\n<color=grey><i> </i></color>\n” +
“\n<color=grey><i> </i></color>\n”;
playerInvestigateField.onEndEdit.RemoveListener(SecretInvestigate);
Investigate();
Break;
Case “C”:
	displayText.text += "\n<color=grey><i>You decided to do something else.</i></color>\n";
playerInvestigateField.onEndEdit.RemoveListener(SecretInvestigate);
PlayerInput();
break;
Default:
displayText.text = += “\n<color=grey><i>Please choose a valid option. </i></color>\n”
		Break;
	}
    }



    void Question()
    {
        // Add code for questioning
        playerInputField.onEndEdit.RemoveListener(SubmitChoice);
    }

    void CheckInventory()
    {
	displayText.text =
        // Add code for checking inventory
        playerInputField.onEndEdit.RemoveListener(SubmitChoice);
    }

   void Accuse()
    {
        int accuseNum = 0;
        
        bool isGuessCorrect = false;


        displayText.text += "\n<color=grey><i>Who should I accuse</i></color>\n" +
                "\n<color=red><i>A. Thomas Acker</i></color>\n" +
                "\n<color=orange><i>B. Alice Acker</i></color>\n" +
                "\n<color=blue><i>C. Officer Bradley</i></color>\n" +
                "\n<color=green><i>D. Officer Abraham</i></color>\n" +
                "\n<color=cyan><i>E. Sarah McKinsly</i></color>\n" +
                "\n<color=purple><i>F. Jefferson Oakley</i></color>\n" +
                "\n<color=grey><i>G. Back</i></color>\n";

        
        playerInputField.onEndEdit.RemoveListener(SubmitChoice);
        
        var input = PlayerAccuseField.GetComponent<InputField>();

        var playerInput = new InputField.SubmitEvent();

        playerInput.AddListener(delegate {GetStringInput();});
        
        input.onEndEdit = playerInput;

        if(accuseNum <= 2)
        {
            
            accuseNum += 1;
            
            
            switch(input.text.ToUpper())
            {
                case "A":
                    displayText.text += $"<color = red><i>You have accused Thomas Acker!</i></color>";
                    isGuessCorrect = false;
                    break;

                case "B":
                    displayText.text += $"<color = orange><i>You have accused Alice Acker!</i></color>";
                    isGuessCorrect = false;
                    break;
                case "C":
                    displayText.text += $"<color = blue><i>You have accused Officer Bradley!</i></color>";
                    isGuessCorrect = false;
                    break;
                case "D":
                    displayText.text += $"<color = green><i>You have accused Officer Abraham!</i></color> \n You have Accused The Right person... For now." +
                    "Further invetigating could lead to bigger culprits";
                    isGuessCorrect = true;
                    break;
                case "E":
                    displayText.text += $"<color = cyan><i>You have accused Sarah McKinsly!</i></color>";
                    isGuessCorrect = false;
                    break;
                case "F":
                    displayText.text += $"<color = purple><i>You have accused Jefferson Oakley!</i></color>";
                    isGuessCorrect = false;
                    break;
                case "G":
                    displayText.text += $"<color = gray><i>You Chose to go back.</i></color>";
                    break;
                default:
                    displayText.text += "Please enter one of the options from the list.";
                    Accuse();
                    break;


            }
            
        }

    }

    string GetStringInput()
    {
        string sInput = playerInputField.text;

        return sInput;
    }

    string CurrentLocation()
    {
        return currentLocation; 
    }
}


