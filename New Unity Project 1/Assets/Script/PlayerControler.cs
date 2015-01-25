using UnityEngine;
using System.Collections;
 
public class PlayerControler : MonoBehaviour {
	public float speed;

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); 
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PickUp") {
			Attach(other);
			print("pick");
		}
	}
	
	void Attach(Collider other)
	{
		if(other.gameObject.GetComponent("Rigidbody") != null)
		{
			Destroy(other.gameObject.rigidbody);
			other.transform.parent = transform;
			print("attach");
		}
	}

}
