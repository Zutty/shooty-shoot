using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public float sensitivity = 2F;

	private Vector3 euler;

	void Start () {
		euler = transform.localRotation.eulerAngles;
	}
	
	void Update () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		euler.y += Input.GetAxisRaw ("Mouse X") * sensitivity;
		euler.x -= Input.GetAxisRaw ("Mouse Y") * sensitivity;

		euler.x = Mathf.Clamp (euler.x, -90f, 90f);

		transform.localRotation = Quaternion.Euler(euler);
	}
}
