using UnityEngine;

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

    public int life = 10;

    public float bulletCooldowm = 0.7f;
    float nextBulletCooldown = 0f;
    GameObject cursor = null;

    CharacterController charaController = null;
    public float speed = 6.0f;
    public float speedRot = 6.0f;
    public float jumpSpeed = 10.0f;
    private Vector3 moveDirection;

    void Awake()
    {
        nextBulletCooldown = bulletCooldowm;
        cursor = GameObject.Find("Cursor");
        charaController = GetComponent<CharacterController>();
        moveDirection = new Vector3();
    }

    void Update() {
        UpdatePosition();
        UpdateShoot();
    }

    void UpdatePosition()
    {
        if (charaController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y += Physics.gravity.y * Time.deltaTime;
        charaController.Move(moveDirection * Time.deltaTime);
    }

    void UpdateShoot()
    {
        if (nextBulletCooldown > 0)
            nextBulletCooldown -= Time.deltaTime;
        else if (nextBulletCooldown < 0)
            nextBulletCooldown = 0;

        if (Input.GetButton("Fire1") && nextBulletCooldown == 0)
            Shoot();
    }

    void Shoot()
    {
        BaseBullet bulletPrefab = Resources.Load<BaseBullet>("Prefabs/BaseBullet");
        BaseBullet bullet = Instantiate(bulletPrefab);
        Vector3 cursorPosition = cursor.transform.position;
        bullet.shoot(transform.position, new Vector3(cursorPosition.x, transform.position.y, cursorPosition.z));
        nextBulletCooldown = bulletCooldowm;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            --life;
            Destroy(collision.gameObject);
        }
    }
}
