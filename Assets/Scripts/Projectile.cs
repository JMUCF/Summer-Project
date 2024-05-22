using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5.0f;
    [SerializeField] private float launchHeight = 5.0f;
    public GameObject hitBox;
    private Vector3 projectileVelocity;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Vector3 launchDirection = transform.forward; // Use the forward direction of the projectile
        Vector3 launchVelocity = launchDirection * projectileSpeed + Vector3.up * launchHeight;
        rb.velocity = launchVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject hitBoxObject = Instantiate(hitBox, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
