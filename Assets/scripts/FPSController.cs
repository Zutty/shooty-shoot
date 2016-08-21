using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {
	
	public float speed = 6F;
	public float gravity = 20F;
	public float jump = 8F;
	
	private CharacterController controller;
	private Vector3 motion = Vector3.zero;
	
	void Start () {
		controller = GetComponent<CharacterController> ();
	}
	
	void Update () {
		if(controller.isGrounded) {
			motion = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			motion = transform.TransformDirection (motion);
			motion *= speed;
			if(Input.GetButton("Jump")) {
				motion.y = jump;
			}
		}
		motion.y -= gravity * Time.deltaTime;
		controller.Move(motion * Time.deltaTime);
	}
}
