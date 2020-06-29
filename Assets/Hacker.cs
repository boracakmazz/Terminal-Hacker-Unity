

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hacker : MonoBehaviour {

    int level;
    string password;
    string [] level_1_passwords = { "book", "lecture", "professor", "grade", "education", "attendance" };
    string [] level_2_passwords = { "file", "badge", "dispatch", "database", "investigation", "tracking", "federal" };
    string [] level_3_passwords = { "weapon", "extraterrestial", "defcon", "experiment", "conspiracy", "president", "strategy" };

    enum Screen { MainMenu , Password , Win };
    Screen currentScreen = Screen.MainMenu;

    // Use this for initialization
    void Start () {
         ShowMainMenu();
        
    }
	
    void ShowMainMenu(){
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to DECV52 Terminal User...\n");
        Terminal.WriteLine("Press 1 to access University's System\n");
        Terminal.WriteLine("Press 2 to access FIB's Database\n");
        Terminal.WriteLine("Press 3 to access Departmant of Defense\n");
        Terminal.WriteLine("User's choose:");
        
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            if (input == password)
                DisplayWinScreen();
            else
                Terminal.WriteLine("Incorrect Password");
        }
    }

     void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        showLevelReward();
    }

    void showLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/           
"
                );
                break;
            case 2:
                Terminal.WriteLine("Feds are going to bust you kid..You should stop.");
                Terminal.WriteLine(@"

★   ★   ★   ★   ★"



);
                break;
        

            case 3: 
            Terminal.WriteLine("Men in black are on the way ");
        Terminal.WriteLine(@"
           _______
          /       \
    _____/---------\_____
    \                   /
     \_________________/
");
        break;

            default:
                Debug.Log("Invalid level reached");
                break;

        }
    }

            

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else
            Terminal.WriteLine("Your input is invalid,please try again");
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        setRandomPassword();

        Terminal.WriteLine("Please enter your password : " + password.Anagram());
    }

    private void setRandomPassword()
    {
        switch (level)
        {
            case 1:

                password = level_1_passwords[Random.Range(0, level_1_passwords.Length)];
                break;
            case 2:

                password = level_2_passwords[Random.Range(0, level_2_passwords.Length)];
                break;
            case 3:

                password = level_3_passwords[Random.Range(0, level_3_passwords.Length)];
                break;
            default:
                Debug.LogError("Unauthorized entry detected");
                break;
        }
    }
}
