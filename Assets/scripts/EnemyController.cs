using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	
	public float health = 10f;
	public float attackRange = 3f;
	
	private NavMeshAgent navMeshAgent;
	private Transform target;
	
	void Start() {
		navMeshAgent = GetComponent<NavMeshAgent> ();
	}
	
	void OnTriggerStay(Collider other) {
		if(other.CompareTag("Player")) {
			navMeshAgent.SetDestination(other.transform.position);
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.CompareTag("Player")) {
			navMeshAgent.Stop();
			navMeshAgent.ResetPath();
		}
	}
	
	void OnHit(float damage) {
		health -= damage;
		
		if(health <= 0) {
			Destroy(gameObject);
		}
	}
}