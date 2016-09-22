using UnityEngine;

public class Cursor : MonoBehaviour {

    Camera cam = null;

    void Awake()
    {
        cam = PlayerCamera.Instance;
    }

    void Update()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(cam.ScreenPointToRay(Input.mousePosition), 50);
        if(hits.Length > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (LayerMask.NameToLayer("Terrain") == hit.collider.gameObject.layer)
                {
                    Vector3 hitPosition = hit.point;
                    hitPosition.y += 0.01f;
                    transform.position = hitPosition;
                    return;
                }
            }
        }
        
    }
}
