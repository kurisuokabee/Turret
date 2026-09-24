using UnityEngine;

public class ProjectileCone : MonoBehaviour
{
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] TurretCone turretCone;

    bool wasInCone;
    
    void Update()
    {
        bool isInCone = turretCone.IsInCone();

        if (isInCone && !wasInCone)
        {   
            Debug.Log("IN CONE");
            projectileParticles.Play();
        }
        else if (!isInCone && wasInCone)
        {   
            Debug.Log("NOT IN CONE");
            projectileParticles.Stop();
        }

        wasInCone = isInCone;
    }
}
