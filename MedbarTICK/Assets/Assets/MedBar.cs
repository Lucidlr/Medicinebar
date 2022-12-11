using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxMedicine(float medicine)
    {
        slider.maxValue = medicine;
        slider.value = medicine;
    }


    public void SetMedicine(float medicine)
    {
        slider.value = medicine;
    }
}
