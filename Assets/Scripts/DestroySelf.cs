using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// just to make sure our explosion particle emmiters don't linger after they're done
// mohammed

public class DestroySelf : MonoBehaviour
{
    // used to remove the explosions after a certain period of time
    public float time;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject,time);
    }
}