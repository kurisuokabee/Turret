using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject youWinPanel;
    void Update()
    {
        float finishZoneDistance = (player.position - transform.position).magnitude;

        if (finishZoneDistance <= 3f)
        {   
            youWinPanel.SetActive(true);
            Debug.Log("You Win!");
            
        }
        else
        {       
            youWinPanel.SetActive(false);
        }
    }
}
