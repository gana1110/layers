using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TweakableParameter
{
    public string name;
    public float value;

}

public class parametres : MonoBehaviour
{
    public List<TweakableParameter> parameters = new List<TweakableParameter>();
}
