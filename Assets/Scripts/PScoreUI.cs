using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PScoreUI : MonoBehaviour
{
    // if i was smarter i'd just put this in the pscore script without any 
    private void Update() { 
        // display score, d10 stands for 10 decimals, keeping it old school and cool
        GetComponent<TMP_Text>().text = SpaceShip.PScore.ToString();
        //print(score);
    }
}