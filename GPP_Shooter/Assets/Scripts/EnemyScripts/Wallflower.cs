using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SubclassSandbox;

public class Wallflower : Enemy{

	protected override void Start (){
		base.Start ();
        speed = Random.Range(1, 1.5f);
        health = 15;
	}

	void Update(){
		Movement ();
	}

	public override void Movement(){
		LookAtPlayer ();
		
		if (CheckIfTargeted () == false) {
			UpdatePosition (TargetDestination (player.transform.position.x, transform.position.z), speed);
		} else {
			if (player.transform.position.x != 0) {
				float adj = player.transform.position.x / Mathf.Abs (player.transform.position.x);
				UpdatePosition (TargetDestination (player.transform.position.x - (15 * adj), transform.position.z), speed);
			}
		}
	}
}
