using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Floating_health_Bar : MonoBehaviour
{
    [SerializeField] private Slider Slider;

    private void Update()
    {
        
    }


    public void UpdateHealthBar(float Currentvalue, float maxvalue)
    {
        Slider.value = Currentvalue / maxvalue;
    }
}
