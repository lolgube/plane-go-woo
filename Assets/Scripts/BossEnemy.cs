using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Elio
public class BossEnemy : MonoBehaviour
{
    public GameObject explosion, battery;
    public static bool bossDying;

    // sets boss health
    public int bossHealth;
    // how much score our enemies are worth
    public int score;

    public Animator bossDeathAnimator;
    public BossSpawnBar bar;
    
    void Start()
    {
        bossDying = false;
        GetComponent<BossSpawn>();
       bar = GetComponent<BossSpawnBar>();
    }
    void Update()
    {
        if (bossHealth <= 0 && bossDying == false)
        {
            StartCoroutine(BossDie());
            bossDying = true;
        }
    }
    IEnumerator BossDie()
    {
        //Starts death animation and waits two seconds
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

        //Makes another boss spawn when you gather 10000 points after bosses death 
        BossSpawn.bossScoreSpawner = PlayerPrefText.score + 10000;
        //drar ner bossspawnslidern till början -Alfred
       // bar.setScore(0);
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
