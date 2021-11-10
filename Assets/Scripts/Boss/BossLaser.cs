using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * detta är för att bossen ska skjuta
 */
public class BossLaser : MonoBehaviour
{
    public GameObject thickLaserWall;
    public GameObject attackWarning;
    public SpriteRenderer bossSpriteRenderer;
    public Animator bossAnimator;
    public int wallXPositionRandom;
    public bool spawningAttack = false;
    public int chooseLaser;


    //Creates array for x position and choosing different thin lasers
    public GameObject[] thinLaser;
    public int[] warningPosition;

    

    // Start is called before the first frame update
    void Start()
    {
        bossAnimator.SetBool("BossAttackAnimation", false);
        spawningAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks if an attack is spawning
        if (spawningAttack == false && PauseMenu.GameIsPaused == false)
        {
            //Spawns attack if no attack is already spawning
            StartCoroutine(BossLazerAttack());
        }

        
    }


    //Method for the laser attack
    IEnumerator BossLazerAttack()
    {
        //Shows that attack is spawning
        spawningAttack = true;
        yield return new WaitForSecondsRealtime(Random.Range(1, 6));
        //Chooses one of three positions for the attack warning and attack to spawn
        wallXPositionRandom = Random.Range(0, 3);
        //Randomly chooses which of the lasers that will spawn
        chooseLaser = Random.Range(0, 2);
        //Spawns an attack warning randomly in one of three positions
        GameObject warning = Instantiate(attackWarning, new Vector3(warningPosition[wallXPositionRandom], 0, 1), Quaternion.identity);
        //Waits for 4 seconds
        yield return new WaitForSecondsRealtime(4f);

        //Does attack animation
        bossAnimator.SetBool("BossAttackAnimation", true);
        //Spawns one of two different laserwallattacks in the same x position as the attack warning
        if(chooseLaser == 1)
        {
            GameObject thickLaserClone = Instantiate(thickLaserWall, new Vector3(warningPosition[wallXPositionRandom], 20, 1), Quaternion.identity);
            //Makes it so that if the boss attacks in the middle it will use a short attack instead of the big one since the big laser one can collide with the bosses hitbox
            if(wallXPositionRandom == 1)
            {
                Destroy(thickLaserClone);
                Instantiate(thinLaser[wallXPositionRandom]);
            }
        }
        else
        {
            Instantiate(thinLaser[wallXPositionRandom]); 
        }
        //Destroys attack warning and ends the attack animation after two seconds
        Destroy(warning);
        yield return new WaitForSecondsRealtime(2);
        bossAnimator.SetBool("BossAttackAnimation", false);

        //Ends the spawning so that another attack can start spawning
        spawningAttack = false;
    }

}
