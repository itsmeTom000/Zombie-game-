using UnityEngine;
using DG.Tweening;

public class CameraScript : MonoBehaviour
{
    public Transform player;       // Drag the Player here in Inspector
    private Vector3 offset = new(0, 4.5f, -5f);  // Camera offset

    private Tween moveTween;
    private Tween rotateTween;

    void LateUpdate()
    {
        if (player != null)
        {
            // Kill previous tweens to prevent multiple tweens at the same time
            if (moveTween != null && moveTween.IsActive()) moveTween.Kill();
            if (rotateTween != null && rotateTween.IsActive()) rotateTween.Kill();

            // Smoothly move the camera to follow the player
            moveTween = transform.DOMove(player.position + offset, 0.2f).SetEase(Ease.OutSine);

            // Smoothly rotate camera to look at player
            Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
            rotateTween = transform.DORotateQuaternion(targetRotation, 0.2f).SetEase(Ease.OutSine);
        }
    }

    void OnDestroy()
    {
        // Kill tweens if camera is destroyed
        if (moveTween != null) moveTween.Kill();
        if (rotateTween != null) rotateTween.Kill();
    }
}
