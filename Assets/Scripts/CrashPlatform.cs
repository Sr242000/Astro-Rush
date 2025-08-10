using UnityEngine;

public class CrashPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        SpaceshipController ship = collision.gameObject.GetComponent<SpaceshipController>();
        if (ship != null)
        {
            GameManager.Instance.EndGame();
            // Optionally: add particle or visual effect here
        }
    }
}
