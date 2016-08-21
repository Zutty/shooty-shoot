using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public Image crosshair;
	public Color highlightColour = Color.red;
	public float fireRate = 0.5f;
	public float damage = 5f;

	private Camera mainCamera;
	private Color defaultColour;
	private float fireTimer = 0f;

	void Start () {
		mainCamera = GetComponentInChildren<Camera> ();
		defaultColour = crosshair.color;
	}
	
	void Update () {
		RaycastHit hit;

		if (Physics.Raycast (mainCamera.ViewportPointToRay (new Vector3 (.5F, .5F, 0)), out hit)) {
			var hitEnemy = hit.transform.tag == "Enemy";

			crosshair.color = hitEnemy ? highlightColour : defaultColour;

			if(hitEnemy && Input.GetButtonDown("Fire1") && Time.time > fireTimer) {
				fireTimer = Time.time + fireRate;
				hit.collider.SendMessageUpwards("OnHit", damage);
			}
		}
	}
}
