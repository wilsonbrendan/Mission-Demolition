using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    static public int bestScore;

    void Awake()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
        }

        PlayerPrefs.SetInt("BestScore", bestScore);
    }
    
    // Update is called once per frame
    void Update()
    {
       Text gt = this.GetComponent<Text>();
       gt.text = "Best Attempt: " + bestScore;
       if (bestScore < PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }
}
