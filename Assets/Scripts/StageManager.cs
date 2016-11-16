using UnityEngine;
using UnityEngine.SceneManagement;
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
        cam.transform.parent = null;

        var camOldPos = cam.transform.position;
        var camTargetPos = new Vector3(0, 43, 0);

        StartCoroutine(Lerp(cam.transform, camOldPos, camTargetPos, 1));
    }

    public void StartLaunchStage()
    {
        var sunPos = solarSystem.entities[0].position;
        var earthPos = solarSystem.entities[3].position;
        var earthVel = solarSystem.entities[3].velocity;

        rocket.velocity = -(earthVel / 3.0);
        rocket.position = earthPos;

        var offset = earthPos - sunPos;
        offset.Normalize();
        offset *= 6671e3;

        rocket.position += offset;

        cam.transform.SetParent(solarSystem.entities[3].transform);
        cam.transform.localPosition = new Vector3(0, 10, 0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
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
