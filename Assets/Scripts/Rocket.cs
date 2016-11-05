using UnityEngine;
using System.Collections;

public class Rocket : Entity
{
    public double force = 3.9e6;

    public double fuelPerSecond = 1122;

    public double fuelMass = 20196 * 14;

    public double fuelTankMass = 10000;

    public double orbiterFuelMass = 500;

    public double orbiterMass = 500;

    public override Vector2 F(Entity[] planets, Vector2 pos)
    {
        Vector2 accel = Vector2.zero;

        foreach(var other in planets)
        {
            accel += (float)G * (float)other.GetMass() * (other.position - pos) / Mathf.Pow(Vector2.Distance(other.position, pos), 3);
        }

        return accel;
    }

    public override double GetMass()
    {
        return fuelMass + fuelTankMass + orbiterFuelMass + orbiterMass;
    }
}
