using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Equipamiento
{
    [Header("Attribute")]
    [SerializeField] private int lv;
    [SerializeField] private float cooldown;

    #region Encapsulamiento de las variables
    public int Lv { get => lv; set => lv = value; }
    public float Cooldown { get => cooldown; set => cooldown = value; }
    #endregion

    void Start()
    {
        #region iniciación de las variables
        Lv = 0;
        Cooldown = 10f;
        #endregion
    }

    void Update()
    {
        
    }
    #region OverrideFunction  (Lv Related)
    // Utilizamos este metodo del padre para actualizar los valores de este equipamiento
    public override void setAttributesValues(string variable, float value)
    {
        if (variable == "lv")
        {
            Lv += (int)value;
        }
        else if (variable == "cooldown")
        {
            Cooldown += value;
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
        else if (variable == "cooldown")
        {
            Debug.Log(Cooldown);
            return Cooldown;
        }
        else
        {
            Debug.LogError("No se encontro la variable");
        }
        return -1000000f;
    }
    #endregion
    #region EquipmentBehavior
    //Aqui colocamos el codigo referente al comportamiento del equipamiento durante el juego
    #endregion
}
