using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

    public double mass;

    [Tooltip("Seconds to orbit")]
    public float orbitPeriod = 5.0f;

    public float nychthemeronDuration = 1.0f; // You learn a new word every day!

    public float orbitRadius = 10;

    private float angle;    // The current angle of orbit
    private float radiansPerSecond;

    private float theta;    // The angle of rotation around the planets own axis
    private float thetaIncPerSecond;

    void Update()
    {
        radiansPerSecond = orbitPeriod / (2*Mathf.PI);

        angle += radiansPerSecond * Time.deltaTime;

        transform.position = new Vector3(orbitRadius * Mathf.Cos(angle), 0, orbitRadius * Mathf.Sin(angle));

        thetaIncPerSecond = nychthemeronDuration / (2 * Mathf.PI);
        theta += thetaIncPerSecond * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(new Vector3(0, theta, 0));
    }
}

