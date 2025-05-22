 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    int points = 0;
    public int Points { get => points; } //Encapsulación
    private void Awake()
    {
        if(Instance != null) //Evitar que se dupliquen entre scenes
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); //Se genera SOLO 1 instancia en toda la 
    }

    public void AddPoints(int value) //para varios enemigos
    {
        points += value;
    }
}
