using UnityEngine;
using System.Collections;

public class Planet : Entity
{
    public double mass;

    public override double GetMass()
    {
        return mass;
    }

    public override Vector2 F(Entity[] entities, Vector2 pos)
    {
        Vector2 accel = Vector2.zero;

        foreach(var other in entities)
        {
            if(pos != other.position)
            {
                accel += (float)G * (float)other.GetMass() * (other.position - pos) / Mathf.Pow(Vector2.Distance(other.position, pos), 3);
            }
        }

        return accel;
    }
}
