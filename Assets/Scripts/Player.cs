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

    public Vector3 deltaCamera = new Vector3(0,3,-3);
    public Camera cam { get; private set; }
    public float bulletCooldowm = 0.7f;
    float nextBulletColldown = 0f;
    GameObject cursor = null;
    Vector3 shootDirection = new Vector3();


    CharacterController charaController = null;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        nextBulletColldown = bulletCooldowm;
        cam = GetComponentInChildren<Camera>();
        cam.transform.LookAt(transform);
        cursor = GameObject.Find("Cursor");
        charaController = GetComponent<CharacterController>();
    }

    void Update() {
        UpdatePosition();
        UpdateCursor();
    }
    void UpdateCursor()
    {
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
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;
        if (Input.GetButton("Jump"))
            moveDirection.y = jumpSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        charaController.Move(moveDirection * Time.deltaTime);

        Vector3 position = transform.position;
        cam.transform.position = position + deltaCamera;

        if (nextBulletColldown > 0)
            nextBulletColldown -= Time.deltaTime;
        else if (nextBulletColldown < 0)
            nextBulletColldown = 0;

        if (Input.GetButton("Fire1") && nextBulletColldown == 0)
        {
            BaseBullet bulletPrefab = Resources.Load<BaseBullet>("Prefabs/BaseBullet");
            BaseBullet bullet = Instantiate(bulletPrefab);
            bullet.shoot(transform.position, new Vector3(shootDirection.x, position.y, shootDirection.z));
            nextBulletColldown = bulletCooldowm;
        }
    }
}
