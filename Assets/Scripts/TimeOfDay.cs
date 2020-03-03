using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOfDay : MonoBehaviour
{
    public Animation MainLight;
    Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        slide = this.GetComponent<Slider>();
        MainLight.Play("sun");
        MainLight["sun"].speed = 0;
        slide.value = 0.5f;
        AnimateOnSliderChange();
    }

    public void AnimateOnSliderChange()
    {
        MainLight["sun"].normalizedTime = slide.value;

    }
}
