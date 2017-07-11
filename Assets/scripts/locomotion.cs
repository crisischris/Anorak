using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locomotion : MonoBehaviour {

    private float speed = 5;
    private int TimeSinceStart;
    private int CameraPosition;

    
 
        void Update()


        {
           
            transform.Translate(Vector3.forward * Time.deltaTime*speed, Space.World);

               if (transform.position.z > 100)
                {
                    speed = -5;
                }
               if (transform.position.z < 0)
        {
            speed = 5; 
        }
        }

    }

