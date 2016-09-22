using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {

    public int life = 1;
    public float enemySpeed = 0.2f;
    public float gravity = 20f;
    public int chanceToDrop = 10;
    Player player = null;

    void Awake()
    {
        GameMgr.Instance.AddEnemy(this);
        player = Player.Instance;
    }

    public void Hit()
    {
        --life;
        if (life <= 0)
            Kill();
    }

    public void Kill()
    {
        if (Random.Range(0, 100) < chanceToDrop)
            Drop();
        GameMgr.Instance.RemoveEnemy(this);
        Destroy(gameObject);
    }

    void Drop()
    {
        Object pickup = Resources.Load("Prefabs/Pickups/ExplosionPickup");
        Instantiate(pickup, transform.position, Quaternion.identity);
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
        Vector3 position = transform.position;
        position += (direction.normalized * enemySpeed * Time.deltaTime);
        transform.position = position;
    }
}
