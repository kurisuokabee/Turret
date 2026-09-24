using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileDetection : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    [SerializeField] Transform player;

    ParticleSystem.Particle[] particles;

    void Start()
    {
        particles = new ParticleSystem.Particle[
            _particleSystem.main.maxParticles
        ];
    }

    void Update()
    {
        int count = _particleSystem.GetParticles(particles);

        for (int i = 0; i < count; i++)
        {
            float distanceSqr = (particles[i].position - player.position).sqrMagnitude;

            if (distanceSqr <= .5f * .5f)
            {
                Debug.Log("Particle detected player!");
                Debug.Log("Scene Restart");
                SceneManager.LoadScene("Gameplay");     
            }
        }   
    }   
}
