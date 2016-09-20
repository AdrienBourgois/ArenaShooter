using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float playerSpeed = 2f;
    public Vector3 deltaCamera = new Vector3(0,3,-3);
    Camera cam = null;
    public float bulletCooldowm = 0.7f;
    float nextBulletColldown = 0f;

    void Awake()
    {
        nextBulletColldown = bulletCooldowm;
        cam = GetComponentInChildren<Camera>();
        cam.transform.LookAt(transform);
    }
	
	void Update () {
        Vector3 position = transform.position;
        cam.transform.position = position + deltaCamera;

        if (nextBulletColldown > 0)
            nextBulletColldown -= Time.deltaTime;
        else if (nextBulletColldown < 0)
            nextBulletColldown = 0;

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            position.x += Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
            position.z += Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
            transform.position = position;
        }

        if (Input.GetButton("Fire1") && nextBulletColldown == 0)
        {
            BaseBullet bulletPrefab = Resources.Load<BaseBullet>("Prefabs/BaseBullet");
            BaseBullet bullet = Instantiate(bulletPrefab);
            bullet.shoot(transform.position, new Vector3(20, 1, 20));
            nextBulletColldown = bulletCooldowm;
        }

    }
}
