using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class PåskÄgg : MonoBehaviour
{
    //static int betyder att den sparar värdet till olika scener
    public static int mio;
    // Start is called before the first frame update
    void Start()
    {
        mio = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //om man trycker ner M,I,O i menyn så blir int mio 1 vilket startar ett easteregg
        if (Input.GetKey(KeyCode.M))
        {
            print("M");
            if(Input.GetKey(KeyCode.I))
            {
                print("I");
                if(Input.GetKey(KeyCode.O))
                {
                    print("Mio min Elio");
                    mio = 1;
                }
            }
        }
    }
}
