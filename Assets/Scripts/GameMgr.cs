using UnityEngine;
using System.Collections.Generic;

public class GameMgr : MonoBehaviour {

    private static GameMgr instance = null;
    public static GameMgr Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = GameObject.Find("GameMgr").GetComponent<GameMgr>();
            return instance;
        }
    }

    public List<BaseEnemy> enemies = new List<BaseEnemy>();

    public void AddEnemy(BaseEnemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(BaseEnemy enemy)
    {
        enemies.Remove(enemy);
    }
}
