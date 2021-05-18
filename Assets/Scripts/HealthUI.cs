using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// don't think this is going to stay forever. 
// it gets our health variable from spaceship.cs
// the problem i ran into here was the static thingie, still not really sure what it's about.
// the solution was to make the variable static in the original script (spaceship.cs)

// i got it explained!
// so making something static is like writing it down in a library
// so if i make 100 spaceships, all of them are going to share that one
// health variable (instead of it being unique as a default)
// that cleared up a lot, thank you

public class HealthUI : MonoBehaviour {
    public TMP_Text healthText;
    public int healthCounter;

    // this is for the multiple sprite heart thingy
    //public Image[] orbs = new Image[healthArrayLenght];
    public Image[] healthSlots;
    public Sprite fullHealth;
    public Sprite emptyHealth;

    private void Awake() {
        
    }
    // you can not get a static field to appear in the inspector
    // without some black magic. so now i'm kinda fucked 
    //[SerializeField] public static int healthArrayLenght; 

    void Update() {
        healthCounter = SpaceShip.health;
        healthText.text = "health = " + healthCounter.ToString();
        //print("fuck");

        // the for loop is there to make this run for as much health as we have in the array
        // every time we check if i is smaller than the amount of health our player has
        // if it's smaller, then we want the heart to be visible
        // if it's bigger, we want to hide those hearts. 
        for (int i = 0; i < healthSlots.Length; i++) {
            if(i < healthCounter){
                healthSlots[i].enabled = true;
            } else {
                healthSlots[i].enabled = false;
            }
        }
    }
}