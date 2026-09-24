using UnityEngine;

public class SniperTurret : MonoBehaviour
{   
    [SerializeField] TurretCone turretCone;
    [SerializeField] float rotationSpeed;
    float originalAngle;
    void Start()
    {
        originalAngle = transform.eulerAngles.z;
    }

    void Update()
    {   
        if(turretCone.IsInCone())
        {
            Vector2 dir = turretCone.player.position - transform.position;
            float targetAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            RotationTowardsPlayer(targetAngle);
        }
        else
        {   
            RotationTowardsPlayer(originalAngle);
        }
        
    }

    private void RotationTowardsPlayer(float targetAngle)
    {
        float currentAngle = transform.eulerAngles.z;

        float newAngle = Mathf.MoveTowardsAngle(
        currentAngle,
        targetAngle,
        rotationSpeed * Time.deltaTime);

        transform.eulerAngles = new Vector3(0f, 0f, newAngle);
    }
}
