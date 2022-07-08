using System;
using System.Collections;
using UnityEngine;

public class AttachWeapon : MonoBehaviour, IAttachable
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private HingeJoint _hingeJoint;
    private WeaponCreater _weaponCreater;
    public bool IsAttached => _isAttached;
    private bool _isAttached = false;

    private void OnDisable()
    {
        _isAttached = false;
        _rigidbody.isKinematic = true;
        _hingeJoint.connectedBody = null;
    }

    private void Start()
    {
        _weaponCreater = GetComponentInParent<WeaponCreater>();
    }

    public void Attach(Rigidbody rigidbody)
    {
        if (_isAttached)
            return;

        _weaponCreater.CreateWeapon();
        _hingeJoint.connectedBody = rigidbody;
        _rigidbody.isKinematic = false;
        StartCoroutine(AttachDelay(_hingeJoint));
        _isAttached = true;
    }

    private IEnumerator AttachDelay(HingeJoint hingeJoint)
    {
        JointLimits limits = new JointLimits();
        limits.min = -8f;
        limits.max = 8f;
        limits.bounciness = 1f;
        limits.bounceMinVelocity = 0.2f;
        hingeJoint.limits = limits;

        while (limits.bounciness != 0)
        {
            limits.bounciness -= Time.deltaTime / 2;
            hingeJoint.limits = limits;
            yield return null;
        }
    }
}
