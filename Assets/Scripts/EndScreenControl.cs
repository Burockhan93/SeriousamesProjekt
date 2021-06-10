using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenControl : MonoBehaviour
{
    public Text FinalScoreText;
    public Text BestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        //print current score
        FinalScoreText.text = Mathf.Round(StaticClass.score).ToString();

        //check if score is higher than the current highscore
        float bestScore = SaveScore.loadHighscore("overallHighscore_" + StaticClass.gameDifficulty);

        //save the score inside the PlayerPref if the score is higher
        if (bestScore < StaticClass.score)
        {
            SaveScore.saveHighscore("overallHighscore_" + StaticClass.gameDifficulty,StaticClass.score);
        }

        //show best high score
        BestScoreText.text = Mathf.Round(SaveScore.loadHighscore("overallHighscore_" + StaticClass.gameDifficulty)).ToString();
    }

}
