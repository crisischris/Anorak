using System.Collections;
using System.Collections.Generic;
using UnityEngine;

private fling newInstanceOfFling = AddComponent<fling>();


public class AudioManager : MonoBehaviour {

    // Use this for initialization


    void Awake()
    {

        fling newInstanceOfFling = AddComponent<fling>();

    }


	void Start () {

        

        ClickedSound = GetComponent<AudioSource>();
        ClickedSound.clip = Resources.Load<AudioClip>("Footstep_Gravel_1");

    }

    // Update is called once per frame
    void Update () {

        if (newInstanceOfFling.clicked())
        {
            ClickedSound.Play();
                    }
    }
}
