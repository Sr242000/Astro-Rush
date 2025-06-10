
using UnityEngine;

public class ParticleActivator : MonoBehaviour
{
    public ParticleSystem particles;

    public void ActivateParticles()
    {
        if (particles != null)
            particles.Play();
    }
}
