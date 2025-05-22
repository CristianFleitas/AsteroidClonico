using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : Equipamiento
{
    [Header("Attribute")]
    [SerializeField] private int lv;
    [SerializeField]private float velocity;

    public int Lv { get => lv; set => lv = value; }
    public float Velocity { get => velocity; set => velocity = value; }

    #region OverrideFunction  (Lv Related)
    // Utilizamos este metodo del padre para actualizar los valores de este equipamiento
    public override void setAttributesValues(string variable, float value)
    {
        if (variable == "lv")
        {
            Lv += (int)value;
        }
        else if (variable == "velocity")
        {
            Velocity += value;
        }
        else
        {
            Debug.LogError("No se encontro la variable");
        }
    }

    public override float getAttributesValues(string variable)
    {
        if (variable == "lv")
        {
            float lvFloat = Lv;
            return lvFloat;
        }
        else if (variable == "velocity")
        {
            return Velocity;
        }
        else
        {
            Debug.LogError("No se encontro la variable");
        }
        return -1000000f;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
