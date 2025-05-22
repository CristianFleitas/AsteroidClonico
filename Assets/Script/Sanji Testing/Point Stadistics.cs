using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointStadistics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Puntos: " + GameManager.Instance.Points);
        GameManager.Instance.AddPoints(2);
        Debug.Log("Puntos: " + GameManager.Instance.Points);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
