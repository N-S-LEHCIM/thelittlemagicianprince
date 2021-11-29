using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Stack inventoryOne;
    private Queue inventoryTwo;
    Dictionary<string, GameObject> inventoryThree;

    [SerializeField] private int[] foodQuantity = { 0 };
    void Start()
    {
        inventoryOne = new Stack();
        inventoryTwo = new Queue();
        inventoryThree = new Dictionary<string, GameObject>();
    }
    public int[] GetFoodQuantity()
    {
        return foodQuantity;
    }
    public void CountFood(GameObject food)
    {
        FoodController f = food.GetComponent<FoodController>(); //Foodcontroller associado a esa categoria, para obtener la categoria
        //f.GetTypeFood(); Tipo associado a la comida

        switch (f.GetTypeFood())
        {
            case GameManager.typesFood.Hamburger:
                foodQuantity[0]++;
                break;
            default:
                Debug.Log("No se cuenta");
                break;
        }

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void AddInventoryOne(string name, GameObject item)
    {
        inventoryOne.Push(item); //AGREGAR ITEM
    }

    public GameObject GetInventoryOne()
    {
        return inventoryOne.Pop() as GameObject; //SACA ITEM, pero hay que decir de que tipo guarda
    }


    public void SeeInventoryOne()
    {
        Debug.Log(inventoryOne.ToString());
        foreach (var item in inventoryOne)
        {
            Debug.Log(item.ToString());
        }
    }

    public bool InventoryOneHas()
    {
        return inventoryOne.Count > 0;
    }
}
