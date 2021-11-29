using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUBcontroller : MonoBehaviour
{
    [SerializeField] private Text textHamburger;

    [SerializeField] private InventoryManager mgInventory;
    [SerializeField] private GameObject panelFood;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFoodUI();
    }
    void UpdateFoodUI()
    {
        int[] foodCount = mgInventory.GetFoodQuantity();
        textHamburger.text = "x" + foodCount[0];
    }
    public void FoodButoon()
    {
        panelFood.SetActive(!panelFood.activeSelf);
    }
}
