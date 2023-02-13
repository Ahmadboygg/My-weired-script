using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private float speed = 0.1f;

    public void sliderValueUp()
    {
        slider.value += speed;
    }

    public void sliderValueDown()
    {
        slider.value -= speed;
    }
}
