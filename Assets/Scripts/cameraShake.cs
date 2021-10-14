using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    //hur snabbt kameran ska skaka i x respektive y led -Alfred
    public Vector2 frekvens;
    //hur l�ngt kameran ska r�ra sig n�r den skakar i x respektive y led -Alfred
    public Vector2 amplitude;
    //hur l�nge den skakar med frekvensen -Alfred
    Vector2 time;
    //bool som kollar om man ska skaka -Alfred
    public bool shouldShake;
    //timer f�r hur l�nge man ska skaka -Alfred
    public float timer;

    private void Update()
    {
        //positionen f�r objektet som ska skaka -Alfred
        Vector3 shakePos = transform.localPosition;
        //multipliserar frekvensen med tid s� man kan f� den att skaka
        time.x += Time.deltaTime * frekvens.x;
        time.y += Time.deltaTime * frekvens.y;

        timer -= Time.deltaTime;

        if (timer > 0)
        {
            shouldShake = true;
        }
        else
        {
            shouldShake = false;
        }
        if (shouldShake == true)
        {
            shakePos = new Vector3(Mathf.Sin(time.x) * amplitude.x, Mathf.Sin(time.y) * amplitude.y, 0);
        }
        if (shouldShake == false)
        {
            shakePos = Vector3.zero;
        }
        transform.localPosition = shakePos;
    }

    public void Shake(float timeToShake)
    {
        timer = timeToShake;
        print("shake");
        
    }
}
