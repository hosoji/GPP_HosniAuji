using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SubclassSandbox;
using Managers;

public class GameManager : MonoBehaviour {

    public EnemyManager enemyManager = new EnemyManager();

	private float t = 0;
	[SerializeField] private float timeBetweenChecks;

	void Start () {
        t = timeBetweenChecks;
        enemyManager.Init();
	}

	void Update(){

		if (t > 0) {
			t -= Time.deltaTime;
		} else {
			
            t = timeBetweenChecks;
		}
	}

    private void UpdateManagers(){
        enemyManager.EnemyUpdate();
    }

}
