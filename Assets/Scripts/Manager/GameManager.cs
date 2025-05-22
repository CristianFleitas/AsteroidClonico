using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private List<GameObject> UpgradeWindows;

    [Header("Flags")]
    [SerializeField] private bool pauseIsTrigger;

    private void Awake()
    {
        menuPausa = GameObject.FindGameObjectWithTag("MenuPausa");
        
        foreach (Transform child in menuPausa.transform) {
            UpgradeWindows.Add(child.gameObject);        
        }
        triggerLvUpMenu(false);
    }

    private void Start()
    {
        pauseIsTrigger = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pauseIsTrigger)
            {
                triggerTimeStop(true);
                triggerLvUpMenu(true);
                pauseIsTrigger = true;
            }else
            {
                triggerTimeStop(false);
                triggerLvUpMenu(false);
                pauseIsTrigger = false;
            }
            
            
        }
    }

    private void triggerTimeStop(bool state)
    {
        if (!state)
        {
            Time.timeScale = 1;
            Debug.Log("tiempo se mueve");
        }
        if (state)
        {
            Time.timeScale = 0;
            Debug.Log("tiempo parado");
        }
    }
    private void triggerLvUpMenu(bool state)
    {
        if (state)
        {
            menuPausa.SetActive(true);
        }
        else if (!state)
        {
            menuPausa.SetActive(false);
        }
    }
}
