using UnityEngine;
using System.Collections;

public class ResetVolume : MonoBehaviour 
{
	public string myObject;
	public Vector3 resetPosition;

	private GameObject mySphere;
	private Rigidbody rigidBody;


	void Start()
	{
		mySphere = GameObject.Find (myObject);
		rigidBody = mySphere.GetComponent<Rigidbody> ();
	}

	void OnTriggerExit(Collider other)
	{
		// if ball exits reset volume;
		if(other.gameObject == mySphere)
		{
			//reset position
			other.transform.position = resetPosition;

			// reset velocity
			rigidBody.velocity = Vector3.zero;

			//reset angular velocity
			rigidBody.angularVelocity = Vector3.zero;

			// reset orientation
			other.transform.rotation = Quaternion.identity;

		}
	}
}

