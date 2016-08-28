using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lore : MonoBehaviour {

	public Image image;
	// Use this for initialization
	void Start () {

		image.GetComponent<Image>();

		image.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	

		image.GetComponent<Image>();

		if (Input.GetKeyDown (KeyCode.Escape) == true) 
		{

			image.enabled = false;

		}

	}

	void OnTriggerEnter(Collider col)
	{

		if(col.gameObject.tag == "Player")
		{

			image.enabled = true;

		}

	}

}
