using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject Sprite;
    private float timer = 0.0f;
    public bool appear = false;
    public bool disappear = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer == 1)
        {
            if(disappear == true)
            {
                Sprite.SetActive(false);
                appear = true;
                disappear = false;
            }
            if(appear == true)
            {
                Sprite.SetActive(true);
                appear = false;
                disappear = true;
            }
            timer = 0;
        }
        
        

    }
}
