using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
	void Update () {
		Vector3 camPos = Camera.main.transform.position;
		camPos.y = transform.position.y;
		transform.LookAt (camPos);
	}
}
