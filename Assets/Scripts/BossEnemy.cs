using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public GameObject explosion, battery;
    public bool bossDying;


    // sets boss health
    public int bossHealth;
    // how much score our enemies are worth
    public int score;

    public Animator bossDeathAnimator;
    
    void Start()
    {
        bossDying = false;
        GetComponent<BossSpawn>();
    }
    void Update()
    {
        if (bossHealth == 0 && bossDying == false)
        {
            StartCoroutine(BossDie());
            bossDying = true;
        }
    }
    IEnumerator BossDie()
    {
        bossDeathAnimator.SetBool("BossDeath", true);
        yield return new WaitForSecondsRealtime(2f);
        //Spawns a battery when boss dies
        Instantiate(battery, transform.position, Quaternion.identity);

        // plays our explosion particle effect
        Instantiate(explosion, transform.position, Quaternion.identity);

        // adds score onto our score variable using playerprefs
        // playerprefs is handy cause it saves it onto the computer and not just the current session
        // actually this is dumb and useless, but it works.
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);

        //Makes it so that another boss can spawn
        BossSpawn.bossSpawned = 0;
        // die
        Destroy(gameObject);
        

        // maybe play a sound?
    }

    // if they take damage, reduce health, if health at 0, die function. 
    public void Damage()
    {
        bossHealth--;
    }

    

}
