using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fling : MonoBehaviour {

    bool isClicked = false;
    public float vel;
    public GameObject main;
    public Rigidbody rb;
    public Material defaultMat;

// Use this for initialization
    void Start () {
                
        rb = GetComponent<Rigidbody>();
    }
        

// Update is called once per frame
    void Update () {
        if (isClicked == true && transform.position.y <= 0)
        {
                Destroy(main);
                print("destroyed!");
                isClicked = false;
            }
        }

    

    public void Clicked() {

        Vector3 randomDirection = new Vector3(Random.value, Random.value, Random.value);
        
            rb.AddForce(randomDirection * vel);
            rb.useGravity = true;
            isClicked = true;
            print("clicked!");
            print(randomDirection);
        
    }

    public void IsGazed() {
                GetComponent<Renderer>().material.color  =  Color.red;
    }


    public void IsNotGazed() {
        GetComponent<Renderer>().material = defaultMat;
    }
}
