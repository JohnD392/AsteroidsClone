using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

    public GameObject asteroidPrefab;

    public int currentLevel;
    public float timeBetweenSpawns;

    public List<GameObject> asteroids;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(CRAsteroidSpawner());
        asteroids = new List<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    GameObject SpawnAsteroid() {
        Debug.Log("Spawning Asteroid");
        Vector3 spawnLocation = RandomBorderLocation();
        GameObject asteroid = Instantiate(asteroidPrefab, spawnLocation, Quaternion.identity);
        Vector3 trajectory = Random.insideUnitSphere;
        trajectory.z = 0f;
        asteroid.GetComponent<Rigidbody>().velocity = trajectory * currentLevel;
        asteroids.Add(asteroid);
        Debug.Log("New asteroids count: " + asteroids.Count);
        return asteroid;
    }

    Vector3 RandomBorderLocation() {
        Vector3 v;
        if (Random.Range(0f, 1f) > .5f) {
            v = new Vector3(Random.Range(0f, 1f), 0f, 0f);
        } else {
            v = new Vector3(0f, Random.Range(0f, 1f), 0f);
        }
        Vector3 vec = Camera.main.ViewportToWorldPoint(v);
        vec.z = 0f;
        return vec;
    }

    IEnumerator CRAsteroidSpawner () {
        Debug.Log("Starting coroutine");
        for (int i=0; i<5; i++) {
            currentLevel = i;
            Debug.Log("Level:" + i);
            while(GameObject.FindGameObjectsWithTag("Asteroid").Length > 0) {
                yield return new WaitForSeconds(1f);
            }
            Debug.Log("Level Complete!");
            yield return new WaitForSeconds(3f);
            for(int j=0; j<i*3; j++) {
                Debug.Log("Iterating");
                SpawnAsteroid();
            }
        }
        yield return null;
    }
}
