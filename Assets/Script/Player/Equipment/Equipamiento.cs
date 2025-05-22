using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipamiento : MonoBehaviour
{

    public abstract void setAttributesValues(string variable, float value);
    public abstract float getAttributesValues(string variable);

}
