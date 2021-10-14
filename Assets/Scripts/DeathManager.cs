using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    GameObject player;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start() {
        // gets our player
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        // if our player is dead and game over isn't true (we don't want it to keep repeating)
        if(player==null&&!gameOver){
            GameOver();
        }
    }

    void GameOver(){
        gameOver = true;
        StartCoroutine(LoadGameOver());
    }

    // once we lose, load the lose screen after 3s
    IEnumerator LoadGameOver(){
        yield return new WaitForSeconds(3f);
        SpaceShip.health = 4;
        SpaceShip.PScore = 0;
        SceneManager.LoadScene(3);
    }
}
