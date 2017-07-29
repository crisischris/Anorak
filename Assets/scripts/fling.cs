using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fling : MonoBehaviour {

    bool isClicked = false;
    public float vel = 500;
    public GameObject main;
    public Rigidbody rb;
    public Material red;


    // Use this for initialization
    void Start ()
    {

        // newcube = GameObject.Instantiate(main, new Vector3(0, .5f, 3), Quaternion.identity);
        rb = GetComponent<Rigidbody>();

    }


    void FixedUpdate()
    {
       // if (isClicked == true)
        //{
          //  rb.AddForce(transform.up * 10);
            //rb.useGravity = true;

           // if (isClicked == true && main.transform.position.x > 150 || main.transform.position.z > 150 || main.transform.position.y > 150)
           // {
           //     Destroy(main);
           //     GameObject.Instantiate(main, new Vector3(0, .5f, 3), Quaternion.identity);
           //     isClicked = false;
                            }
        
    


// Update is called once per frame
void Update ()
    {
		/*if(isClicked == true)
    {
            
            main.transform.Translate(Vector3.forward * (Time.deltaTime * vel));
            main.transform.Translate(Vector3.right * (Time.deltaTime * vel));
            main.transform.Translate(Vector3.up * (Time.deltaTime * vel));

            if (isClicked == true && main.transform.position.x > 150 || main.transform.position.z > 150 || main.transform.position.y > 150)
            {
                Destroy(main);
                GameObject.Instantiate(main, new Vector3(0, .5f, 3), Quaternion.identity);
                isClicked = false;

            }
        }
        */

        if(transform.position.x > 150)
        {
            Destroy(main);
            print("destroyed!");

        }

    }

    public void Clicked()
    {

        Vector3 randomDirection = new Vector3(Random.Range(.5f,1), Random.Range(.5f, 1), Random.Range(.5f, 1));

        GetComponent<Renderer>().material =  red;

        //Vector3 direction = Random.insideUnitSphere;
        rb.AddForce(randomDirection * vel);
          //  rb.AddForce(transform.right * vel);
            rb.useGravity = true;
            isClicked = true;
            print("clicked!");
        print(randomDirection);


       

    }
}
