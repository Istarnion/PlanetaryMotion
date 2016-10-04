using UnityEngine;
using System.Collections;

public class SliderScript : MonoBehaviour {

    public void OnSliderChange(float value)
    {
        Planet.timeMultiplier = value;
    }
}
