using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour {
	private Light myLight;

	public static float timer = 30.0f;
	private bool ispaused = true; 


	// Use this for initialization
	void Start () {
		myLight = GetComponent<Light>();

		myLight.enabled = false;

		GameObject.FindObjectOfType (typeof(PlayerMovement));

	}
	
	// Update is called once per frame
	void Update () {
	


		Debug.Log (timer);
		if(timer >= 0.0f)
		{
			if(Input.GetKeyDown(KeyCode.F) && PlayerMovement.collected == true)
			{
				myLight.enabled = !myLight.enabled;

			}

		}

		if(timer <= 0.0f)
		{
			
				myLight.enabled = false;


		}

		if (timer >= 0 && PlayerMovement.collided1 == true) 
		{
			if (!ispaused) 
			{
				timer -= Time.deltaTime;
			}

		}

		if (Input.GetKeyDown(KeyCode.F) && PlayerMovement.collided1 == true) 
		{

			ispaused = !ispaused;

		}

	}




}
