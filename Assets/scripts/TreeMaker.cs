using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMaker : MonoBehaviour {


    public GameObject Tree;
	private List<GameObject> Forest = new List<GameObject>();
    public float speed = 2f;
	private float timeTracker = 0;
	private float targetSpawnTime = 0;
	private int numberOfTreesToSpawnInitially = 7;

    // Use this for initialization
    void Start () {
		for (int index = 0; index < numberOfTreesToSpawnInitially; index++) {
			spawnTree ();
		}
    }

    // Update is called once per frame
    void Update () {

		timeTracker += Time.deltaTime;

		for (int indexOfForestList = 0; indexOfForestList < Forest.Count; indexOfForestList++) {
			moveTree (Forest[indexOfForestList], indexOfForestList);
			checkTreeForDestruction (Forest [indexOfForestList]);
		}

		if (spawnObjectRate ()) {
			int randomNumberToSpawn = Random.Range (10, 30);
			for (int index = 0; index < randomNumberToSpawn; index++) {
				spawnTree ();
			}
		}

    }

	bool spawnObjectRate() {
		if (timeTracker >= targetSpawnTime) {
			targetSpawnTime = Random.Range (1, 3);
			timeTracker = 0;
			return true;
		}

		return false;
	}

	void checkTreeForDestruction(GameObject treeToCheck) {
		if (treeToCheck.transform.position.z < -20)
		{
			int treeNumber = Forest.IndexOf (treeToCheck);
			GameObject treeToRemove = treeToCheck;
			Forest.Remove (treeToCheck);
			Destroy (treeToRemove);
			print ("Tree #" + treeNumber + " destroyed.");
		}
	}

	void spawnTree() {
		var xPos = Random.Range(-50, 50);
		var yPos = Random.Range(1.5f, 2);
		var zPos = Random.Range(20, 40);

		GameObject newTree;

		newTree = GameObject.Instantiate(Tree, new Vector3(xPos, yPos, zPos), Quaternion.identity);
		Forest.Add (newTree);

		print ("Tree #" + Forest.Count + " created.");
	}

	void moveTree(GameObject inputTree, int treeNumber) {
		var pos = inputTree.transform.position.z;

		if (inputTree.transform.position.z > -20) {          
			inputTree.transform.Translate (new Vector3 (0, 0, speed * -Time.deltaTime));       
		}

//		print ("Position of Tree #" + treeNumber + " = " + pos);
	}
}
