using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    //hur snabbt kameran ska skaka i x och y led -Alfred
    public Vector2 frekvens;
    //hur långt kameran ska röra sig när den skakar i x re
    public Vector2 amplitude;
    Vector2 time;
    public bool shouldShake;
    public float timer;
    public Camera cam;
   
    public void Shake()
    {
        print("shake");
        Vector3 shakePos = cam.transform.localPosition;
        time.x += Time.deltaTime * frekvens.x;
        time.y += Time.deltaTime * frekvens.y;
        timer += Time.deltaTime;
        //när timern är mer en 0


        if (timer > 0 && timer < 0.4)
        {
            shouldShake = true;
        }
        else
        {
            shouldShake = false;
        }
        if (shouldShake)
        {
            shakePos = new Vector3(Mathf.Sin(time.x) * amplitude.x, Mathf.Sin(time.y) * amplitude.y, 0);
        }
        else
        {
            shakePos = Vector3.zero;
        }
        transform.localPosition = shakePos;
    }
}
