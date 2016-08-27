using UnityEngine;
using System.Collections;

public class Cameramove : MonoBehaviour {

	public Transform target;

	public float offsetx;

	public float offsety;

	public float offsetz;

	private float lockpos;

	private bool jumps = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Space) == true && jumps == false)
		{
			jumps = true;
		}

		if(jumps)
		{
			transform.position = new Vector3 (target.transform.position.x + offsetx, lockpos + offsety, offsetz);

		}
		else
		{

			transform.position = new Vector3 (target.transform.position.x + offsetx, target.transform.position.y + offsety, offsetz);

			lockpos = target.transform.position.y;

		}
			

	}

	void OnCollisionEnter(Collision col)
	{

		if(col.gameObject.tag == "Map")
		{

			jumps = false;

		}

	}

	void OnCollisionExit(Collision col)
	{

		if (col.gameObject.tag == "Map")
		{

			jumps = true;
		}
}
}
