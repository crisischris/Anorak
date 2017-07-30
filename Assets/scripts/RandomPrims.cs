using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrims : MonoBehaviour {

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

    GameObject applyColor(GameObject primitiveObject)
    {
        Renderer objectRenderer = primitiveObject.GetComponentInChildren<Renderer>();
        objectRenderer.material.color = Color.yellow * Random.value;
        return primitiveObject;
    }
     
    void Start() {

        myNodes = new ArrayList();
        for (int i = 0; i < 10; i++) {
            createRandomPrimitive();
        }
    }

    void createRandomPrimitive()
    {
        List<PrimitiveType>listOfPrimitives = new List<PrimitiveType>();

        listOfPrimitives.Add(PrimitiveType.Cube);
        listOfPrimitives.Add(PrimitiveType.Sphere);
        listOfPrimitives.Add(PrimitiveType.Cylinder);
        listOfPrimitives.Add(PrimitiveType.Capsule);
        
        int randomListIndex = Random.Range(0, listOfPrimitives.Count);
        PrimitiveType randomType = listOfPrimitives[randomListIndex];

        createPrimitiveObject(randomType);
       }
}        