using UnityEngine;

public class Cursor : MonoBehaviour {

    Camera cam = null;

    void Awake()
    {
        cam = PlayerCamera.Instance;
    }

    void Update()
    {
        RaycastHit hit = new RaycastHit();
        bool isHit = false;
        isHit = Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit);
        if (isHit && LayerMask.NameToLayer("Terrain") == hit.collider.gameObject.layer)
        {
            Vector3 hitPosition = hit.point;
            hitPosition.y += 0.01f;
            transform.position = hitPosition;
        }
    }
}
