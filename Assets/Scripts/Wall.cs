using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float rotateSpeed = 5f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, Time.deltaTime * rotateSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IAttachable attachable))
        {
            attachable.Attach(rigidbody);
        }
    }
}
