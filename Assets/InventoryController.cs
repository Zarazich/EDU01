using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class InventoryController : MonoBehaviour
{
    [SerializeField] GameObject ItemsDB;
    int CurrentItem = 0;
    public List<GameObject> InventoryItems = new List<GameObject>();
    public void Add_item(string name) 
    {
        GameObject InvObj = Instantiate(ItemsDB.GetComponent<ItemDBController>().ItemsDB[name][2], transform.position, Quaternion.identity);
        InvObj.GetComponent<ItemController>().indxOfItem = InventoryItems.Count;
        InventoryItems.Add(InvObj);
    }
    public void ChooseItem(int index)
    {
        CurrentItem = index;
    }
}
