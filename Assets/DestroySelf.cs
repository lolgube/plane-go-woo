using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    // used to remove the explosions after a certain period of time
    public float time;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject,time);
    }
}
