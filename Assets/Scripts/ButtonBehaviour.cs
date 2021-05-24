using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{

    public void navigateToEndscreen()
    {
        Debug.Log("Navigate to Endscreen");
        // Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("EndScreen");
    }

    public void navigateToMenu()
    {
        Debug.Log("Navigate to Menu");
        SceneManager.LoadScene("Menu");
    }

    public void navigateToGame()
    {
        Debug.Log("Navigate to Game");
        //set curser
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        //reset the game
        GameUI.initGame();
        SceneManager.LoadScene("Game");
    }

    public void closeGame()
    {
        Debug.Log("Close Game");
        Application.Quit();
    }
}
