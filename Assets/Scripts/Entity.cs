using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour
{
    public Vector2 position;

    public Vector2 velocity;

    public abstract double GetMass();

    public static float scale = 1.0f;

    public const double G = 6.674e-9;

    void Awake()
    {
        position.x = transform.position.x * scale;
        position.y = transform.position.z * scale;
    }

    void Update()
    {
        transform.position = new Vector3(position.x / scale, 0, position.y / scale);
    }

    public abstract Vector2 F(Entity[] entities, Vector2 pos);
}
