using UnityEngine;

public class ProjectileSniper : MonoBehaviour
{
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] Transform player;

    bool wasInLOS;

    void Update()
    {
        Vector2 barrel   = transform.right;
        Vector2 toPlayer = ((Vector2)player.position - (Vector2)transform.position).normalized;
        float dot      = Vector2.Dot(barrel, toPlayer);
        bool inSights  = dot >= .999f; 

        if (inSights && !wasInLOS)
        {   
            Debug.Log("IN LOS");
            projectileParticles.Play();
        }
        else if (!inSights && wasInLOS)     
        {   
            Debug.Log("NOT IN LOS");
            projectileParticles.Stop();
        }

        wasInLOS = inSights;

    }
}
