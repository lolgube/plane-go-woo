using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWarning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BossSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        //Makes it so that warning is destroyed in time with the boss if the boss dies
        if (BossEnemy.bossDying == true)
        {
            StartCoroutine(DestroyWarningSoon());
        }
    }
    IEnumerator DestroyWarningSoon()
    {
        //Destroys the attack warning
        yield return new WaitForSecondsRealtime(2f);
        Destroy(gameObject);
    }
}
