using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour
{

    [HideInInspector]
    public Vector3 velocity;

    [HideInInspector]
    public bool dead = false;

    void Update()
    {
        if(velocity.sqrMagnitude > 0.1f)
        {
            transform.forward = velocity;
        }

        transform.position = transform.position + velocity * Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        dead = true;
    }
}

