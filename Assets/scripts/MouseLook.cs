using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public float sensitivity = 2F;

	private Vector3 direction;

	void Start () {
		direction = transform.localRotation.eulerAngles;
	}
	
	void Update () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		direction.y += Input.GetAxisRaw ("Mouse X") * sensitivity;
		direction.x -= Input.GetAxisRaw ("Mouse Y") * sensitivity;
		transform.localRotation = Quaternion.Euler(direction);
	}
}
