using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color defaultcolor;
    public Color newcolor;
    public Renderer render;

    void Start()
    { 
        render = GetComponent<Renderer>();
        render.material.color = newcolor;

   }

    


}
