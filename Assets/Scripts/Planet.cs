using UnityEngine;
using System;
using System.Collections;

public class Planet : Entity
{
    public double mass;

    public double rotationTime;

    public override double GetMass()
    {
        return mass;
    }

    public override Vec2d F(Entity[] entities, Vec2d pos)
    {
        Vec2d accel = new Vec2d(0, 0);

        foreach(var other in entities)
        {
            if(other.GetMass() > 3e23) // Only accelerate towards planets
            {
                if(!pos.Equals(other.position))
                {
                    double pow = Math.Pow(Vec2d.Distance(other.position, pos), 3);
                    double gmass = G * other.GetMass();
                    var offset = (other.position - pos);
                    var nominator = gmass * offset;
                    accel += nominator / pow;
                }
            }
        }

        return accel;
    }
}
