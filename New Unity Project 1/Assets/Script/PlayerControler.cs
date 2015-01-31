using UnityEngine;
using System.Collections;
 
public class PlayerControler : MonoBehaviour {
	public float speed;

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); 
		rigidbody.AddTorque(movement * speed * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "PickUp") {
			Attach(collision);
			print("pick");
		}
	}
	
	void Attach(Collision collision)
	{
		if(collision.gameObject.GetComponent("Rigidbody") != null)
		{
			Destroy(collision.gameObject.rigidbody);
			collision.transform.parent = transform;
			print("attach");
		}
	}

}
