using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class Gravity : MonoBehaviour
{
    public float gravityPull;
    public static float m_GravityRadius = 1f;

    void Awake()
    {
        m_GravityRadius = GetComponent<SphereCollider>().radius; // set gravity radius to SphereCollider radius
    }

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody) // if the other object has a rigidbody
        {
            float gravityIntensity = Vector3.Distance(transform.position, other.transform.position) / m_GravityRadius;
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * gravityIntensity * other.attachedRigidbody.mass * gravityPull * Time.smoothDeltaTime);
            Debug.DrawRay(other.transform.position, transform.position - other.transform.position);
        }
    }
}