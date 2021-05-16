using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// don't think this is going to stay forever. 
// it gets our health variable from spaceship.cs
// the problem i ran into here was the static thingie, still not really sure what it's about.
// the solution was to make the variable static in the original script (spaceship.cs)
// so like, tobbe om du läser det här skicka ett mail som förklarar, tack :)

public class HealthUI : MonoBehaviour {
    public TMP_Text healthText;
    private int healthCounter;

    void Update() {
        healthCounter = SpaceShip.health;
        healthText.text = "health = " + healthCounter.ToString();
        //print("fuck");
    }
}