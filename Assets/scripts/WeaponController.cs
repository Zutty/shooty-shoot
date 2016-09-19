using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponController : MonoBehaviour {

	public Image crosshair;
	public Color highlightColour = Color.red;
	public float fireRate = 0.5f;
	public float damage = 5f;
	public AudioClip shootSound;
	public GameObject impactPrefab;

	private Camera mainCamera;
	private Color defaultColour;
	private float fireTimer = 0f;
	private AudioSource audioSource;
	private GameObject muzzleFlash;

	void Start () {
		mainCamera = GetComponentInChildren<Camera> ();
		audioSource = GetComponent<AudioSource>();
		defaultColour = crosshair.color;
		muzzleFlash = transform.Find ("gun/muzzle_flash").gameObject;
		muzzleFlash.SetActive (false);
	}
	
	void Update () {
		RaycastHit raycastHit;
		var hit = Physics.Raycast (mainCamera.ViewportPointToRay (new Vector3 (.5F, .5F, 0)), out raycastHit);

		var hitEnemy = hit && raycastHit.transform.tag == "Enemy";
		crosshair.color = hitEnemy ? highlightColour : defaultColour;

		muzzleFlash.SetActive (false);

		if (Input.GetButtonDown ("Fire1") && Time.time > fireTimer) {
			audioSource.PlayOneShot (shootSound, Random.Range (.5f, 1f));
			fireTimer = Time.time + fireRate;
			muzzleFlash.SetActive (true);

			GameObject impact = Instantiate (impactPrefab);
			impact.transform.position = raycastHit.point;
			impact.transform.rotation = Quaternion.FromToRotation (Vector3.forward, raycastHit.normal);

			if(hitEnemy) {
				raycastHit.collider.SendMessageUpwards("OnHit", damage);
			}
		}
	}
}
