using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColors : MonoBehaviour
{
    public Material redMaterial;
    public Material yellowMaterial;
    public Material greenMaterial;
    public Material purpleMaterial;
    public Material whiteMaterial;
    private Renderer renderer;
    private void Start()
    {
        renderer = GetComponent<Renderer>(); 
    }
    void Update()
    {
        if(this.transform.GetChild(0).tag == "red")
        {
            renderer.material = redMaterial;
        }
        if (this.transform.GetChild(0).tag == "yellow")
        {
            renderer.material = yellowMaterial;
        }
        if (this.transform.GetChild(0).tag == "green")
        {
            renderer.material = greenMaterial;
        }
        if (this.transform.GetChild(0).tag == "purple")
        {
            renderer.material = purpleMaterial;
        }
        if (this.transform.GetChild(0).tag == "white")
        {
            renderer.material = whiteMaterial;
        }
    }
}
