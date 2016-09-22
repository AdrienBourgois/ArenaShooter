using UnityEngine;

abstract public class BasePickup : MonoBehaviour
{
    abstract public void Effect();

    void Update()
    {
        Vector3 rotation = new Vector3(0, 10, 0);
        transform.Rotate(rotation * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            Effect();
    }

    protected void Destroy()
    {
        Destroy(gameObject);
    }
}
