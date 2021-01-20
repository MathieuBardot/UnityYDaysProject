using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject cube;
    public Color color;
    public Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        //rend = this.GetComponent<Renderer>();
        //color = rend.material.color;
        //rend.material.color = Color.red;

        color = cube.GetComponent<Test>().color;
        //cube = GameObject.Find("Cylinder");
        cube = GameObject.FindWithTag("CubeChangeColor");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        color = Color.yellow;
        rend.material.color = Color.blue;
    }
}
