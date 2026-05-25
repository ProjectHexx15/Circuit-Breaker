using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level1"); // loads the Level1 scene for the player
    } // end of play

    public void Help()
    {
        SceneManager.LoadScene("Help"); // loads the help scene for the player
    } // end of help

    public void Credits()
    {
        SceneManager.LoadScene("Credits"); // loads the credits scene for the player
    } // end of credits

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // loads the mainmenu scene for the player
    } // end of mainmenu

    public void QuitGame()
    {
        Application.Quit(); //quits the application when the button is pressed
    } // end of quit game

} // end of class
