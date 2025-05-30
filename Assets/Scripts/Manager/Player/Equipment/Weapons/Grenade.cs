using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Equipamiento
{
    [Header("Attribute")]
    [SerializeField] private int lv;
    [SerializeField] private float power;
    [SerializeField] private float range;

    public int Lv { get => lv; set => lv = value; }
    public float Power { get => power; set => power = value; }
    public float Range { get => range; set => range = value; }

    #region OverrideFunction  (Lv Related)
    // Utilizamos este metodo del padre para actualizar los valores de este equipamiento
    public override void setAttributesValues(string variable, float value)
    {
        if (variable == "lv")
        {
            Lv += (int)value;
        }
        else if (variable == "power")
        {
            Power += value;
        }
        else if (variable == "range")
        {
            Range += value;
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
        else if (variable == "power")
        {
            return Power;
        }
        else if (variable == "range")
        {
            return Range;
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
