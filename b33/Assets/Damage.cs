using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	public float health = 2.0f;
	int damageAmount;
	int damageTime;

	public GameObject player;


	// Use this for initialization
	void Start () 
	{


		GameObject.FindObjectOfType (typeof(PlayerMovement));

	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0.0f) {
			Debug.Log ("Player destroyed");

			StartCoroutine (DamageOverTimeCoroutine2 (1f));
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			health--;

			//StartCoroutine (DamageOverTimeCoroutine (1f));

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
		while (health <= 0)
		{
			player.GetComponent<PlayerMovement> ().enabled = false;
			yield return new WaitForSeconds (3f);
			Destroy (gameObject);
		}

	}

}

