using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour {

	public static bool collected = false;
	private bool jumps = false;
	public float speed = 1.0f;
	private Rigidbody rb;

	public float jumpvelocity = 5.0f;


	// Use this for initialization
	void Awake () {

		rb = GetComponent<Rigidbody> ();
		Debug.Log (speed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		


		rb.velocity = (new Vector3 (Input.GetAxis("Horizontal")*speed, rb.velocity.y, 0));


		if(Input.GetKey(KeyCode.Space) == true && jumps == false)
		{
			StartCoroutine (jump ());
			jumps = true;
		}



	}

	IEnumerator jump()
	{
		rb.velocity = new Vector3(0, jumpvelocity, 0);

		yield return new WaitForSeconds(0);

	}

	void OnCollisionEnter(Collision col)
	{

		if(col.gameObject.tag == "Map")
		{

			jumps = false;
		}



	}

	void OnTriggerEnter(Collider col)
	{

		if(col.tag == "flash")
		{

			Debug.Log ("1");
			collected = true;
			Destroy (col.gameObject);

		}

	}

}
