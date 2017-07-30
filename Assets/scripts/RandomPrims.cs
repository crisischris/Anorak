using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrims : MonoBehaviour {

    public GameObject PrimsCube;
    //public GameObject PrimsSphere;
    //public GameObject PrimsCylinder;
    //public GameObject PrimsCapsule;
    //public GameObject PrimsQuad;

    //private GameObject PrimsInstance;
    public float speed = 2f;
    private bool objectdestroyed;
    private ArrayList myNodes;


    // Use this for initialization
    void Start () {

        myNodes = new ArrayList();

        for (int i = 0; i < 4; i++)
        {
            var xPos = Random.Range(-5, 15);
            var yPos = Random.Range(1.0f, 2.0f);
            var zPos = Random.Range(0, 35);

            var PrimsCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //GameObject PrimsSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //GameObject PrimsCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            //GameObject PrimsCapsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            //GameObject PrimsQuad = GameObject.CreatePrimitive(PrimitiveType.Quad);

            PrimsCube.transform.position = new Vector3(xPos, yPos, zPos);
            //PrimsSphere.transform.position = new Vector3(xPos, yPos, zPos);
            //PrimsCylinder.transform.position = new Vector3(xPos, yPos, zPos);
            //PrimsCapsule.transform.position = new Vector3(xPos, yPos, zPos);
            //PrimsQuad.transform.position = new Vector3(xPos, yPos, zPos);

            //PrimsInstance = GameObject.Instantiate(Prims, new Vector3(xPos, 0, zPos), Quaternion.identity);

            Renderer objectRenderer = PrimsCube.GetComponentInChildren<Renderer>();
            objectRenderer.material.color = Color.blue * Random.value;

            myNodes.Add(PrimsCube);
            //myNodes.Add(PrimsSphere);
            //myNodes.Add(PrimsCylinder);
            //myNodes.Add(PrimsCapsule);
            //myNodes.Add(PrimsQuad);

            objectdestroyed = false;
          }
    }

    // Update is called once per frame
  //  void Update() {
        
    //      if (!objectdestroyed && PrimsCube.transform.position.z < -20)
      //      {
        //        Destroy(PrimsCube);
          //      objectdestroyed = true;
            //}
     //}
}
