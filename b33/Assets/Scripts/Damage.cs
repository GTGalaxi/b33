using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	
	[SerializeField]
	private Stat health;
	public Transform HpBar;
	int damageAmount;
	int damageTime;

	public GameObject player;

	void Awake()
	{
		//Initializes the stats
		health.Initialize();
	}

	// Use this for initialization
	void Start () 
	{


		GameObject.FindObjectOfType (typeof(PlayerMovement));

	}
	
	// Update is called once per frame
	void Update () {
		
		HpBar.transform.localScale = new Vector3(0.01f*health.CurrentValue, 1f, 1f);


		if (health.CurrentValue <= 0.0f) {
			Debug.Log ("Player destroyed");

			StartCoroutine (DamageOverTimeCoroutine2 (1f));
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy") 
		{
			Debug.Log ("Hit Enemy");
			health.CurrentValue -= 25;
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "health") 
		{
			if (health.CurrentValue < 100)
			{
				health.CurrentValue += 50;
				Destroy(col.gameObject);
			}
		}
	}


	/*	void OnCollisionExit(Collision collisionInfo)
	{

		StopAllCoroutines();

	}

	IEnumerator DamageOverTimeCoroutine(float wait)
	{
		while (health >= 0)
		{
			health -= 1.0f;


			Debug.Log (health);
			yield return new WaitForSeconds (1f);
		}

	}
*/
	IEnumerator DamageOverTimeCoroutine2(float wait)
	{
		while (health.CurrentValue <= 0)
		{
			player.GetComponent<PlayerMovement> ().enabled = false;
			yield return new WaitForSeconds (3f);
			Destroy (gameObject);
		}

	}

}

