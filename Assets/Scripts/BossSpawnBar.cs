using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSpawnBar : MonoBehaviour
{
    public Slider slider;//vilken slider vi vill ska �ndras
    

    public void setScore(int score)//funktion med en int -Alfred
    {
        slider.value = score;//s�tter slidern p� det v�rdet vi vill (score) - Alfred
    }
}
