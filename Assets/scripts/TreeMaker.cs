using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMaker : MonoBehaviour {


    public GameObject Tree;
    private GameObject TreeInstance;
    public float speed = 2f;
	private bool objectdestroyed;

    // Use this for initialization
    void Start () {

	    var xPos = Random.Range(-5, 15);
	    var yPos = Random.Range(1.5f, 2);
	    var zPos = Random.Range(20, 40);
       
        TreeInstance = GameObject.Instantiate(Tree, new Vector3(xPos, yPos, zPos), Quaternion.identity);
		objectdestroyed = false;

    }

    // Update is called once per frame
    void Update () {

		if (!objectdestroyed) {
			moveTree ();
		}
			
		if (!objectdestroyed && TreeInstance.transform.position.z < -20)
        {
            Destroy(TreeInstance);
			objectdestroyed = true;
        }
    }

	void moveTree() {
		var pos = TreeInstance.transform.position.z;

		if (TreeInstance.transform.position.z > -20) {          
			TreeInstance.transform.Translate (new Vector3 (0, 0, speed * -Time.deltaTime));       
		}

		print ("the position of TreeInstance =" + pos);
	}
}
