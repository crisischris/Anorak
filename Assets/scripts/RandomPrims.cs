using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrims : MonoBehaviour {

    public GameObject primitiveToApply;
    public float speed = 2f;
    private bool objectdestroyed;
    private ArrayList myNodes;

    void createPrimitiveObject(PrimitiveType typeOfPrimitive)
    {
        var xPos = Random.Range(-5, 15);
        var yPos = Random.Range(1.0f, 2.0f);
        var zPos = Random.Range(0, 35);
        var PrimitiveObject = GameObject.CreatePrimitive(typeOfPrimitive);

        PrimitiveObject.transform.position = new Vector3(xPos, yPos, zPos);
        PrimitiveObject = applyColor(PrimitiveObject);
        myNodes.Add(PrimitiveObject);

    }

    GameObject applyColor(GameObject primitiveToApply)
    {
        Renderer objectRenderer = primitiveToApply.GetComponentInChildren<Renderer>();
        objectRenderer.material.color = Color.blue * Random.value;
        return primitiveToApply;
    }
     
    void Start() {

        myNodes = new ArrayList();
        createPrimitiveObject(PrimitiveType.Cube);
        createPrimitiveObject(PrimitiveType.Sphere);
        createPrimitiveObject(PrimitiveType.Cylinder);
        createPrimitiveObject(PrimitiveType.Capsule);
        createPrimitiveObject(PrimitiveType.Quad);
    }
}