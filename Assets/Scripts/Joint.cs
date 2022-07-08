using System;
using UnityEngine;

public class Joint : MonoBehaviour
{
    [SerializeField] private FixedJoint _fixedJoint;
    public bool isConnected = false;
    public Action<Collider, FixedJoint, Joint> OnConnectRagdoll;

    private void OnDisable()
    {
        _fixedJoint.connectedBody = null;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isConnected)
            return;

        OnConnectRagdoll?.Invoke(other, _fixedJoint, this);
    }
}
