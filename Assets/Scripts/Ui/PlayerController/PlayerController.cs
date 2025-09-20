using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    #region Private_Variable
    [SerializeField] private float playerSpeed;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private BulletScript bulletPrefeb;
    [SerializeField] private Transform firePosition;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private LayerMask zombieLayerMask;
    [SerializeField] private float detectionInterval = 0.2f;
    private bool isZombieNearby = false;
    private float moveSpeed;
    private bool isFire;
    #endregion

    #region Unity_Callbacks
    private void Start()
    {
        //playerPosition = GameObject.FindGameObjectWithTag("Spawn");
        InvokeRepeating(nameof(CheckForNearbyZombies), 0f, detectionInterval);
    }

    private void Update()
    {
        HandleMovementUsingCharacterController();
    }
    #endregion

    #region Private_Callbacks

    private void HandleMovementUsingCharacterController()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveSpeed = Input.GetKey(KeyCode.LeftShift) ? 17f : 7f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFire = true;
            StartCoroutine(BulletFire());
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFire = false;
        }
        Vector3 moveDir = new Vector3(x, 0, z).normalized;

        if (moveDir.magnitude >= 0.1f)
        {
            transform.position += moveSpeed * Time.deltaTime * moveDir;
            Quaternion toRotation = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime * rotationSpeed);
        }
    }

    private void DetectZombie()
    {
        Collider[] coliderArray = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider colider in coliderArray)
        {
            if (colider.TryGetComponent<ZombieScript>(out ZombieScript zombieScript))
            {
                //StartCoroutine(BulletFire());
            }
        }
    }

    private void CheckForNearbyZombies()
    {
        // 1) Do a sphere overlap only against the zombie layer
        Collider[] colliders = Physics.OverlapSphere(
            transform.position,
            detectionRadius
        );

        // 2) See if any of those colliders actually has a ZombieScript
        bool foundZombie = false;
        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<ZombieScript>(out ZombieScript zombieScript) || collider.TryGetComponent<BossZombieScript>(out BossZombieScript bossZombieScript))
            {
                Vector3 targetPosition = collider.transform.position;
                Vector3 direction = (targetPosition - firePosition.position).normalized;

                // Create a rotation that looks along that direction:
                Quaternion lookRot = Quaternion.LookRotation(direction);

                // Apply it (world‑space):
                firePosition.rotation = lookRot;

                foundZombie = true;
                break;  // we only need one
            }
        }

        // 3) If we’ve just spotted a zombie and aren’t firing yet → start firing
        if (foundZombie && !isFire)
        {
            isFire = true;
            StartCoroutine(BulletFire());
        }
        // 4) If no zombie is found but we were firing → stop firing
        else if (!foundZombie && isFire)
        {
            isFire = false;
        }
    }


    IEnumerator BulletFire()
    {
        while (isFire)
        {
            Instantiate(bulletPrefeb, firePosition.position, firePosition.rotation);
            SoundManager.Instance.PlayFiringSound();
            yield return new WaitForSeconds(.1f);
        }
    }
    #endregion
}
