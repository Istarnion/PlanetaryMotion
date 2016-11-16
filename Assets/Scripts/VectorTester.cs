using UnityEngine;
using System.Collections;

public class VectorTester : MonoBehaviour
{
    void Start()
    {
        var v1 = new Vec2d(1.5e30, 72.5e30);
        var v2 = new Vec2d(4.5e30, 50.5e30);

        var h = 10800.0;

        Debug.Log(Vec2d.Distance(h/6*v1, v2 * h/6));
    }
}
