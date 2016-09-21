using UnityEngine;
using System.Collections;

public class BaseBullet : MonoBehaviour {

    public float speed = 20f;
    public float range = 10f;
    Vector3 direction;
    Vector3 previousPosition;

    public void shoot(Vector3 from, Vector3 to)
    {
        transform.position = from;
        transform.LookAt(to);
        direction = to - from;
        previousPosition = transform.position;
    }

	void FixedUpdate()
    {
        Vector3 position = transform.position;
        position += direction.normalized * speed * Time.deltaTime;
        transform.position = position;

        Vector3 delta = position - previousPosition;
        range -= delta.magnitude;
        if (range <= 0)
            destroy();
        previousPosition = position;
	}

    void destroy()
    {
        Destroy(gameObject);
    }
}
