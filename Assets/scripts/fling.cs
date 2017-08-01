﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class fling : MonoBehaviour
{

	bool isClicked = false;
	public float vel;
	public GameObject main;
	public Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
	}
        

	// Update is called once per frame
	void Update ()
	{
		if (isClicked == true && transform.position.y <= 0 || transform.position.y >= 150 || transform.position.z >= 150) {
			Destroy (main);
			print ("destroyed!");
			isClicked = false;
		}
	}

    

	public void Clicked (BaseEventData eventData)
	{
		Vector3 randomDirection = new Vector3 (Random.value, Random.value, Random.value);
		rb.AddForce (randomDirection * vel);
		rb.useGravity = true;
		isClicked = true;
		print ("clicked!" + main.gameObject);
		print (randomDirection);
        
	}

	public void IsGazed (BaseEventData eventData)
	{
		GetComponent<Renderer> ().material.color = Color.red;
	}


	public void IsNotGazed (BaseEventData eventData)
	{
		GetComponent<Renderer> ().material.color = Color.yellow * Random.value;
	}
}
