using System.Collections;
using UnityEngine;

public class BossSpawn : MonoBehaviour //Kodad av Marcus Kjellin
{
    public Transform Spawnpoint;
    public GameObject Prefab;
    public bool ShouldBossSpawn = false;
    public static int bossSpawned;
    public BossSpawnBar bar;
    public GameObject ScoreBar;
    // public GameObject explosion

    public static int bossScoreSpawner;
    public static int barScore;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerPrefText>(); // Hämta koden med poängen
        bossScoreSpawner = 10000;
        barScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefText.score >= bossScoreSpawner) //Om po�ngen �r �ver bossScoreSpawner
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
        /*   if (bossSpawned == 1)
           {
               barScore = PlayerPrefText.score - bossScoreSpawner;
           }*/
        barScore = PlayerPrefText.score;//sätter slidern till värdet av score -Alfred
        if (barScore == 10000)
        {
            ScoreBar.SetActive(false);//tar bort baren om bossen spawnar-Alfred 
            //Instantiate(explosion,transform.position,Quaternion.identity);
        }
        if(ShouldBossSpawn == true) // Om bossen borde spawna
        {
            bossSpawn(); // Spawna bossen
            
        }

        bar.setScore(barScore);
    }
    void bossSpawn()
    {       
       ShouldBossSpawn = false;
       if(bossSpawned == 1) 
       {
            return; // Spawnar inte bossen om bossen redan �r spawnad
       } 
        GameObject RigidPrefab;
        RigidPrefab = Instantiate(Prefab) as GameObject;
        bossSpawned = 1;// Ber�ttar f�r spelet att Bossen har Spawnat

        
    }
}
