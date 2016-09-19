using UnityEngine;

public class DestroyOnCompletion : MonoBehaviour {

	private ParticleSystem particles;

	void Start () {
		particles = GetComponent<ParticleSystem> ();
	}
	
	void Update () {
		if(!particles.IsAlive()) {
			Destroy (gameObject);
		}
	}
}
