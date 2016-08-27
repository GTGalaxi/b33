using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour {

	public static bool collided1 = false;
	public static int turnonmesh;
	public static bool collected = false;
	private bool jumps = false;
	public float speed = 1.0f;
	private Rigidbody rb;
	//public GameObject door;
	public float topSpeed = 5.0f;
	public float slowSpeed = 1.2f;
	public Animator animator;

	public float jumpvelocity = 5.0f;


	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody> ();
		animator = GetComponent<Animator> ();
		Debug.Log (speed);
	}

	// Update is called once per frame
	void FixedUpdate () {


		var move = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f, 0f);
		rb.velocity += move * speed * Time.deltaTime;

		if (rb.velocity.magnitude > topSpeed)
			rb.velocity = rb.velocity.normalized * topSpeed;
		
		if (Input.GetAxisRaw ("Horizontal") == 1) {
			animator.SetBool ("Run", true);
			transform.localScale = new Vector3(30f, 30f, 30f);
		}

		else if (Input.GetAxisRaw ("Horizontal") == -1)
		{
			animator.SetBool ("Run", true);
			transform.localScale = new Vector3(30f, 30f, -30f);
		}

		if (Input.GetAxisRaw ("Horizontal") == 0) {
			rb.velocity = new Vector3 (Mathf.Lerp(rb.velocity.x, 0f, slowSpeed * Time.deltaTime), rb.velocity.y, 0f);
			animator.SetBool ("Run", false);
		}



		if (Input.GetKey(KeyCode.Space) == true/* && jumps == false*/)
		{
			StartCoroutine (jump ());
			jumps = true;
		}

	}

	IEnumerator jump()
	{
		rb.velocity = new Vector3(rb.velocity.x, jumpvelocity, 0);
		animator.SetBool ("Jump", true);
		yield return new WaitForSeconds(0);
		animator.SetBool ("Jump", false);
	}

	void OnCollisionExit(Collision col)
	{
		jumps = false;
	}

	void OnCollisionEnter(Collision col)
	{
		jumps = true;
	}

    void OnTriggerEnter(Collider col)
	{

		if(col.tag == "flash")
		{

			Debug.Log ("1");
			collected = true;
			turnonmesh++;
			Destroy (col.gameObject);
			collided1 = true;
			//Destroy (door);

		}

	}

}
