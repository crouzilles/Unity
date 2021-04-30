using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour
{
    public float thrustForce = 15f;

    private float thrustInput = 0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // We use Raw input on purpose to abruptly start and stop force applied
        this.thrustInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (this.thrustInput > 0)
            rb.AddForce(transform.up * thrustForce);
    }
}
