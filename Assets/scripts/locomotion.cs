﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class locomotion : MonoBehaviour {

    private float speed = 2;
    private int TimeSinceStart;
    private int CameraPosition;
     
    void Update() {
           
        transform.Translate(Vector3.forward * Time.deltaTime*speed, Space.World);

        if (transform.position.z > 45) {

           speed = 0;
        }

        if (transform.position.z < -23) {

           speed = 0; 
        }
   }


}

