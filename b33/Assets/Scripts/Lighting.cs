using UnityEngine;
using System.Collections;

public class Lighting : MonoBehaviour {
	
	private Light myLight;

	[SerializeField]
	private Stat2 battery;
	public Transform BatBar;

	private bool ispaused = true; 
	public static int pickup;

	void Awake()
	{
		//Initializes the stats
		battery.Initialize();
	}

	// Use this for initialization
	void Start () {

		myLight = GetComponent<Light>();

		myLight.enabled = false;

		GameObject.FindObjectOfType (typeof(PlayerMovement));

	}
	
	// Update is called once per frame
	void Update () {
	

		if (PlayerMovement.pickup == true) 
		{

			battery.CurrentValue = battery.MaxVal;
			PlayerMovement.pickup = false;

		}

		BatBar.transform.localScale = new Vector3(0.033f*battery.CurrentValue, 1f, 1f);

		if(battery.CurrentValue >= 0.0f)
		{
			if(Input.GetKeyDown(KeyCode.F) && PlayerMovement.collected == true)
			{
				myLight.enabled = !myLight.enabled;

			}

		}

		if(battery.CurrentValue <= 0.0f)
		{
			
				myLight.enabled = false;


		}

		if (battery.CurrentValue >= 0 && PlayerMovement.collided1 == true) 
		{
			if (!ispaused) 
			{
				battery.CurrentValue -= Time.deltaTime;
			}

		}

		if (Input.GetKeyDown(KeyCode.F) && PlayerMovement.collided1 == true) 
		{

			ispaused = !ispaused;

		}

	}




}
