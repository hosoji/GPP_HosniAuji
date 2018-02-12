using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SubclassSandbox{

	public abstract class Enemy : MonoBehaviour{

		public float speed;
		public float health; 

		public GameObject player;

		protected GameObject GetPlayer(){
			return GameObject.Find ("Player");
		}

		protected virtual void Start(){
			player = GetPlayer ();
		}

		////////////////////////////
		/// MOVEMENT AND ORIENTATION
		////////////////////////////

		public abstract void Movement ();

		protected Vector3 TargetDestination(float x, float z){
			return new Vector3 (x, 0.0f, z);
		}

		protected void LookAtPlayer(){
			transform.LookAt (player.transform);
		}

		protected void UpdatePosition(Vector3 target, float s){
			transform.position += (target - transform.position) * (Time.deltaTime * s);
		}

		protected void RotateAroundPlayer(float _angle, float radius, float s){
			var offset = new Vector3(Mathf.Sin(_angle),0, Mathf.Cos(_angle)) * radius;
			var newTarget = player.transform.position + offset;
			UpdatePosition (newTarget, s);
		}

		protected bool CheckIfTargeted(){
			bool check = false;

			Vector3 targetDir = transform.position - player.transform.position;
			float angle = Vector3.Angle(targetDir, player.transform.forward);

			if (angle < 50f) {
				check = true;
			}
			return check;
		}

		protected float DistanceFromPlayer(){
			return Vector3.Distance (transform.position, player.transform.position);
		}

		////////////////////////////
		/// ATTACKING
		////////////////////////////

	}
}
