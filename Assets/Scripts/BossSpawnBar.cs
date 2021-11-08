using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSpawnBar : MonoBehaviour
{
    public Slider slider;//vilken slider vi vill ska ändras
    

    public void setScore(int score)//funktion med en int -Alfred
    {
        slider.value = score;//sätter slidern på det värdet vi vill (score) - Alfred
    }
}
