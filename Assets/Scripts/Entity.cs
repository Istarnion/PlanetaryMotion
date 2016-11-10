using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour
{
    public Vec2d position;

    public Vec2d velocity;

    public abstract double GetMass();

    public static double scale = 1e-10;

    public const double G = 6.674e-11;

    void Update()
    {
        if(position.x != 0 && position.y != 0)
        {
            transform.position = new Vector3((float)(position.x * scale), 0, (float)(position.y * scale));
            // Debug.Log(string.Format("{0}: x: {1}, y: {2}\n\tX: {3}, Y: {4}", gameObject.name, position.x, position.y, transform.position.x, transform.position.y));
        }
    }

    public abstract Vec2d F(Entity[] entities, Vec2d pos);
}
