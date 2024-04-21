using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoints : MonoBehaviour
{
    public GameObject[] spawnpoints;
    public GameObject[] pointAlive;
    public GameObject pointFab;
    // Start is called before the first frame update
    void Start()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        StartCoroutine(spawnStuff()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator spawnStuff()
    {
        pointAlive = GameObject.FindGameObjectsWithTag("Point");

        if (pointAlive.Length < 6 )
        {
            var whereToSpawn = Random.Range(0, spawnpoints.Length);
            Instantiate(pointFab, spawnpoints[whereToSpawn].transform.position, spawnpoints[whereToSpawn].transform.rotation);
        }

        yield return new WaitForSeconds(2);
        StartCoroutine(spawnStuff());
    }
}
