using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPrefText : MonoBehaviour
{
    // why is this here??  (think it not being here broke something before so just ignore it i guess)
    //public string name;

    public static int score;

    // gets our text, sets it as the playerpref "score"
    private void Update() { 
        // get score
        score = PlayerPrefs.GetInt("Score");

        // display score, d10 stands for 10 decimals, keeping it old school and cool
        GetComponent<TMP_Text>().text = score.ToString("D10");
        //print(score);
    }
}