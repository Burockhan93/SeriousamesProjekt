using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveScore
{
    public static void saveHighscore(float score)
    {
        PlayerPrefs.SetFloat("overallHighscore", score);
        PlayerPrefs.Save();
        Debug.Log("Highscore data saved!");
    }

    public static float loadHighscore()
    {
        if (PlayerPrefs.HasKey("overallHighscore"))
        {
            Debug.Log("Game data loaded!");
            return PlayerPrefs.GetFloat("overallHighscore");
        }
        else {
            Debug.LogError("There is no highscore data!");
            return 0f;
        }
    }

}
