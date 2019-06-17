using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
	public float speed = 10.0f;

	bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
		float vertical = Input.GetAxis ("Vertical") * speed;
		float horizontal = Input.GetAxis ("Horizontal") * speed;
		vertical *= Time.deltaTime;
		horizontal *= Time.deltaTime;

		transform.Translate (horizontal, 0, vertical);

		if (Input.GetKeyDown ("escape"))
			Cursor.lockState = CursorLockMode.None;

		RaycastHit hit;
		Vector3 physicsCentre = this.transform.position +
			this.GetComponent<BoxCollider> ().center;

		Debug.DrawRay (physicsCentre, Vector3.down, Color.red, 1);
		if (Physics.Raycast (physicsCentre, Vector3.down, out hit, 1.2f)) 
		{
			if (hit.transform.gameObject.tag != "Player") 
			{
				onGround = true;
			}
		} 
		else 
		{
			onGround = false;
		}

		if (Input.GetKeyDown ("space")&& onGround) 
		{
			this.GetComponent<Rigidbody> ().AddForce (Vector3.up * 250);
		}
	}
}
