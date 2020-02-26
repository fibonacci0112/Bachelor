using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{

    public Material[] mats;

    public void SwitchMaterial(int val)
    {
        GetComponent<Renderer>().material = mats[val];
    }

}
