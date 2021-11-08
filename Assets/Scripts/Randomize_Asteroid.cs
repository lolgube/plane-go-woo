using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// mohammed
// point of the script is to avoid having to use 2 different prefabs. i.e accidentally duplicating the spawnrate of asteroids
public class Randomize_Asteroid : MonoBehaviour {

    private int rand;
    public Sprite[] asteroid_sprites;

    void Start() {
        // defines random
        rand = Random.Range(0, asteroid_sprites.Length);
        // randomly sets our sprite to one in the array
        GetComponent<SpriteRenderer>().sprite = asteroid_sprites[rand]; 
    }
}
