using UnityEngine;

public class SlowDownPlatform : MonoBehaviour
{
    public float slowDrag = 10f;

    void OnCollisionEnter(Collision collision)
    {
        SpaceshipController ship = collision.gameObject.GetComponent<SpaceshipController>();
        if (ship != null)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearDamping = slowDrag;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        SpaceshipController ship = collision.gameObject.GetComponent<SpaceshipController>();
        if (ship != null)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearDamping = 0f; // or your normal drag value
            }
        }
    }
}
