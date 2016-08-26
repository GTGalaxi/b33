using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour {
	private Light myLight;


	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light>();

		myLight.enabled = !myLight.enabled;

		GameObject.FindObjectOfType (typeof(PlayerMovement));

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.F) && PlayerMovement.collected == true)
		{
			myLight.enabled = !myLight.enabled;

		}



	}




}
