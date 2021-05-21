using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// gives our text a cool typewriter effect
// this is very last minute 

public class TypewriterText : MonoBehaviour
{
    public  float textSpeed = 0.1f;
    public string entireText;
    private string currentText = "";
    
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(ShowText());
        StartCoroutine(CutsceneTime());
    }

    // Update is called once per frame
    IEnumerator ShowText() {
        // when i is less than the lenght of our entire text, increase i
        // our current text = our entire text, starting from 0 going to i
        // get our component
        // wait until delay has happend, then return
        for (int i = 0; i < entireText.Length; i++) {
            currentText = entireText.Substring(0,i);
            this.GetComponent<TMP_Text>().text = currentText;
            yield return new WaitForSeconds(textSpeed);
        }
    }

// after 28 seconds, load the next scene
    IEnumerator CutsceneTime(){
        yield return new WaitForSeconds(28);
        SceneManager.LoadScene(2);
    }
}
