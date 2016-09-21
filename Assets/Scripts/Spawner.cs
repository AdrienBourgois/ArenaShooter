using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public float cooldown = 2f;
    float nextSpawnCooldown = 0f;
    public GameObject enemyPrefab = null;

	void Awake () {
        nextSpawnCooldown = cooldown;
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
}
