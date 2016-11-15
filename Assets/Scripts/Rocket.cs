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
            model.transform.forward = new Vector3((float)velocity.x, 0, (float)velocity.y);
        }
    }

    public override Vec2d F(Entity[] planets, Vec2d pos)
    {
        Vec2d accel = new Vec2d();

        foreach(var other in planets)
        {
            if(other.GetMass() > 3e23)
            {
                accel += G * other.GetMass() * (other.position - pos) / Math.Pow(Vec2d.Distance(other.position, pos), 3);
            }
        }

        return accel;
    }

    public override double GetMass()
    {
        return fuelMass + fuelTankMass + orbiterFuelMass + orbiterMass;
    }
}
