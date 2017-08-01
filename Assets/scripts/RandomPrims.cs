using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using GVR.Input;

public class RandomPrims : MonoBehaviour
{
	private ArrayList myNodes;

	void createprimitiveObject (PrimitiveType typeOfPrimitive)
	{
		var xPos = Random.Range (-5, 15);
		var yPos = Random.Range (1.0f, 2.0f);
		var zPos = Random.Range (0, 35);
		var primitiveObject = GameObject.CreatePrimitive (typeOfPrimitive);

		primitiveObject.transform.position = new Vector3 (xPos, yPos, zPos);
		applyColor (primitiveObject);
		applyPhysics (primitiveObject);
		addFlingScript (primitiveObject);
		addEventTriggers (primitiveObject);
		myNodes.Add (primitiveObject);
	}

	void applyColor (GameObject primitiveObject)
	{
		Renderer objectRenderer = primitiveObject.GetComponentInChildren<Renderer> ();
		objectRenderer.material.color = Color.yellow * Random.value;
	}

	void applyPhysics (GameObject primitiveObject)
	{
		Rigidbody gameObjectsRigidBody = primitiveObject.AddComponent<Rigidbody> ();
		gameObjectsRigidBody.mass = 1;
	}

	void addFlingScript (GameObject primitiveObject)
	{
		fling scriptOfGameObjectInstance = primitiveObject.AddComponent<fling> ();
		scriptOfGameObjectInstance.main = primitiveObject;
		scriptOfGameObjectInstance.rb = primitiveObject.GetComponent<Rigidbody> ();
		scriptOfGameObjectInstance.vel = Random.Range (2500, 5000);
	}

	void addEventTriggers (GameObject primitiveObject)
	{
		primitiveObject.AddComponent<EventTrigger> ();
		applyClickTrigger (primitiveObject);
		applyGazeTrigger (primitiveObject);
		applyNoGazeTrigger (primitiveObject);
	}

	void addEventTriggerToObject (GameObject primitiveObject, EventTriggerType eventType, System.Action<BaseEventData> callback)
	{
		EventTrigger trigger = primitiveObject.GetComponent<EventTrigger> ();
		EventTrigger.Entry entry = new EventTrigger.Entry ();
		entry.eventID = eventType;
		entry.callback = new EventTrigger.TriggerEvent ();
		entry.callback.AddListener (new UnityEngine.Events.UnityAction<BaseEventData> (callback));
		trigger.triggers.Add (entry);
	}

	void applyClickTrigger (GameObject primitiveObject)
	{
		fling script = primitiveObject.GetComponent<fling> ();
		addEventTriggerToObject (primitiveObject, EventTriggerType.PointerClick, script.Clicked);
	}

	void applyGazeTrigger (GameObject primitiveObject)
	{
		fling script = primitiveObject.GetComponent<fling> ();
		addEventTriggerToObject (primitiveObject, EventTriggerType.PointerEnter, script.IsGazed);
	}

	void applyNoGazeTrigger (GameObject primitiveObject)
	{
		fling script = primitiveObject.GetComponent<fling> ();
		addEventTriggerToObject (primitiveObject, EventTriggerType.PointerExit, script.IsNotGazed);
	}

	void Start ()
	{
		myNodes = new ArrayList ();

		int primitivesToGenerate = Random.Range (10, 30);
		for (int i = 0; i < primitivesToGenerate; i++) {
			createRandomPrimitive ();
		}
	}

	void createRandomPrimitive ()
	{
		List<PrimitiveType> listOfPrimitives = new List<PrimitiveType> ();

		listOfPrimitives.Add (PrimitiveType.Cube);
		listOfPrimitives.Add (PrimitiveType.Sphere);
		listOfPrimitives.Add (PrimitiveType.Cylinder);
		listOfPrimitives.Add (PrimitiveType.Capsule);
        
		int randomListIndex = Random.Range (0, listOfPrimitives.Count);
		PrimitiveType randomType = listOfPrimitives [randomListIndex];

		createprimitiveObject (randomType);
	}
}        