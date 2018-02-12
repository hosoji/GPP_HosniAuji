using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float speed;



    private GameObject bullet;

	private RaycastHit hit;

	private float distance;
	private Vector3 floor = new Vector3 (0, -17, 0);

	private float t = 0;
	[SerializeField] private float fireDelay = 0f;

    void Start(){
        bullet = GameObject.Find("[GameManager]").GetComponent<PrefabHolder>().normalBulletPrefab;
    }

	void Update () {

		var horizontal = (Input.GetAxis ("Horizontal") * Time.deltaTime) * speed;
		var vertical = (Input.GetAxis ("Vertical") * Time.deltaTime) * speed;

		transform.position = new Vector3 (transform.position.x + horizontal, transform.position.y,transform.position.z + vertical);

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Plane plane = new Plane(Vector3.up, floor);

		if(plane.Raycast(ray, out distance)) {
			Vector3 target = ray.GetPoint(distance);
			Vector3 direction = target-transform.position;
			float rotation = Mathf.Atan2(direction.x, direction.z)* Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0, rotation, 0);
		}

		if (Input.GetMouseButton (0)) {
			if (t > 0) {
				t -= Time.deltaTime;
		
			} else {
				Vector3 pos = GetComponentsInChildren<MeshRenderer> () [1].transform.position;
                Instantiate ((GameObject)bullet, pos, transform.rotation);
				t = fireDelay;
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			t = 0;
		}
	}
}
