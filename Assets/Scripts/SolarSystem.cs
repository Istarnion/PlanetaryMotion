using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Collections;

public class SolarSystem : MonoBehaviour
{

    public double timeMultiplier = 1;

    public Entity[] entities;

    private bool useEuler = true;
    public int numSteps = 100;

    public Text gui;

    public double time = 0;

    private StringBuilder stringBuilder = new StringBuilder();

    void FixedUpdate()
    {
        stringBuilder.Remove(0, stringBuilder.Length);

        Step(10800 * timeMultiplier);

        gui.text = stringBuilder.ToString();
    }

    public void Step(double h)
    {
        time += h;
        stringBuilder.Append(string.Format("Tid: {0:0.00} dager\n", SecondsToDays(time)));
        stringBuilder.Append(string.Format("h: {0} s\n", h/numSteps));

        if(useEuler)
        {
            var doublePrecisionPos = EulerEarthError(h, numSteps);
            EulerStep(h, numSteps);
            var error = (doublePrecisionPos - entities[3].position).Length();

            stringBuilder.Append(string.Format("Feil i jordas posisjon: {0:0.00} km\n", error * 10.0e-3));
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

        double halfh = h / 2.0;

        Vec2d s1p, s2p, s3p, s4p;
        Vec2d s1v, s2v, s3v, s4v;

        for(int i=0; i<n; ++i)
        {
            foreach(var e in entities)
            {
                s1v = e.velocity;
                s1p = e.F(entities, e.position);

                s2v = e.velocity + h / 2 * s1p;
                s2p = e.F(entities, e.position + s1v * h/2);

                s3v = e.velocity + h / 2 * s2p;
                s3p = e.F(entities, e.position + s2v * h/2);

                s4v = e.velocity + h * s3p;
                s4p = e.F(entities, e.position + s3v * h);

                e.position = e.position + (h / 6) * (s1p + 2 * s2p + 2 * s3p + s4p);
                e.velocity = e.velocity + (h / 6) * (s1v + 2 * s2v + 2 * s3v + s4v);
            }
        }
    }

    private Vec2d EulerEarthError(double h, int n)
    {
        n *= 2;
        h /= n;

        var earth = entities[3];
        var pos = earth.position;
        var vel = earth.velocity;

        for(int step=0; step<n; ++step)
        {
            pos = pos + vel * h;
            vel = vel + earth.F(entities, pos) * h;
        }

        return pos;
    }

    public void UseEuler(bool b)
    {
        useEuler = b;
    }

    public void UseRungeKutta(bool b)
    {
        useEuler = !b;
    }

    private double SecondsToDays(double s)
    {
        return s / (3600.0 * 24.0);
    }
}
