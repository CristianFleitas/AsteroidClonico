using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbitals : Equipamiento
{
    [Header("Attribute")]
    [SerializeField] private int lv;
    [SerializeField] private float power;
    [SerializeField] private float speed;

    public int Lv { get => lv; set => lv = value; }
    public float Power { get => power; set => power = value; }
    public float Speed { get => speed; set => speed = value; }

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
        else if (variable == "speed")
        {
            Speed += value;
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
        else if (variable == "speed")
        {
            return Speed;
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
        lv = 0;
        power = 1;
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
