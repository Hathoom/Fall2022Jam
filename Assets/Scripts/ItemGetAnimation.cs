using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGetAnimation : MonoBehaviour
{
    public float animationTime;
    public float animationTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animationTimer += Time.deltaTime;
        if (animationTimer >= animationTime) Destroy(gameObject);
    }
}
