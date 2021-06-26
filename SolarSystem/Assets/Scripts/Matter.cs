using UnityEngine;

public class Matter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent != null)
        {
            if (other.transform.parent.transform.localScale.x > transform.parent.transform.localScale.x)
            {
                other.transform.parent.transform.localScale += new Vector3(transform.parent.transform.localScale.x / 4, transform.parent.transform.localScale.y / 4, transform.parent.transform.localScale.z / 4);
                Destroy(transform.parent.gameObject);
            }
            else
            {
                transform.parent.transform.localScale += new Vector3(other.transform.parent.transform.localScale.x / 4, other.transform.parent.transform.localScale.y / 4, other.transform.parent.transform.localScale.z / 4);
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
