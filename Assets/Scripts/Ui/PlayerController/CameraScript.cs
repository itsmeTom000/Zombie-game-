using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;       // Drag the Player here in Inspector
    private Vector3 offset = new(0, 4.5f, -5f);  // Adjust as needed
    void LateUpdate()
    {
        if (player != null)
            transform.position = player.position + offset ;
    }
}
