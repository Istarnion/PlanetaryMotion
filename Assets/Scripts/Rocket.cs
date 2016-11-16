using UnityEngine;
using System;
using System.Collections;

public class Rocket : Entity
{
    public double force = 3.9e6;

    public double fuelPerSecond = 1122;

    public double fuelMass = 20196 * 14;

    public double fuelTankMass = 10000;

    public double orbiterFuelMass = 500;

    public double orbiterMass = 500;

    public Transform model;

    void FixedUpdate()
    {
        if(velocity.LengthSquared() > 1)
        {
            transform.forward = new Vector3((float)velocity.x, 0, (float)velocity.y);
            transform.up = Vector3.up;
        }
    }

    public override Vec2d F(Entity[] planets, Vec2d pos)
    {
        Vec2d accel = new Vec2d();

        if(pos.LengthSquared() < 1)
        {
            return accel;
        }

        foreach(var other in planets)
        {
            if(other.GetMass() > 3e23)
            {
                double pow = Math.Pow(Vec2d.Distance(other.position, pos), 3);
                double gmass = G * other.GetMass();
                var offset = (other.position - pos);
                var nominator = gmass * offset;
                accel += nominator / pow;
            }
        }

        return accel;
    }

    public override double GetMass()
    {
        return fuelMass + fuelTankMass + orbiterFuelMass + orbiterMass;
    }
}
