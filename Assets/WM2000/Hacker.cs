
using UnityEngine;

public class Hacker : MonoBehaviour {
    // Game Configuration

    // set up different variable 'Arrays'

    string[] L1passwords = {"Table", "Head", "Wheel", "Cheese", "Fly" };
    string[] L2passwords = { "Happy", "Royal", "Peanut", "Chicken", "Flower" };
    string[] L3passwords = { "Escapism", "Petunia", "Botanical", "Seaweed", "Consequence" };

   
    // Game State

    int level;

    enum Screen { MainMenu, Password, Win };  // emum is a list of possible values or states
                                              // array is a set of alternative related data/values

    string password;

    Screen currentScreen;


	// Run Game
	
    void Start () {
       
        ShowMainMenu();

	}

    void ShowMainMenu() 
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("It's time to start practicing password cracking - want a go?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Where would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("1.Your Mum's Computer (Easy!)");
        Terminal.WriteLine("2.Your School's Computer (Medium...)");
        Terminal.WriteLine("3.Scotland Yard's Mainframe (Eeeek!)");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter Your Selection ");    
    }

    void OnUserInput(string input)
    {
        if (input == "Menu") // This is a 'listener' always first in line when anything is typed in using 'OnUserInput' and which will
                            // always trigger ShowMainMenu -  a clear/screen and re-draw of the main menu. 
            // ShowMainMenu sets the screen state to 'Screen.MainMenu' which routes 'input' via relay to RunMainMenu (see next line of code)
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);      // Calls function RunMainMenu and passes-it-along the required string variable (box) called 'input'
                                     // If it didn't include the variable in brackets it would throw an exception - 
                                     // because the method requires to be called along with a string variable which it (re) calls 'input'.
                                     // - this 'input' string was in turn relay-race'ed 
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input)  // RunMainmenu executes - and required an externally-sent string variable 
                                    // naming or 're-naming' (or even 'continuing to name it') 'input'.
                                    // Keyboard input is sent by the black-box 'OnUserInput' to the string variable 
                                    //'input' relayed into the string variable name 'input' attached to 'RunMainMenu' for subsequent use.
    {

        // Set up a true/false bool called isValidLevel No which is only true if Input strings are 1 2 or 3.
        // In an if statement - a boolian needs to be true to return a true result



        bool isValidLevelNo = (input == "1" || input == "2" || input == "3" );  

        if (isValidLevelNo)
        {
            level = int.Parse(input);
            StartGame();

        }
        else
        {
            Terminal.WriteLine("Please Choose a Valid Level");
        }
    }


    void StartGame ()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
       
        switch(level)  
        {
            case 1:
                password = L1passwords[Random.Range(0, L1passwords.Length)];                              
                break;
            case 2:
                password = L2passwords[Random.Range(0, L2passwords.Length)];                
                break;
            case 3:
                password = L3passwords[Random.Range(0, L3passwords.Length)];                              
                break;
        }

        Terminal.WriteLine("");
        Terminal.WriteLine("Please Enter Your Password");

    }

    void CheckPassword (string input)
    {
       if (input == password)
        {
            Terminal.WriteLine("Correct - Well Done!" );  
        }
        else 
        {
            Terminal.WriteLine("Naaaahhhh Wrong!" );  
  
        }
    }
}
