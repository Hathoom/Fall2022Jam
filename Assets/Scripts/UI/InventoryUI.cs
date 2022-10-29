using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameManager gameManager;

    public TextMeshProUGUI[] itemTxtList;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();

        for (int i = 0; i < itemTxtList.Length; i++) {
            if (i < gameManager.inventoryList.Count)
                itemTxtList[i].text = Inventory.GetName(gameManager.inventoryList[i]);
            else
                itemTxtList[i].text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
