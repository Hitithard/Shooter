using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorShaderDisolve : MonoBehaviour
{
    public Material myshader;

    public void SetShaderProperty(float armor, float maxArmor)
    {
        gameObject.GetComponent<MeshRenderer>().material.SetFloat("_Disolvelvl", armor/maxArmor);
    }


    // Update is called once per frame
    void Update()
    {
        

    }
}
