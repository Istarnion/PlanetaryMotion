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
        }
    }

    public abstract Vec2d F(Entity[] entities, Vec2d pos);
}
