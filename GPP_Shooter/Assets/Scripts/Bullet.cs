using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	
	[SerializeField] private float bulletSpeed = 80;
	[SerializeField] private float bulletDistanceMax;

	private Vector3 startPos;


	void Start () {
		startPos = transform.position;
	}

	void Update () {

		transform.position += transform.forward * Time.deltaTime * bulletSpeed;

		if (Vector3.Distance (transform.position, startPos) > bulletDistanceMax) {
			Destroy (gameObject);
		}
	}
}
