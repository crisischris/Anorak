using UnityEngine;

public class ObjectState 
{
	public Vector3 position;
	public Quaternion rotation;

	public ObjectState ()
	{
		this.position = new Vector3();
		this.rotation = new Quaternion();
	}

	public ObjectState (Vector3 _position, Quaternion _rotation)
	{
		this.position = _position;
		this.rotation = _rotation;
	}
		

	public ObjectState lerpInterpolationBetweenTwoStates(ObjectState nextState, float interpolationValue) {

		ObjectState interpolatedState = new ObjectState ();

		interpolatedState.position = Vector3.Lerp (this.position, nextState.position, interpolationValue);
		interpolatedState.rotation = Quaternion.Slerp (this.rotation, nextState.rotation, interpolationValue);

		return interpolatedState;
	}

	public bool isEqualTo (ObjectState stateToCompare) {
		bool arePositionsEqual = this.position == stateToCompare.position;
		bool areRotationsEqual = this.rotation == stateToCompare.rotation;
		return arePositionsEqual && areRotationsEqual;
	}


	public bool isWithinChangeOfState (ObjectState stateToCompare) {
		bool arePositionsEqual = this.position.Equals(stateToCompare.position);
		bool areRotationsEqual = this.rotation.Equals(stateToCompare.rotation);
		return arePositionsEqual && areRotationsEqual;
	}
}