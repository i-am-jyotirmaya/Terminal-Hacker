using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    int level;
    enum Screen
    {
        MainMenu, WaitingForPassword, Win
    }

    Screen currentScreen = Screen.MainMenu;

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
    }

    private void RunMainMenu(string input)
    {
        if (input == "1" || input == "2" || input == "3")
        {
            level = int.Parse(input);
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please select a valid level!");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.WaitingForPassword;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Enter your password: ");
    }
}
