using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Equipamiento
{
    [Header("Attribute")]
    [SerializeField] private int lv;
    [SerializeField] private float life;
    [SerializeField] private float maxLife;
    [SerializeField] private float lifeGeneration;

    public int Lv { get => lv; set => lv = value; }
    public float Life { get => life; set => life = value; }
    public float LifeGeneration { get => lifeGeneration; set => lifeGeneration = value; }
    public float MaxLife { get => maxLife; set => maxLife = value; }

    #region OverrideFunction  (Lv Related)
    // Utilizamos este metodo del padre para actualizar los valores de este equipamiento
    public override void setAttributesValues(string variable, float value)
    {
        if (variable == "lv")
        {
            Lv += (int)value;
        }
        else if (variable == "life")
        {
            Life += value;
        }
        else if(variable == "maxLife")
        {
            MaxLife += value;
        }
        else if (variable == "lifeGeneration") 
        {
            lifeGeneration += value;
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
        else if (variable == "life")
        {
            return Life;
        }
        else if (variable == "maxLife")
        {
            return MaxLife;
        }
        else if (variable == "lifeGeneration")
        {
            return LifeGeneration;
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
        Lv = 1;
        Life = 3;
        MaxLife = 3;
        LifeGeneration = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
