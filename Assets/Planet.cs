using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

    public bool sun = false;

    public double mass;

    [Tooltip("Seconds to orbit")]
    public float orbitPeriod = 5.0f;

    public float nychthemeronDuration = 1.0f; // You learn a new word every day!

    public float orbitRadius = 10;

    private float angle = 0;    // The current angle of orbit. This is in radians
    private float radiansPerSecond;

    private float theta = 0;    // The angle of rotation around the planets own axis. This is in degrees
    private float degreesPerSecond;

    void Update()
    {
        if (sun) return; // The sun doesn't move in our simulation
        
        radiansPerSecond = (2*Mathf.PI) / orbitPeriod;

        angle += radiansPerSecond * Time.deltaTime;
        if(angle >= Mathf.PI * 2)
        {
            angle -= Mathf.PI * 2;
        }

        transform.position = new Vector3(orbitRadius * Mathf.Cos(angle), 0, orbitRadius * Mathf.Sin(angle));

        degreesPerSecond = 360.0f / nychthemeronDuration;
        theta += degreesPerSecond * Time.deltaTime;
        if(theta >= 360.0f)
        {
            theta -= 360.0f;
        }

        transform.localRotation = Quaternion.Euler(new Vector3(0, theta, 0));
    }
}

