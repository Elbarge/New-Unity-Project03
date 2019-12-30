using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlane : MonoBehaviour
{
    public float target_kmph_ = 100f;
    void FixedUpdate()
    {
        var hori = Input.GetAxis("Horizontal") * 3f;
        var vart = Input.GetAxis("Vertical") * 1f;
        var rb = GetComponent<Rigidbody>();
        // AddTorqueはワールド座標
        // AddRelativeTorqueはローカル座標
        rb.AddRelativeTorque(new Vector3(0, hori, -hori));
        rb.AddRelativeTorque(new Vector3(vart, 0, 0));

        var left = transform.TransformVector(Vector3.left);
        var horizontal_left = new Vector3(left.x, 0f, left.z).normalized;
        // Crossは外積
        rb.AddTorque(Vector3.Cross(left, horizontal_left) * 4f);
        var forward = transform.TransformVector(Vector3.left);
        var horizontal_forward = new Vector3(left.x, 0f, left.z).normalized;
        rb.AddTorque(Vector3.Cross(forward, horizontal_forward) * 4f);

        var force = (rb.mass * rb.drag * target_kmph_ / 3.6f) / (1f - rb.drag*Time.fixedDeltaTime);
        rb.AddRelativeForce(new Vector3(0f, 0f, force));
    }
}
