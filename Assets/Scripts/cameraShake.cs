using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    //hur snabbt kameran ska skaka i x respektive y led -Alfred
    public Vector2 frekvens;
    //hur långt kameran ska röra sig när den skakar i x respektive y led -Alfred
    public Vector2 amplitude;
    //hur länge den skakar med frekvensen -Alfred
    Vector2 time;
    //bool som kollar om man ska skaka -Alfred
    public bool shouldShake;
    //timer för hur länge man ska skaka -Alfred
    public float timer;

    private void Update()
    {
        //positionen för objektet som ska skaka -Alfred
        Vector3 shakePos = transform.localPosition;
        //multipliserar frekvensen med tid så man kan få den att skaka
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
