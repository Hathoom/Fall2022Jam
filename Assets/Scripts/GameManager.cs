using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] inventoryList;
    public GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameObject.FindGameObjectsWithTag("InventoryUI").Length == 0)
                InventoryOpen();
            else
                InventoryClose();
        }
    }

    public void InventoryOpen() {
        Time.timeScale = 0f;
        Instantiate(inventoryUI);
    }

    public void InventoryClose() {
        GameObject inventoryTemp = GameObject.FindGameObjectsWithTag("InventoryUI")[0];
        Destroy(inventoryTemp);
        Time.timeScale = 1f;
    }
}
