using UnityEngine;
using System.Collections;

public class enableflashlight : MonoBehaviour {

	public Renderer rend;
	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer>();

		rend.enabled = false;

		GameObject.FindObjectOfType (typeof(PlayerMovement));

		GameObject.FindObjectOfType (typeof(Lighting));

	}
	
	// Update is called once per frame
	void Update () {
	
		if(PlayerMovement.turnonmesh == 1)
		{
			
			rend.enabled = true;

		}

	}

}
