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
    // sets boss health
    public float bossHealth;
    // how much score our enemies are worth
    public int score;

    BossSpawn boss;
    public Animator bossDeathAnimator;
    
    void Start()
    {
      boss =  GetComponent<BossSpawn>();
    }
    void Die()
    {
        print("MAMMAMAMAMAMAMA");
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

        if (bossHealth == 0)
        {
            bossDeathAnimator.SetBool("BossDeath", true);
            print("Bosshealth == 0");
            Die();
        }

        // maybe play a sound?
    }

    // if they take damage, reduce health, if health at 0, die function. 
    public void Damage()
    {
        bossHealth--;
    }

    

}
