using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private static Player instance = null;
    public static Player Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = GameObject.Find("Player").GetComponent<Player>();
            return instance;
        }
    }

    public float playerSpeed = 2f;
    public Vector3 deltaCamera = new Vector3(0,3,-3);
    public Camera cam { get; private set; }
    public float bulletCooldowm = 0.7f;
    float nextBulletColldown = 0f;
    GameObject cursor = null;
    Vector3 shootDirection = new Vector3();

    void Awake()
    {
        nextBulletColldown = bulletCooldowm;
        cam = GetComponentInChildren<Camera>();
        cam.transform.LookAt(transform);
        cursor = GameObject.Find("Cursor");
    }
	
	void Update () {
        UpdatePosition();
        RaycastHit hit = new RaycastHit();
        bool isHit = false;
        isHit = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit);
        if (isHit && LayerMask.NameToLayer("Terrain") == hit.collider.gameObject.layer)
        {
            cursor.transform.position = hit.point;
            shootDirection = hit.point;
        }
    }

    void UpdatePosition()
    {
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
            bullet.shoot(transform.position, new Vector3(shootDirection.x, position.y, shootDirection.z));
            nextBulletColldown = bulletCooldowm;
        }
    }
}
