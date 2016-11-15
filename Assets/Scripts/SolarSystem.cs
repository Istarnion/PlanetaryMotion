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
        stringBuilder.Append(string.Format("h: {0} s", h));

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

        double halfh = h / 2.0;

        double x, y;
        Vec2d k1, k2, k3, k4;

        for(int i=0; i<n; ++i)
        {
            foreach(var e in entities)
            {
                k1 = e.velocity + e.F(entities, e.position);
                k2 = e.F(entities, e.position + halfh * k1);
                k3 = e.F(entities, e.position + halfh * k2);
                k4 = e.F(entities, e.position + h * k3);

                e.velocity = e.velocity + h / 6 * (k1 + 2*k2 + 2*k3 + k4);
                e.position = e.position + h * e.velocity;

                /*
                s11 = e.velocity * h;
                s12 = e.F(entities, e.position) * h;
                s21 = e.velocity + h / 2 * s11;
                s22 = e.F(entities, e.position + s12 * h/2);

                s31 = e.velocity + h / 2 * s21;
                s32 = e.F(entities, e.position + s22 * h/2);

                s41 = e.velocity + h * s31;
                s42 = e.F(entities, e.position + s32 * h);
                */
            }
        }
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
