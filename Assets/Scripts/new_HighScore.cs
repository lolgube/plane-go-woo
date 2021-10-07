using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// i'm creating another script because the getcomponent will get messy otherwise
/*
public class new_HighScoreText : MonoBehaviour
{
    public static int highscore;
    TMP_Text text;

    private void Start() {
        // gets our text
        text = GetComponent<TMP_Text>();
        // sets our highscore
        highscore = PlayerPrefs.GetInt ("highscore", highscore);
        // applies our higscore to the texxt
        text.text = highscore.ToString("D10");
    }

    private void Update() { 
        // if our score is higher than the high score
        if(PlayerPrefText.score > highscore){
            // set the high score to the value of the score
            highscore = PlayerPrefText.score;
            // update the text with our score
            text.text = PlayerPrefText.score.ToString("D10");
            // set our new highscore in playerprefs
            PlayerPrefs.SetInt("highscore", highscore); 
        }

        // display score, d10 stands for 10 decimals
        //GetComponent<TMP_Text>().text = score.ToString("D10");
    }
}
*/

// ok let's go

[System.Serializable]
public class new_HighScoreText {
    public static int highscore;

}
