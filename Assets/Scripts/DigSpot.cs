using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigSpot : MonoBehaviour
{
    // What we want to spawn
    public GameObject dirt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function to be called by player
    public void Dug()
    {
        Vector3 spawnLocation = gameObject.transform.position;
        spawnLocation = new Vector3(spawnLocation.x, spawnLocation.y -0.4f, spawnLocation.z);

        Instantiate(dirt, spawnLocation, Quaternion.identity);
        Destroy(gameObject);
    }
}
