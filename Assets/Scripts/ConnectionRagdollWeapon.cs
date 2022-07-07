using System;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionRagdollWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private List<Joint> _joints = new List<Joint>();

    private List<GameObject> _currentRagdollConnect = new List<GameObject>();

    public event Action OnAddRagdoll;

    private void Start()
    {
        _joints.AddRange(GetComponentsInChildren<Joint>());
        foreach (Joint joint in _joints)
        {
            joint.OnConnectRagdoll += OnConnectRagdoll;
        }
    }

    private void OnConnectRagdoll(Collider collider, FixedJoint fixedJoint, Joint joint)
    {
        if (_currentRagdollConnect.Contains(collider.transform.root.gameObject))
            return;
        fixedJoint.connectedBody = collider.attachedRigidbody;
        _currentRagdollConnect.Add(collider.transform.root.gameObject);
        joint.isConnected = true;

        OnAddRagdoll?.Invoke();
    }
}
