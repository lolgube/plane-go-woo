using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// by mohammed
// technically there's already some of this stuff in healthui.cs that makes this entire script redundant
// but yeah, not touching that for this one thing

public class ExtraHealthUI : MonoBehaviour
{
    
    // real hp
    int hpReference;
    // hp that we display (so it's just normal hp -6. so that it shows as +1 when you have 7 hp)
    int displayHP;
    [SerializeField]
    GameObject textThingObject;
    [SerializeField]
    TMP_Text text;

    // Start is called before the first frame update
    void Awake() {
        // turns off the text if it's active. 
        if(textThingObject.activeInHierarchy){
            textThingObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update() {
    hpReference = SpaceShip.health;
    displayHP = hpReference - 6;
    //print(hpReference);
        if(hpReference < 5){
            // turns off the text if hp is less or eqqual to five. 
            textThingObject.SetActive(false);
            // print("hp is less than 5 and set to false");
        }
        else if(hpReference > 6){
            // turns on the text if hp is more than 5 (more or equal to 6). 
            textThingObject.SetActive(true);
            // print("hp is more than 5 and set to true");

            text.text = "+" + displayHP.ToString();

        }
    }
}
