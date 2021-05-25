using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveScore
{
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
