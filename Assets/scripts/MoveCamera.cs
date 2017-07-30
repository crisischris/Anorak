using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    Vector3 End_pos;
    Vector3 Start_pos;

    public float speed = 2f;

    // Use this for initialization
    void Start () {
        Start_pos = transform.position;
           	
	}
	
	// Update is called once per frame
	void Update () {
            if (Input.GetKey(KeyCode.W))
                End_pos = transform.position + new Vector3(0, 40, 0);
            speed += 0.1f;
            transform.position = Vector3.Lerp(Start_pos, End_pos, speed);                   ;
    }
}
    