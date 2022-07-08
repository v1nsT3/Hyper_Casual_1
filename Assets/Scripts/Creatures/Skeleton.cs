using System.Collections;
using UnityEngine;

public class Skeleton : Creature
{
    private float _speedTorque = 5f;
    private float _minForceY = 15f;
    private float _maxForceY = 25f;
    private float _timeForDestroy = 10f;

    private void OnEnable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies.Keys)
        {
            rigidbody.isKinematic = false;
        }

        StartCoroutine(DestroyCreature());
    }

    private void OnDisable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies.Keys)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.transform.localPosition = _rigidbodies[rigidbody].StartPosition;
            rigidbody.transform.localRotation = _rigidbodies[rigidbody].StartRotation;
            rigidbody.isKinematic = true;
        }

        StopCoroutine(DestroyCreature());
    }

    private IEnumerator DestroyCreature()
    {
        yield return new WaitForSeconds(_timeForDestroy);

        gameObject.SetActive(false);
    }

    private void Awake()
    {
        if (_rigidbodies == null)
            InitializedRigidbodies();
    }

    public override void AddForce(float minForceX, float maxForceX)
    {
        float rndX = Random.Range(minForceX, maxForceX) * -1f;
        float rndY = Random.Range(_minForceY, _maxForceY);
        _mainRigidbody.AddForce(rndX, rndY, 0, ForceMode.VelocityChange);
    }

    private void FixedUpdate()
    {
        _mainRigidbody.AddRelativeTorque(0, 0, _speedTorque, ForceMode.VelocityChange);
    }
}
