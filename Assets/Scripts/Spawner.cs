using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public int life = 5;
    public float cooldown = 2f;
    float nextSpawnCooldown = 0f;
    public GameObject enemyPrefab = null;
    Material material = null;

	void Awake () {
        nextSpawnCooldown = cooldown;
        material = GetComponent<Renderer>().material;
	}
	
	void Update () {
        nextSpawnCooldown -= Time.deltaTime;
        if (nextSpawnCooldown <= 0)
        {
            spawn();
            nextSpawnCooldown = cooldown;
        }
	}

    void spawn()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.FromToRotation(transform.position, Player.Instance.transform.position));
    }

    void OnTriggerEnter(Collider collision)
    {
        GameObject go = collision.gameObject;
        if (go.layer == LayerMask.NameToLayer("Bullet"))
        {
            Hit();
            Destroy(go);
        }
    }

    public void Hit()
    {
        --life;
        Color color = material.color;
        color.a -= (color.a / (life + 1));
        material.color = color;
        if (life <= 0)
            Destroy(gameObject);
    }
}
