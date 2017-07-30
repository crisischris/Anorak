using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSphere : MonoBehaviour
{

    public GameObject PrimsSphere;
    
    //private GameObject PrimsInstance;
    public float speed = 2f;
    private bool objectdestroyed;
    private ArrayList myNodes;


    // Use this for initialization
    void Start()
    {
        myNodes = new ArrayList();

        for (int i = 0; i < 4; i++)
        {
            var xPos = Random.Range(-5, 15);
            var yPos = Random.Range(1.0f, 2.0f);
            var zPos = Random.Range(0, 35);

            var PrimsSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            
            PrimsSphere.transform.position = new Vector3(xPos, yPos, zPos);
            
            //PrimsInstance = GameObject.Instantiate(Prims, new Vector3(xPos, 0, zPos), Quaternion.identity);

            Renderer objectRenderer = PrimsSphere.GetComponentInChildren<Renderer>();
            objectRenderer.material.color = Color.red * Random.value;

            myNodes.Add(PrimsSphere);
    
            objectdestroyed = false;
        }
    }

    // Update is called once per frame
   // void Update()
    //{
    
    //    if (!objectdestroyed && PrimsSphere.transform.position.z < -20)
      //  {
        //    Destroy(PrimsSphere);
          //  objectdestroyed = true;
        //}
    //}
}
