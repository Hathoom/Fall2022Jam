using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtWithItem : MonoBehaviour
{
    private int randomNum;

    public GameObject rebar;
    public GameObject bullet;
    public GameObject knuckles;

    public Transform itemSpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(0,3);
        Debug.Log("randomNum: " + randomNum);
        SpawnItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItem()
    {
        if (randomNum == 0)
        {
            Instantiate(rebar, itemSpawnLocation.position, Quaternion.identity);
        }
        else if (randomNum == 1)
        {
            Instantiate(bullet, itemSpawnLocation.position, Quaternion.identity);
        }
        else if (randomNum == 2)
        {
            Instantiate(knuckles, itemSpawnLocation.position, Quaternion.identity);
        }
    }
}
