using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletScript : MonoBehaviour
{
    #region Private_Variable
    [SerializeField] private float lifeTime = 100f;

    [Range(0, 100)]
    public float bulletSpeed;
    private Rigidbody rb;
    #endregion

    #region Unity_Callbacks
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        Destroy(gameObject, lifeTime); // Destroy after a few seconds
    }
    #endregion
}
