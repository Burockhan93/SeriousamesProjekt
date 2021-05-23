using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenControl : MonoBehaviour
{
    public Text FinalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        FinalScoreText.text = Mathf.Round(StaticClass.score).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
