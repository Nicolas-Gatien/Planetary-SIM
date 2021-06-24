using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int numOfObjects;

    public GameObject planet;
    public float spawnRange=5;

    public float maxPlanetSize = 2f;
    public float minPlanetSize = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        while (numOfObjects > 0)
        {
            Vector3 planetPos = new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));
            Quaternion planetRotation = new Quaternion(Random.Range(0, 365), Random.Range(0, 365), Random.Range(0, 365), 1);
            GameObject curPlanet = Instantiate(planet, planetPos, planetRotation);
            curPlanet.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-10f, 10f));
            float fsize = Random.Range(minPlanetSize, maxPlanetSize);
            curPlanet.transform.localScale = new Vector3(fsize, fsize, fsize);
            numOfObjects--;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
