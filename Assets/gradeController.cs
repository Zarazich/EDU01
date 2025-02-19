using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.EventSystems;

public class GradeController : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] GameObject seedPrefab;
    [SerializeField] GameObject littlePlantPrefab;
    [SerializeField] GameObject largePlantPrefab;
    private GameObject currentPlaunt;
    private bool isPlanted = false;
    private bool isReadyToHarvest = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (isReadyToHarvest)
            {
                Harvest();
                return;
            }
            if (!isPlanted)
            {
                PlantSeed();
                return;
            }
        }
    }
    private IEnumerator GrowingPlant()
    {
        yield return new WaitForSeconds(5.0f);
        Transform currentPosition = currentPlaunt.transform;
        Destroy(currentPlaunt);
        currentPlaunt = Instantiate(littlePlantPrefab, currentPosition.position, Quaternion.identity);
        Debug.Log("закончилась 1 фаза роста");
        
        yield return new WaitForSeconds(5.0f);
        currentPosition = currentPlaunt.transform;
        Destroy(currentPlaunt);
        currentPlaunt = Instantiate(largePlantPrefab, currentPosition.position, Quaternion.identity);
        Debug.Log("закончилась 2 фаза роста");
        isReadyToHarvest = true;

    }

    private void PlantSeed()
    {
        currentPlaunt = Instantiate(seedPrefab, transform.position, Quaternion.identity);
        isPlanted = true;
        StartCoroutine(GrowingPlant());
        Debug.Log("семена посажены");
    }

    private void Harvest()
    {
        if(currentPlaunt != null)
        {
            Destroy(currentPlaunt); 
            isPlanted = false;
            isReadyToHarvest=false;
            Debug.Log("семена собраны");
        }
    }
}
