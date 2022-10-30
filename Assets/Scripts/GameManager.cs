using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public List<int> inventoryList;
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

    public void AddItem(int itemID) {
        inventoryList.Add(itemID);
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


    // Main Menu stuff
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Nick_Testing");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadControls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
