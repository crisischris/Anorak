using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

	//	This is our 'rewind' properties.
	public List<ObjectState> ObjectStates;
	public int keyframeSampleRate = 4;
	public float maxRewindTimeInSec = 15.0f;

	//	These are private, helper variables. These are NOT meant to be seen outside this class.
	private bool isRewinding = false;
	private float keyFrameCounter = 0; 

	//	Start is used to initialize the beginning of the script. 
	void Start () {
		//	We must instantiate an empty list of ObjectState and store it
		//		in ObjectStates in order to use it. 
		ObjectStates = new List<ObjectState> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			startRewind ();
		} else {
			stopRewind ();
		}
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
		
	public void interpolatedRewind() {

		//	This value is pretty important. From this value, we're trying to figure out
		//		a specific value in between the first and second Object State.
		//		Ex. What is the Object State that is 1/5 of the transition between
		//		Object State 1 and Object State 2? 

		float frameDerivedInterpolation =  keyFrameCounter / keyframeSampleRate;

		if (ObjectStates.Count > 1)
		{

			//	lerpInterpolationBetweenTwoStates is a helper function I defined within the
			//		ObjectState class. Feel free to give it a look!
			ObjectState startingState = ObjectStates [0];
			ObjectState endingState = ObjectStates [1];
			ObjectState interpolatedState = startingState.lerpInterpolationBetweenTwoStates (endingState, frameDerivedInterpolation);

			transform.position = interpolatedState.position;
			transform.rotation = interpolatedState.rotation;

			//	Since we're generating the positions in between two Object States,
			//		we need to make sure that we get rid of old Object States that
			//		we've already used. In other words, after we've generated all
			//		the transitions between Object State 1 and Object State 2, we 
			//		need to delete Object State 1 so we don't use it again. 
			pruneSampledObjectStates ();
		} else {
			stopRewind ();
		}
	}

	private void pruneSampledObjectStates () {
		if (keyFrameCounter > 0) {
			keyFrameCounter--;
		} else {
			keyFrameCounter = keyframeSampleRate;
			ObjectStates.RemoveAt (0);
		}
	}

	public void sampleRecord () {
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
		if (ObjectStates.Count > Mathf.Round(maxRewindTimeInSec / Time.fixedDeltaTime))
		{
			ObjectStates.RemoveAt(ObjectStates.Count - 1);
		}

		ObjectStates.Insert(0, new ObjectState(transform.position, transform.rotation));
	}

	public void startRewind ()
	{
		isRewinding = true;
	}

	public void stopRewind ()
	{
		isRewinding = false;
	}

	private void hasGvrClickTrigger ()
	{
		//need to update the data here otherwise we dont get mouse clicks; this is because we are 
		//automatically creating the GVRSDK (seems like a bug)
//		GvrViewer.Instance.UpdateState (); 
//		if (GvrViewer.Instance.Triggered) {
//			stateMachine.SetTrigger (AnimationName);
//		}
	}
}
