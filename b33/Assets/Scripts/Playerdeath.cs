using UnityEngine;
using System.Collections;

public class Playerdeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{

		if(col.gameObject.tag == "bee")
		{
			
			Application.LoadLevel ("Lose");

		}

	}

}
