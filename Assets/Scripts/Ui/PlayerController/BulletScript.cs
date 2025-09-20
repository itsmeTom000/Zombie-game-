using UnityEngine;

public class BulletScript : MonoBehaviour
{
    #region Private_Variable
    [SerializeField] private float lifeTime = 100f;
    private float bulletSpeed = 50;
    private Rigidbody rb;
    #endregion

    #region Unity_Callbacks
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed , ForceMode.Impulse);
        Destroy(gameObject, lifeTime); // Destroy after a few seconds
    }
    #endregion
}
