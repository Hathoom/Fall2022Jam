using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHitbox : MonoBehaviour
{
    public string terrainType;

    void OnTriggerEnter(Collider collider) {
        Debug.Log("ping");
        if (collider.gameObject.tag == "Player") {
            //Debug.Log(collider.gameObject.GetComponent<TerrainHitbox>().terrainType);
            //Debug.Log("ping");
        }
    }
}
