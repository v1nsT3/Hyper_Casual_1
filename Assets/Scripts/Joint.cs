using System;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public bool isConnected = false;
    public Action<Collider, FixedJoint, Joint> OnConnectRagdoll;

    private void OnTriggerEnter(Collider other)
    {

        if (isConnected)
            return;

        OnConnectRagdoll?.Invoke(other, GetComponent<FixedJoint>(), this);
    }
}
