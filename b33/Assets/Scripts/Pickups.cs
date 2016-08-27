using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {


	// Use this for initialization
	void Start () 
	{

		GameObject.FindObjectOfType (typeof(Lighting));

		GameObject.FindObjectOfType (typeof(Damage));


	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter(Collider col)
	{

		if(col.tag == "battery")
		{

			Lighting.timer = 30.0f;
			Destroy (col.gameObject);

		}

		if(col.tag == "health")
		{

			Damage.health += 2.0f;
			Destroy (col.gameObject);

			Debug.Log ("health restored: " + Damage.health);

		}

	}

}
