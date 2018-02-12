using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SubclassSandbox;

public class Stalker : Enemy {

	private float angle;

	protected override void Start (){
		base.Start ();
        speed = Random.Range(0.5f, 0.8f);
        health = 10;
	}

	void Update(){
		Movement ();
	}

	public override void Movement(){
		LookAtPlayer ();
		if (DistanceFromPlayer () > 9.0f) {

			UpdatePosition (TargetDestination (player.transform.position.x, player.transform.position.z), speed);

		} else if ((DistanceFromPlayer () < 6.0f)) {
			UpdatePosition (TargetDestination (player.transform.position.x, player.transform.position.z), -speed * 2);

		} else {
			if (CheckIfTargeted () == true) {
				angle += speed * Time.deltaTime;
				RotateAroundPlayer (angle, 8.9f, speed);
			} 
		}
	}
}
