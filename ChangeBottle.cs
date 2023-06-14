using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBottle : MonoBehaviour
{
    public MeshFilter meshFilter;
    public Renderer renderer;

    public Mesh green;
    public Mesh blue;
    public Mesh yellow;
    public Mesh red;

   

    public Material material ;
    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        renderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.G))
        {
            meshFilter.mesh = green;
            renderer.material = material; 
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.transform.childCount != 0)
        {
            if (col.gameObject.transform.GetChild(0).gameObject.tag == "detergent")
            {
                Destroy(col.gameObject);
                StartCoroutine(Wait(6,blue,"detergent"));
               

            }
            else if (col.transform.GetChild(0).gameObject.tag == "manganese")
            {
                Destroy(col.gameObject);
                StartCoroutine(Wait(9,yellow, "manganese"));
                
            }
            else if (col.transform.GetChild(0).gameObject.tag == "potassium")
            {
                Destroy(col.gameObject);
                StartCoroutine(Wait(6,red,"postassium"));
               
            }
            else if (col.transform.GetChild(0).gameObject.tag == "copper")
            {
                Destroy(col.gameObject);
                StartCoroutine(Wait(9,green,"copper"));
               
                
            }
        }
        
    }
    private IEnumerator Wait(int delay , Mesh mesh,string objTag)
    {
        yield return new WaitForSeconds(delay);
        transform.GetChild(0).tag = objTag;
        meshFilter.mesh = mesh;
        renderer.material = material;
    }
}
