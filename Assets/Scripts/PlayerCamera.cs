using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public Vector3 deltaCamera = new Vector3(0, 10, -10);
    Player player = null;

    private static Camera instance = null;
    public static Camera Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = GameObject.Find("Player Camera").GetComponent<Camera>();
            return instance;
        }
    }

    void Awake () {
        player = Player.Instance;
        transform.LookAt(player.transform);
    }
	
	void Update () {
        Vector3 playerPosition = player.transform.position;
        transform.position = playerPosition + deltaCamera;
    }
}
