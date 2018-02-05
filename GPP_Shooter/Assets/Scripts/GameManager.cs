using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SubclassSandbox;

public class GameManager : MonoBehaviour {
	
	Vector2 widthRange = new Vector2(-15, 15);
	Vector2 heightRange = new Vector2 (-8, 8);

	private float t = 0;
	[SerializeField] private float timeBetweenSpawns;

	void Start () {
		t = timeBetweenSpawns;

		float hor = Random.Range (widthRange.x, widthRange.y);
		Vector3 _wallFlowerPos = new Vector3 (hor, 0, heightRange.y * (hor / Mathf.Abs (hor))); 
		SpawnEnemy<Wallflower> (_wallFlowerPos, "Enemies/Wallflower");
	}


	void SpawnEnemy<T>(Vector3 pos, string t) where T : Enemy {
		GameObject eneGO = Instantiate ((GameObject)Resources.Load (t), pos, Quaternion.identity);
		Enemy enemy  = null;
		enemy = eneGO.AddComponent<T>();

	}

	void Update(){
		if (t > 0) {
			t -= Time.deltaTime;
		} else {


			Vector3 _stalkerPos = new Vector3 (Random.Range (widthRange.x, widthRange.y), 0, Random.Range (heightRange.x, heightRange.y)); 
			SpawnEnemy<Stalker> (_stalkerPos, "Enemies/Stalker");

			t = timeBetweenSpawns;
			
		}
		
	}
}
