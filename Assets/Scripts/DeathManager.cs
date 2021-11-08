using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// written by mohammed, wasn't changed in this project (i think?)

public class DeathManager : MonoBehaviour
{
    GameObject player;
    bool gameOver = false;

    void Start() {
        // gets our player
        player = GameObject.FindGameObjectWithTag("Player");
    }

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
