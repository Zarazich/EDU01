using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.EventSystems;
public class CustomGradeController : MonoBehaviour
{
    [SerializeField] GameObject ItemsDB;
    [SerializeField] GameObject inventoryObject;
    private GameObject target;
    public string NameOfTarget;
    InventoryController inventoryScript;
    public bool filled = false;
    public bool ReadyToHarvest = false;
    public void SeedPlant()
    {

        Debug.Log(1);
        filled = true;
        target = Instantiate(ItemsDB.GetComponent<ItemDBController>().ItemsDB[NameOfTarget][0], transform.position, Quaternion.identity);
    }
    public void GrowPlant()
    {
        Debug.Log(2);
    	ReadyToHarvest = true;
    	Destroy(target);
    	target = Instantiate(ItemsDB.GetComponent<ItemDBController>().ItemsDB[NameOfTarget][1], transform.position, Quaternion.identity);
    }
    public void Harvest()
    {
        Destroy(target);
        Debug.Log(3);
        filled = false;
        ReadyToHarvest = false;
        inventoryObject.GetComponent<InventoryController>().Add_item(NameOfTarget);
        NameOfTarget = "";
    }
    private IEnumerator ControlOfPlant()
    {
        yield return new WaitForSeconds(20f);
        if (filled && !ReadyToHarvest)
        {
            GrowPlant();
        }
    }
    void Start()
    {
        inventoryScript = inventoryObject.GetComponent<InventoryController>();
        StartCoroutine(ControlOfPlant());
    }
    void OnMouseDown()
    {
    	if (Input.GetMouseButton(0))
    	{
    	    if (!filled && !ReadyToHarvest)
    	    {
    	        SeedPlant();
    	    }
    	    else if (ReadyToHarvest)
    	    {
    	        Harvest();
    	    }
    	}
    }

    void Update()
    {
        
    }
}
