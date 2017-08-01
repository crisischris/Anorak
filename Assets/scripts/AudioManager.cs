using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioManager : MonoBehaviour {

	public AudioSource soundBite;

    void Awake()
    {
		
    }


	void Start () {
    }

	public void intializeClip() {
		soundBite.clip = Resources.Load<AudioClip> ("Footstep_Gravel_1");
	}

	public void playClip() {
		soundBite.Play ();
	}

    // Update is called once per frame
    void Update () {
    }
}
