using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float distanceToNearestMetal = float.MaxValue;
    public float baseDistance;                      // The distance where the pitch of the metal detector is 1
    // Note: maybe change it later to only being a list of objects that collide with a larger hit box around the player
    public GameObject[] metalList;                  // List of all the metal objects in the game
    public AudioSource metalBeep;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        metalList = GameObject.FindGameObjectsWithTag("Metal");

        for (int i = 0; i < metalList.Length; i++) {
            if (Vector3.Distance(transform.position, metalList[i].transform.position) < distanceToNearestMetal) {
                distanceToNearestMetal = Vector3.Distance(transform.position, metalList[i].transform.position);
                Debug.Log(distanceToNearestMetal);
            }
        }

        if (distanceToNearestMetal != 0)
            metalBeep.pitch = baseDistance / distanceToNearestMetal;
        else
            metalBeep.pitch = 0;

        distanceToNearestMetal = float.MaxValue;
    }
}
