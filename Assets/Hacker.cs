using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configuration Data
    string menuHint = "You may type \'menu\' at any time.";
    string[] level1passwords = { "books", "aisle", "library", "password", "study", "computer", "knowledge" };
    string[] level2passwords = { "prisoner", "holster", "nuclear", "psychopath", "weaponary", "murderer", "homicide" };
    string[] level3passwords = { "ballistic", "aeronautics", "propulsion", "bureaucracy", "observatory", "spaceflight", "terraform" };

    // Game State
    int level;
    enum Screen
    {
        MainMenu, WaitingForPassword, Win
    }
    Screen currentScreen = Screen.MainMenu;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?\n\nPress 1 for the local library\nPress 2 for the police station\nPress 3 for NASA\nType 'menu' to refresh menu\n\nEnter your selection: ");
    }

    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowMainMenu();
        } 
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.WaitingForPassword)
        {
            CheckPassword(input);
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please select a valid level!");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.WaitingForPassword;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password (Hint: " + password.Anagram() + "): \n");
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1passwords[Random.Range(0, level1passwords.Length)];
                break;
            case 2:
                password = level2passwords[Random.Range(0, level2passwords.Length)];
                break;
            case 3:
                password = level3passwords[Random.Range(0, level3passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Sorry, Wrong Password");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      /,
  /      //
 /______//
(______(/
                ");
                break;
            case 2:
                Terminal.WriteLine("Carefull! Its a prison.");
                Terminal.WriteLine(@"
   __,_____
  / __.==--'
 /#(-'
 `-' Hands Up!
                ");
                break;
            case 3:
                Terminal.WriteLine("Welcome back Captain, on a mission to Saturn.");
                Terminal.WriteLine(@"
         ,MMM8&&&.
    _...MMMMM88&&&&..._
 .::'''MMMMM88&&&&&&'''::.
::     MMMMM88&&&&&&     ::
'::....MMMMM88&&&&&&....::'
   `''''MMMMM88&&&&''''`
         'MMM8&&&'
                ");
                break;
            default:
                Debug.LogError("No case specified!");
                break;
        }
        Terminal.WriteLine("WELL DONE!");
    }
}
