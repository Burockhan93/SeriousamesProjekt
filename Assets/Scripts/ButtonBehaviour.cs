using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{

    public void navigateToEndscreen()
    {
        Debug.Log("Navigate to Endscreen");
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
        SceneManager.LoadScene("Game");
    }

    public void closeGame()
    {
        Debug.Log("Close Game");
        Application.Quit();
    }
}
