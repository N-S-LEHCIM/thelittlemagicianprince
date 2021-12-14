using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUBcontroller : MonoBehaviour
{
    [SerializeField] private Text textHamburger;

    [SerializeField] private TextMeshProUGUI textLife;

    [SerializeField] private InventoryManager mgInventory;
    [SerializeField] private GameObject panelFood;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerCtrl.onLifes += OnlifeChangeHandler;
    }
    void Start()
    {
        PlayerCtrl.onDeath += OnDeadHandler;
    }
    
    private void OnDeadHandler()
    {
        textLife.text = "Fin de Juego";
    }
    private void OnlifeChangeHandler(int lifes)
    {
        textLife.text = "Lifes: " + lifes;
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
