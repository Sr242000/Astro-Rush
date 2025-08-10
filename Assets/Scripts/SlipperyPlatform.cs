using UnityEngine;

public class SlipperyPlatformIce : MonoBehaviour
{
    [Header("Slip Settings")]
    [Tooltip("Strength of the slipping force applied to the ship")]
    public float slipForce = 40f;

    [Tooltip("How many left/right cycles per second")]
    public float wobbleFrequency = 1.5f; // Hz

    [Tooltip("Small random deviation added to wobble direction (0 = perfectly smooth)")]
    [Range(0f, 1f)]
    public float randomness = 0.05f;

    private void OnCollisionStay(Collision collision)
    {
        // Check if collided object is the spaceship
        SpaceshipController ship = collision.gameObject.GetComponent<SpaceshipController>();
        if (ship != null)
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null && rb.linearVelocity.sqrMagnitude > 0.1f) // Only apply if moving
            {
                // Get base slip direction (perpendicular to movement)
                Vector3 baseSlipDir = Vector3.Cross(Vector3.up, rb.linearVelocity).normalized;

                // Smoothly oscillate left <-> right
                float wave = Mathf.Sin(Time.time * wobbleFrequency * Mathf.PI * 2f);

                // Apply wobble multiplier
                Vector3 slipDirection = baseSlipDir * wave;

                // Add small optional randomness for realism
                slipDirection += Random.insideUnitSphere * randomness;
                slipDirection.y = 0; // Keep horizontal slip

                // Apply force so it keeps sliding
                rb.AddForce(slipDirection.normalized * slipForce * Time.fixedDeltaTime, ForceMode.Impulse);
            }
        }
    }
}
