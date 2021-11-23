using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Stack inventoryOne;
  

    // Start is called before the first frame update
    void Start()
    {
        inventoryOne = new Stack(); //Criando obj y associando la variable
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddInventoryOne(GameObject item) //Agregar inventario
    {
        inventoryOne.Push(item);
    }
    public GameObject GetInventoryOne() //Obtendo el Inventario como GameObj
    {
        return inventoryOne.Pop() as GameObject;
    }
    
}
