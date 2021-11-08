using System.Collections;
using UnityEngine;

public class BossSpawn : MonoBehaviour //Kodad av Marcus Kjellin
{
    public Transform Spawnpoint;
    public GameObject Prefab;
    public bool ShouldBossSpawn = false;
    public static int bossSpawned;

    public static int bossScoreSpawner;

    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerPrefText>(); // Hämta koden med poängen
        bossScoreSpawner = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefText.score >= bossScoreSpawner) //Om poängen är över bossScoreSpawner
        {
            //Makes it so that boss is spawned every 10000 points
            bossScoreSpawner = PlayerPrefText.score + 10000;
            //Wont spawn the boss if the points are over 10000 more than bossScoreSpawner
            //This makes it so that a lot of bosses wont spawn at once if you build up your score without killing the boss
            if(PlayerPrefText.score <= bossScoreSpawner + 10000)
            {
                ShouldBossSpawn = true; // Bossen borde spawna
            }

        }
        if(ShouldBossSpawn == true) // Om bossen borde spawna
        {
            bossSpawn(); // Spawna bossen
            
        }
    }
    void bossSpawn()
    {       
       ShouldBossSpawn = false;
       if(bossSpawned == 1) 
       {
            return; // Spawnar inte bossen om bossen redan är spawnad
       } 
        GameObject RigidPrefab;
        RigidPrefab = Instantiate(Prefab) as GameObject;
        bossSpawned = 1;// Berättar för spelet att Bossen har Spawnat

        
    }
}
