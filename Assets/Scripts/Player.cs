using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
        if (Input.GetButton("Horizontal"))
        {
            Vector3 position = transform.position;
            position.x += Input.GetAxis("Horizontal") * Time.deltaTime;
            transform.position = position;
        }
	}
}
