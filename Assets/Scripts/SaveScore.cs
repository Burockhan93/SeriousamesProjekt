using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveScore
{
    //class to save the highscore into the player prefences
    //the highscore is saved by key/value
    //the key is overallHighscore_<GAME_MODE> to save a highscore for each different mode
    public static void saveHighscore(string key, float score)
    {
        PlayerPrefs.SetFloat(key, score);
        PlayerPrefs.Save();
        Debug.Log("Highscore data saved!");
    }

    public static float loadHighscore(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            Debug.Log("Game data loaded!");
            return PlayerPrefs.GetFloat(key);
        }
        else {
            Debug.LogError("There is no highscore data!");
            return 0f;
        }
    }

}
