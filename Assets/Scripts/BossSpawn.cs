using System.Collections;
using UnityEngine;

public class BossSpawn : MonoBehaviour //Kodad av Marcus Kjellin
{
    public Transform Spawnpoint;
    public GameObject Prefab;
    public bool ShouldBossSpawn = false;
    public int BossSpawned;

    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerPrefText>(); // H�mta koden med po�ngen
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefText.score <= 10000) //Om po�ngen �r �ver 10000
        {
            ShouldBossSpawn = true; // Bossen borde spawna
        }
        if(ShouldBossSpawn == true) // Om bossen borde spawna
        {
            bossSpawn(); // Spawna bossen
            
        }
    }
    void bossSpawn()
    {
       if(BossSpawned == 1) 
       {
            return; // Spawnar inte bossen om bossen redan �r spawnad
       } 
        GameObject RigidPrefab;
        RigidPrefab = Instantiate(Prefab) as GameObject;
        BossSpawned = 1;// Ber�ttar f�r spelet att Bossen har Spawnat
        
    }
}
