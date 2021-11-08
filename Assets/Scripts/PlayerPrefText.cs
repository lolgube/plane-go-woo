using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPrefText : MonoBehaviour
{
    public static int score;
    public BossSpawnBar bar;

    private void Awake() {
        score = 0;
    }

    // gets our text, sets it as the playerpref "score"
    public void Update() { 
        // get score
        score = PlayerPrefs.GetInt("Score");

        // display score, d10 stands for 10 decimals, keeping it old school and cool
        GetComponent<TMP_Text>().text = score.ToString("D10");
        //print(score);

        // debug 3
        if(Input.GetKeyDown(KeyCode.K)){
            PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+ 1000);
            //print("ligma");
        }
        //bar.setScore(score);
    }
}