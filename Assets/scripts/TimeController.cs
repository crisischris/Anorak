using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeController : MonoBehaviour
{

	//	This is our 'rewind' properties.
	public int keyframeSampleRate = 8;
	public int rewindFrameSampleRate = 10;
	public float maxRewindTimeInSec = 60.0f;

	//	These are private, helper variables. These are NOT meant to be seen outside this class.
	private List<ObjectState> ObjectStates;
	private bool isRewinding = false;
	private float keyFrameCounter = 0;
	private float slowdown = 0;
	private float slowdown_t = 0;

	//	Start is used to initialize the beginning of the script.
	void Start ()
	{
		//	We must instantiate an empty list of ObjectState and store it
		//		in ObjectStates in order to use it. 
		ObjectStates = new List<ObjectState> ();
		addEventTriggers ();
	}


	// Update is called once per frame
	void Update ()
	{
	
	}

	void addEventTriggers ()
	{
		GvrPointerInputModule globalInputModule = (GvrPointerInputModule) FindObjectOfType(typeof(GvrPointerInputModule));
		globalInputModule.EventExecutor.OnPointerDown += startRewind;
		globalInputModule.EventExecutor.OnPointerUp += stopRewind;
	}



	//	There's a lot of stuff going on here.
	void FixedUpdate ()
	{
		//	If isRewinding is true, we're going to start rewinding. 
		if (isRewinding) {
			//	We're using interpolation, which if you remember from the Animation lesson,
			//		we take fewer data points and interpolate (estimate) what additional data points
			//		might be between two points. 
			interpolatedRewind ();
		} else {
			//	We want to make sure we have as little memory footprint as possible.
			//		So we want to sample an object's change in position and rotation
			//		instead of recording all positions and rotations at all times. 
			sampleRecord ();
		}
	}

	public void interpolatedRewind ()
	{

		//	This value is pretty important. From this value, we're trying to figure out
		//		a specific value in between the first and second Object State.
		//		Ex. What is the Object State that is 1/5 of the transition between
		//		Object State 1 and Object State 2? 

		slowdown = Mathf.Lerp (0, 1, slowdown_t);
		float frameDerivedInterpolation = slowdown;
	
		if (ObjectStates.Count > 1) {
			gameObject.GetComponent<Renderer> ().enabled = true;
			gameObject.GetComponent<Rigidbody> ().useGravity = false;

			//	lerpInterpolationBetweenTwoStates is a helper function I defined within the
			//		ObjectState class. Feel free to give it a look!
			ObjectState startingState = ObjectStates [0];
			ObjectState endingState = ObjectStates [1];
			ObjectState interpolatedState = startingState.lerpInterpolationBetweenTwoStates (endingState, frameDerivedInterpolation);

			transform.position = interpolatedState.position;
			transform.rotation = interpolatedState.rotation;

			slowdown_t += 4f * Time.fixedDeltaTime;


			//	Since we're generating the positions in between two Object States,
			//		we need to make sure that we get rid of old Object States that
			//		we've already used. In other words, after we've generated all
			//		the transitions between Object State 1 and Object State 2, we 
			//		need to delete Object State 1 so we don't use it again. 

			pruneSampledObjectStatesByTime ();
		} else {
			gameObject.GetComponent<Rigidbody> ().useGravity = true;
			stopRewind ();
		}
	}

	private void pruneSampledObjectStatesByTime ()
	{
		if (slowdown >= 1f) {
			slowdown = 0;
			slowdown_t = 0;
			ObjectStates.RemoveAt (0);
		}
	}

	public void sampleRecord ()
	{
		if (keyFrameCounter < keyframeSampleRate) {
			keyFrameCounter++;
		} else {
			keyFrameCounter = 0;
			record ();
		}
	}

	private void record ()
	{
		//	This might be pretty interesting. What does this mean? 
		//		Basically, we're defining what the 'Max Rewind Time' in seconds
		//		is and dividing it by the amount of time (in seconds) it took
		//		to complete the last frame including Physics. 
		//		The result is some number that can be used to gauge how many 
		//		ObjectStates we can have given our MaxRewindTime cap.
		if (ObjectStates.Count > Mathf.Round (maxRewindTimeInSec / Time.fixedDeltaTime)) {
			ObjectStates.RemoveAt (ObjectStates.Count - 1);
		}

		ObjectState newState = new ObjectState (transform.position, transform.rotation);
		if (ObjectStates.Count > 0) {
			if (!ObjectStates [0].isEqualTo (newState)) {
				ObjectStates.Insert (0, newState);
			}
		} else {
			ObjectStates.Insert (0, newState);
		}
	}

	public void startRewind() {
		startRewind (null, null);
	}

	public void stopRewind() {
		stopRewind (null, null);
	}

	public void startRewind (GameObject game, BaseEventData eventData)
	{
		if (!game) {
			
			isRewinding = true;
		}
	}

	public void stopRewind (GameObject game, BaseEventData eventData)
	{
		isRewinding = false;
	}
		
}
