using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWarning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(DestroyWarningSoon());
    }
    IEnumerator DestroyWarningSoon()
    {
        yield return new WaitForSecondsRealtime(4f);
        Destroy(gameObject);
    }
}
