using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {
	
	public float speed = 6F;
	public float gravity = 20F;
	public float jump = 8F;
	
	private CharacterController controller;
	private Vector3 motion = Vector3.zero;

	private float _bobTimer;
	private Camera _camera;
	
	void Start () {
		controller = GetComponent<CharacterController> ();
		_camera = GetComponentInChildren<Camera> ();
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

		Vector3 v = controller.velocity;
		v.y = 0;

		float bob = 0f;

		if (v.magnitude > 0.001f) {
			bob = Mathf.Sin (2f * Mathf.PI * v.magnitude * _bobTimer * 0.15f);
			_bobTimer += Time.deltaTime;
		} else {
			_bobTimer = 0f;
		}

		Vector3 b = new Vector3 ();
		b.y = 0.88f + (bob * 0.05f);
		_camera.transform.localPosition = b;
	}
}
