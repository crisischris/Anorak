using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMaker : MonoBehaviour {


    public GameObject Tree;
    public GameObject Origin;
    private GameObject TreeInstance;


	// Use this for initialization
	void Start () {

       TreeInstance =  GameObject.Instantiate(Tree, new Vector3(7, 1, 20), Quaternion.identity);
       


    }
	
	// Update is called once per frame
	void Update () {

        if (Origin.transform.position.z > 30)
        {
            Destroy(TreeInstance);
        }
    }
}
