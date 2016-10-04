using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlienSpawner : MonoBehaviour
{
    public float spawRadius = 40;

    public int maxAliens = 20;

    public GameObject alienPrefab;

    public Planet[] planets;

    private List<Alien> aliens = new List<Alien>();

    void Start()
    {
        StartCoroutine(SpawnAliens());
    }

    void Update()
    {
        for(int i = aliens.Count-1; i >= 0; --i)
        {
            Alien alien = aliens[i];
            if (alien.dead)
            {
                Destroy(alien.gameObject);
                aliens.RemoveAt(i);
            }
            else
            {
                foreach(var planet in planets)
                {
                    alien.velocity += (planet.transform.position - alien.transform.position).normalized * Time.deltaTime;
                }
            }
        }
    }

    IEnumerator SpawnAliens()
    {
        while(true)
        {
            if(aliens.Count < maxAliens)
            {
                var alien = Instantiate(alienPrefab).GetComponent<Alien>();
                alien.transform.parent = transform;
                aliens.Add(alien);
                alien.transform.position = new Vector3(
                    Mathf.Cos(Random.Range(-spawRadius, spawRadius)) * spawRadius,
                    0,
                    Mathf.Sin(Random.Range(-spawRadius, spawRadius))
                );
            }

            yield return new WaitForSeconds(1);
        }
    }
}

