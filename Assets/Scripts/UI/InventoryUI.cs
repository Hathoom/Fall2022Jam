using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameManager gameManager;

    public TextMeshProUGUI[] itemTxtList;
    public int page;
    public int itemsPerPage;

    public GameObject leftBtn;
    public GameObject rightBtn;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();

        for (int i = 0; i < itemTxtList.Length; i++) {
            if (i < gameManager.inventoryList.Count)
                itemTxtList[i].text = Inventory.GetName(gameManager.inventoryList[page * itemsPerPage + i]);
            else
                itemTxtList[i].text = "";
        }

        leftBtn.SetActive(gameManager.inventoryList.Count > itemsPerPage * (page + 1));
        rightBtn.SetActive(page != 0);
    }

    public void ChangePage(int pageChange) {
        page += pageChange;
        leftBtn.SetActive(gameManager.inventoryList.Count > itemsPerPage * (page + 1));
        rightBtn.SetActive(page != 0);

        for (int i = 0; i < itemTxtList.Length; i++) {
            if (page * itemsPerPage + i < gameManager.inventoryList.Count)
                itemTxtList[i].text = Inventory.GetName(gameManager.inventoryList[page * itemsPerPage + i]);
            else
                itemTxtList[i].text = "";
        }
    }
}
