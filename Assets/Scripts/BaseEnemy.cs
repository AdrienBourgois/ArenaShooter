using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {

    public int life = 1;
    public float enemySpeed = 2f;
    Player player = null;
    CharacterController enemyController = null;

    void Awake()
    {
        enemyController = GetComponent<CharacterController>();
        player = Player.Instance;
    }

    public void attackPlayer()
    {
        
    }

	void Update () {
        Vector3 direction = player.transform.position - transform.position;
        enemyController.SimpleMove(direction.normalized * enemySpeed);
	}
}
