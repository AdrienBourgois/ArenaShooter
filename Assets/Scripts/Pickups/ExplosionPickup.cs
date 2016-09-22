using UnityEngine;
using System.Collections.Generic;

public class ExplosionPickup : BasePickup {

    float radius = 5f;

    public override void Effect()
    {
        List<BaseEnemy> enemiesToDestroy = new List<BaseEnemy>();
        foreach(BaseEnemy enemy in GameMgr.Instance.enemies)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) < radius)
                enemiesToDestroy.Add(enemy);
        }

        foreach (BaseEnemy enemy in enemiesToDestroy)
            enemy.Kill();

        Destroy();
    }
}
