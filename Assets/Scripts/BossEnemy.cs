using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public GameObject bullet, explosion, battery;
    public Color bulletColor;
    // shooting position
    public GameObject c;

    // sets our x and y speed
    public float xSpeed, ySpeed;
    public bool canShoot;
    // sets our firerate and health
    private float health;
    // how much score our enemies are worth
    public int score;

    BossSpawn boss;
    
    void Start()
    {
      boss =  GetComponent<BossSpawn>();
    }
    void Die()
    {
        if ((int)Random.Range(0, 5) == 0)
        {
            Instantiate(battery, transform.position, Quaternion.identity);
            // one in six chance to spawn battery
        }
        // plays our explosion particle effect
        Instantiate(explosion, transform.position, Quaternion.identity);
        // die
        Destroy(gameObject);
        // adds score onto our score variable using playerprefs
        // playerprefs is handy cause it saves it onto the computer and not just the current session
        // actually this is dumb and useless, but it works.
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        boss.BossSpawned = 0;
        print("BossDed");
        

        // maybe play a sound?
    }

    // if they take damage, reduce health, if health at 0, die function. 
    public void Damage()
    {
        health--;
        if (health == 0)
        {
            Die();
        }
    }

    // spawns a bullet at our c location and flips the direction from the bullet script. 
    void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(bullet, c.transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();

        // lets us change our instantiated bullets color
        // fyi you need to change the alpha to be able to see the bullets,  
        // unity ain't smart enough to do that on its own.
        temp.GetComponent<Bullet>().ChangeColor(bulletColor);
    }

}
