using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{

    [SerializeField] Button buttonDefault;
    [SerializeField] Button buttonFast;
    [SerializeField] Button buttonHardcore;
    [SerializeField] GameObject GamePanel;
    [SerializeField] GameObject InstructionPanel;

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

        //reset the game
        GameUI.initGame();
       
        SceneManager.LoadScene("Game");
    }

    public void closeGame()
    {
        Debug.Log("Close Game");
        Application.Quit();
    }

    public void selectDefaultGamemode()
    {
        buttonDefault.interactable = false;
        buttonFast.interactable = true;
        buttonHardcore.interactable = true;

        StaticClass.gameDifficulty = 1;
        Debug.Log("Select gameMode Default");
        navigateToGame();
    }
    public void selectFastGamemode()
    {
        buttonDefault.interactable = true;
        buttonFast.interactable = false;
        buttonHardcore.interactable = true;

        StaticClass.gameDifficulty = 2;
        Debug.Log("Select gameMode Fast");
        navigateToGame();
    }
    public void selectHardcoreGamemode()
    {
        buttonDefault.interactable = true;
        buttonFast.interactable = true;
        buttonHardcore.interactable = false;

        StaticClass.gameDifficulty = 3;
        Debug.Log("Select gameMode Hardcore");
        navigateToGame();
    }

    public void startGame()
    {
        Debug.Log("Start Game");

        GamePanel.gameObject.SetActive(true);
        InstructionPanel.gameObject.SetActive(false);
        
        StaticClass.runGame = true;

        //set curser
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
}
