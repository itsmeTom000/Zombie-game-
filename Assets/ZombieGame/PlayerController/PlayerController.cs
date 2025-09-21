using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static WaitForSeconds _waitForSeconds_1 = new WaitForSeconds(.1f);

    [SerializeField] private float playerSpeed = 7f;
    [SerializeField] private float sprintSpeed = 17f;
    [SerializeField] private BulletScript bulletPrefeb;
    [SerializeField] private Transform firePosition;
    [SerializeField] private float rotationSpeed = 20f;

    private bool isFire;

    private void Update()
    {
        HandleMovement();

        // Start shooting automatically if enemies exist
        if (DetectZombie.Instance.enemyList.Count > 0 && !isFire)
        {
            isFire = true;
            StartCoroutine(BulletFire());
        }
        else if (DetectZombie.Instance.enemyList.Count == 0)
        {
            isFire = false;
        }
    }

    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : playerSpeed;

        Vector3 moveDir = new Vector3(x, 0, z).normalized;

        if (moveDir.magnitude >= 0.1f)
        {
            transform.position += moveSpeed * Time.deltaTime * moveDir;
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private IEnumerator BulletFire()
    {
        while (isFire)
        {
            // Find the closest enemy
            Transform closestEnemy = null;
            float minDistance = Mathf.Infinity;

            foreach (var enemy in DetectZombie.Instance.enemyList)
            {
                if (enemy == null) continue;
                float distance = Vector3.Distance(firePosition.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestEnemy = enemy.transform;
                }
            }

            if (closestEnemy != null)
            {
                // Rotate firePosition to face the closest enemy smoothly
                Vector3 direction = (closestEnemy.position - firePosition.position).normalized;
                firePosition.rotation = Quaternion.Slerp(firePosition.rotation, Quaternion.LookRotation(direction), rotationSpeed);

                // Fire bullet
                Instantiate(bulletPrefeb, firePosition.position, firePosition.rotation);
                SoundManager.Instance.PlayFiringSound();
            }
            else
            {
                // No enemies left
                isFire = false;
            }

            yield return _waitForSeconds_1;
        }
    }
}
