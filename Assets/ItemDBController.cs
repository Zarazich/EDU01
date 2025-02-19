using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDBController : MonoBehaviour
{
    // в нулевом - семя
    // в первом - растение
    // в последнем - объект для инвентаря
    public Dictionary<string, List<GameObject>> ItemsDB;
    [SerializeField] List<GameObject> CarrotPrefubs = new List<GameObject>();
    void Start()
    {
        ItemsDB.Add("carrot", CarrotPrefubs);
    }
    void Update()
    {
        
    }
}
