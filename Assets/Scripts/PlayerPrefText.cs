using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPrefText : MonoBehaviour
{
    // why is this here??
    public string name;

    // gets our text, sets it as the playerpref "score"
    void Update() {
        GetComponent<TMP_Text>().text=PlayerPrefs.GetInt("Score")+"";
    }
}
