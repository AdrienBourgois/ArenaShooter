using UnityEngine;
using System.Collections;

public class BaseBullet : MonoBehaviour {

    public float speed = 20f;
    Vector3 direction;
	
    public void shoot(Vector3 from, Vector3 to)
    {
        transform.position = from;
        transform.LookAt(to);
        direction = to;
    }

	void FixedUpdate()
    {
        Vector3 position = transform.position;
        position += direction.normalized * speed * Time.deltaTime;
        transform.position = position;
	}

    void destroy()
    {
        Destroy(gameObject);
    }
}
