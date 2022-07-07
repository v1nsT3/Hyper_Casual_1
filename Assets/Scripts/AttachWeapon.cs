using System;
using System.Collections;
using UnityEngine;

public class AttachWeapon : MonoBehaviour, IAttachable
{
    [SerializeField] private Rigidbody _rigidbody;

    public bool IsAttached => _isAttached;
    private bool _isAttached = false;

    public void Attach(Rigidbody rigidbody)
    {
        if (_isAttached)
            return;
        HingeJoint hingeJoint = gameObject.AddComponent<HingeJoint>();
        hingeJoint.connectedBody = rigidbody;
        hingeJoint.useLimits = true;
        _rigidbody.isKinematic = false;
        StartCoroutine(AttachDelay(hingeJoint));
        _isAttached = true;
    }

    private IEnumerator AttachDelay(HingeJoint hingeJoint)
    {
        JointLimits limits = new JointLimits();
        limits.min = 0f;
        limits.max = 8f;
        limits.bounciness = 1f;
        limits.bounceMinVelocity = 0f;
        hingeJoint.limits = limits;
        
        while (limits.bounciness != 0)
        {
            limits.bounciness -= Time.deltaTime / 2;
            hingeJoint.limits = limits;
            yield return null;
        }
    }
}
