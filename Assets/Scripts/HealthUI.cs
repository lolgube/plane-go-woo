using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// this script gets our health variable from spaceship.cs
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

    // this is for the multiple sprite heart, orb, health thingy
    //public Image[] orbs = new Image[healthArrayLenght];
    // ^ that is illegal, very illegal.
    public Image[] healthSlots;
    public Sprite fullHealth;
    public Sprite emptyHealth;

    private void godHelpMe() {
        // you can not get a static field to appear in the inspector without some black magic. 
        // so now i'm kinda fucked 
        //[SerializeField] public static int healthArrayLenght; 

        // looking into it, arrays can not be "dynamic" in the slightest. 
        // if i want an array with 20 items at most, that's what it's going to have to be set to.
        // my best shot is having an array with the max amount of slots, and then creating a new array
        // of the actual amount of health the player inputs, and then using that instead.
        // so letting the player choose how much health they start with is a no no since this'll take too long


        // i am fucking brain damaged i swear to god.
        // what the above text is asking is EXCACTLY what our for loop below does.
        // i just wasted so much time. oh my god
        // i manage to impress myself by doing exactly what i want and then forgetting about it

        // on a positive note at least i learned a bit about arrays.
    }

    void Update() {
        healthCounter = SpaceShip.health;
        healthText.text = healthCounter.ToString();
        //print("fuck");

        // the for loop is there to make this run for as much health as we have in the array
        // every time we check if i is smaller than the amount of health our player has
        // if it's smaller, then we want the heart to be visible
        // if it's bigger, we want to hide those hearts. 

        // in practice, it hides the hearts in the array until we have that much health
        // potential issue is that the player might get more health than we have in our array
        // so like, fix that >.>
        for (int i = 0; i < healthSlots.Length; i++) {
            if(i < healthCounter){
                healthSlots[i].enabled = true;
            } else {
                healthSlots[i].enabled = false;
            }
        }
    }
}