using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 180f;

    private float rotationInput = 0f;

    // Update is called once per frame
    void Update()
    {
        // We use Raw input on purpose to start and stop rotating abruptly
        this.rotationInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (this.rotationInput < 0)
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        if (this.rotationInput > 0)
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }
}
