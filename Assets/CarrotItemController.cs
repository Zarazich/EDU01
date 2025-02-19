using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.EventSystems;
public class CarrotItemController : MonoBehaviour
{
    public string name = "carrot";
    public int indxOfItem = -1;
    GameObject PArent;
    void Setup()
    {
        PArent = transform.parent.gameObject;
    }
    public int count = 1;
    public bool IsChoose = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMouseDown()
    {
        PArent.GetComponent<InventoryController>().ChooseItem(indxOfItem);
    }
}
