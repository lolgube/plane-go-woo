using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonStuff : MonoBehaviour
{
    // used for main menu, loads ur cutscene
    public void Play() {
        SceneManager.LoadScene(1);
        Debug.Log("clicked play");
    }

    // simple quit button
    public void Quit() {
        Application.Quit();
    }

    // skips our cutscene (which might not even exist tbh), loads our game
    public void Skip() {
        Debug.Log ("Skip Cutscene");
        SceneManager.LoadScene(2);
    }
}
