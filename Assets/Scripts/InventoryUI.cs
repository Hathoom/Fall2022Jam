using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameManager gameManager;

    public TextMeshProUGUI[] itemList;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();

        for (int i = 0; i < itemList.Length; i++) {
            if (i < gameManager.inventoryList.Length)
                itemList[i].text = Inventory.GetName(gameManager.inventoryList[i]);
            else
                itemList[i].text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
