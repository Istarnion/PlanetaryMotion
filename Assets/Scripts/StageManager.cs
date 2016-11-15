using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    private SolarSystem solarSystem;

    private Camera cam;

    public Rocket rocket;

    void Start()
    {
        solarSystem = GetComponent<SolarSystem>();
        cam = Camera.main;
    }

    public void ShowOverview()
    {
        rocket.velocity = new Vec2d();
        rocket.position = new Vec2d();
        rocket.transform.position = Vector3.zero;

        cam.transform.parent = null;

        var camOldPos = cam.transform.position;
        var camTargetPos = new Vector3(0, 43, 0);

        StartCoroutine(Lerp(cam.transform, camOldPos, camTargetPos, 1));
    }

    public void StartLaunchStage()
    {
        cam.transform.SetParent(solarSystem.entities[3].transform);
        cam.transform.localPosition = new Vector3(0, 10, 0);
    }

    public void LeaveOrbitStage()
    {
    }

    IEnumerator Lerp(Transform transform, Vector3 from, Vector3 to, float time)
    {
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(from, to, t);

            yield return null;
        }

        transform.position = to;
    }
}
