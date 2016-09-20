using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {

    public int life = 1;
    public float enemySpeed = 2f;
    public float gravity = 20f;
    Player player = null;
    CharacterController enemyController = null;

    void Awake()
    {
        enemyController = GetComponent<CharacterController>();
        player = Player.Instance;
    }

    public void Hit()
    {
        --life;
        if (life <= 0)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject go = collision.gameObject;
        if (go.layer == LayerMask.NameToLayer("Bullet"))
        {
            Hit();
            Destroy(go);
        }
    }

    void Update () {
        Vector3 direction = player.transform.position - transform.position;
        direction.y -= gravity * Time.deltaTime;
        enemyController.SimpleMove(direction.normalized * enemySpeed);
	}
}
