using UnityEngine;
using System.Collections;

public class SliderScript : MonoBehaviour {

    public SolarSystem solarSystem;

    public void OnSliderChange(float value)
    {
        solarSystem.timeMultiplier = value;
    }
}
