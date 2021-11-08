using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSpawnBar : MonoBehaviour
{
    public Slider slider;
    

    public void setScore(int score)
    {
        slider.value = score;
    }
}
