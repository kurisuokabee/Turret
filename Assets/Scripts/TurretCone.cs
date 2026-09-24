using UnityEditor.MPE;
using UnityEngine;

public class TurretCone : MonoBehaviour
{   
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] public Transform player;
    [SerializeField] float range;
    [SerializeField] float coneAngle;
    

    void Update()
    {
        DrawCone();
    }   

    public bool IsInCone()
    {   
        Vector2 dir = player.position- transform.position;

        if (dir.magnitude > range) return false;

        float pAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        float tAngle = transform.eulerAngles.z;

        float delta = Mathf.Abs(Mathf.DeltaAngle(tAngle, pAngle));

        return delta <= coneAngle/2f;
    }

    void DrawCone()
    {
        float halfAngle = coneAngle / 2f;
        float centerAngle = transform.eulerAngles.z;

        int segments = 30;

        // Center + arc points + center
        lineRenderer.positionCount = segments + 3;

        // Center -> left edge
        lineRenderer.SetPosition(0, transform.position);

        // Arc
        for (int i = 0; i <= segments; i++)
        {
            float angle = centerAngle - halfAngle +
                        (coneAngle / segments) * i;

            Vector3 dir =
                Quaternion.Euler(0, 0, angle) * Vector3.right;

            lineRenderer.SetPosition(
                i + 1,
                transform.position + dir * range
            );
        }

        // Right edge -> center
        lineRenderer.SetPosition(
            segments + 2,
            transform.position
        );
    }

}
