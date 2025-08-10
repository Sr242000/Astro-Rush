using UnityEngine;

public class SpeedBoostPlatform : MonoBehaviour
{
    public float boostedSpeed = 35f; // Set this to your desired boost value

    private void OnCollisionStay(Collision collision)
    {
        SpaceshipController ship = collision.gameObject.GetComponent<SpaceshipController>();
        if (ship != null)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Set forward speed to boosted value, keep lateral/vertical unchanged
                Vector3 velocity = rb.linearVelocity;
                velocity.z = Mathf.Sign(velocity.z) * boostedSpeed;
                rb.linearVelocity = velocity;
            }
        }
    }
}
