using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// by mohammed

// Scene build index.
// main menu (0)
// elins animation scen(1)
// level1(2)
// endanimation(3)
// level0(5)

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

// pause on esc hit (also checks that the options menu isn't open so that it doesn't open ontop of each other)
    void Update() {
            if(Input.GetKeyDown(KeyCode.Escape)){
                if (GameIsPaused){
                    Resume();
                    } else{
                    Pause();
                }
            }
    }
// continue time
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        // // enable movement script
        // GameObject vargameobject = GameObject.Find("player9308");
        // vargameobject.GetComponent<movment2>().enabled = true;
        
        // // enable sword script
        // GameObject _vargameobject = GameObject.Find("GameObject (2)");
        // _vargameobject.GetComponent<sword>().enabled = true;
        GameIsPaused = false;
    }

// pause time
    void Pause (){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        // // disable movement script
        // GameObject vargameobject = GameObject.Find("player9308");
        // vargameobject.GetComponent<movment2>().enabled = false;

        // // disable sword script
        // GameObject _vargameobject = GameObject.Find("GameObject (2)");
        // _vargameobject.GetComponent<sword>().enabled = false;
        GameIsPaused = true;
    }

//gtfo
    public void QuitGame(){
        Debug.Log ("quit on pause menu");
        Application.Quit();
    }

// return to main menu
    public void LoadMenu(){
        Debug.Log ("Loading menu");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}