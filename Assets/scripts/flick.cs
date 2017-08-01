using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flick : MonoBehaviour {

    bool IsClicked;



	// Use this for initialization
	void Start () {

        IsClicked = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (IsClicked == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        
	}

     public void OnHouseClick()
    {
        IsClicked = true;
        print("clicked!");

    }
}
