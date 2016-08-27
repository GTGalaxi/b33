using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

	[SerializeField]
	private Stat2 battery;

	// Use this for initialization
	void Start () 
	{

		GameObject.FindObjectOfType (typeof(Lighting));


	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnTriggerEnter(Collider col)
	{

		if(col.tag == "battery")
		{
			GameObject.FindObjectOfType (typeof(Stat2));
			battery.CurrentValue = 30.0f;
			Destroy (col.gameObject);

		}
	}

}
