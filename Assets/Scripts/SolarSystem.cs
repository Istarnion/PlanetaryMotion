using UnityEngine;
using System;
using System.Collections;

public class SolarSystem : MonoBehaviour
{

    public double timeMultiplier = 1;

    public Entity[] entities;

    public bool useEuler;
    public int numSteps = 100;

    void FixedUpdate()
    {
        Step(Time.fixedDeltaTime * Math.Pow(60.0, useEuler? 3 : 1) * timeMultiplier);
    }

    public void Step(double h)
    {
        if(useEuler)
        {
            EulerStep(h, numSteps);
        }
        else
        {
            RungeKuttaStep(h, numSteps);
        }
    }

    private void EulerStep(double h, int n)
    {
        h /= n;

        for(int step=0; step<n; ++step)
        {
            foreach(var e in entities)
            {
                e.position = e.position + e.velocity * h;
                e.velocity = e.velocity + e.F(entities, e.position) * h;
            }
        }
    }

    private void RungeKuttaStep(double h, int n)
    {
        h /= n;

        Vec2d s11, s12, s21, s22, s31, s32, s41, s42;

        for(int i=0; i<n; ++i)
        {
            foreach(var e in entities)
            {
                s11 = e.velocity * h;
                s12 = e.F(entities, e.position) * h;
                s21 = e.velocity + h / 2 * s11;
                s22 = e.F(entities, e.position + s12 * h/2);

                s31 = e.velocity + h / 2 * s21;
                s32 = e.F(entities, e.position + s22 * h/2);

                s41 = e.velocity + h * s31;
                s42 = e.F(entities, e.position + s32 * h);

                e.position = e.position + h / 6 * (s11 + 2*s21 + 2*s31 + s41);
                e.velocity = e.velocity + h / 6 * (s12 + 2*s22 + 2*s32 + s42);
            }
        }
    }
}
