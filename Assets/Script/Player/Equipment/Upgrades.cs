using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Upgrades: MonoBehaviour
{

    [SerializeField] private GameObject parentWeapon;
    [SerializeField] float counter;

    [Header("ListEquipment")]
    [SerializeField] private List<GameObject> equipmentList;
    private void Awake()
    {
        #region LLamada a las clases de los equipamientos
        parentWeapon = GameObject.FindGameObjectWithTag("Weapons");

        foreach(Transform child in parentWeapon.transform)
        {
            equipmentList.Add(child.gameObject);
        }
        
        #endregion

    }
    private void Update()
    {
        
    }


    private void selectRandomWeapon()
    {
         List<GameObject> filteredList = equipmentList;
         
        for(int i = 0; i <= filteredList.Count-1; i++)
        {

            if(filteredList[i].name == "Shield")
            {
                float test = filteredList[i].GetComponent<Equipamiento>().getAttributesValues("cooldown");
                Debug.Log(test);
            }
            
        }
    }


}
