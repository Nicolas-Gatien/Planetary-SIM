using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyNumbers : MonoBehaviour
{
    Rigidbody rb;
    Gravity g;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        g = GetComponent<Gravity>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.mass = transform.localScale.x * 4 * transform.localScale.x;
        g.gravityPull = transform.localScale.x * 2;
    }
}
