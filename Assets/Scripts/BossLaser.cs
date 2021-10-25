using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public GameObject thickLaserWall;
    public GameObject attackWarning;
    public int wallXPositionRandom;
    public bool spawningAttack = false;
    public int chooseLaser;

    //Creates array for x position
    public GameObject[] thinLaser;
    public int[] warningPosition;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Checks if an attack is spawning
        if (spawningAttack == false)
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
        //Waits for 5-10 seconds
        yield return new WaitForSecondsRealtime(Random.Range(3, 8));
        //Chooses one of three positions for the attack warning and attack to spawn
        wallXPositionRandom = Random.Range(0, 3);
        
        chooseLaser = Random.Range(0, 2);
        //Spawns an attack warning randomly in one of three positions
        GameObject warning = Instantiate(attackWarning, new Vector2(warningPosition[wallXPositionRandom], 0), Quaternion.identity);
        //Waits for 2 seconds
        yield return new WaitForSecondsRealtime(4f);
        //Spawns laserwallattack in the same x position as the attack warning
        if(chooseLaser == 1)
        {
            Instantiate(thickLaserWall, new Vector2(warningPosition[wallXPositionRandom], 20), Quaternion.identity);
        }
        else
        {
            Instantiate(thinLaser[wallXPositionRandom]); 
        }
        //Destroys attack warning
        Destroy(warning);

        //Ends the spawning so that another attack can start spawning
        spawningAttack = false;
    }

}
