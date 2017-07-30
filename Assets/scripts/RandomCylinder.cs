using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCylinder : MonoBehaviour {

    public GameObject PrimsCylinder;

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

            var PrimsCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

            PrimsCylinder.transform.position = new Vector3(xPos, yPos, zPos);


            //PrimsInstance = GameObject.Instantiate(Prims, new Vector3(xPos, 0, zPos), Quaternion.identity);

            Renderer objectRenderer = PrimsCylinder.GetComponentInChildren<Renderer>();
            objectRenderer.material.color = Color.yellow * Random.value;

            myNodes.Add(PrimsCylinder);
           
            objectdestroyed = false;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    
    //    if (!objectdestroyed && PrimsCylinder.transform.position.z < 0)
      //  {
        //    Destroy(PrimsCylinder);
          //  objectdestroyed = true;
        //}
    //}
}
