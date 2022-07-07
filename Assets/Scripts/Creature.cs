using System.Collections.Generic;
using UnityEngine;

public abstract class Creature : MonoBehaviour
{
    [SerializeField] protected Rigidbody _mainRigidbody;

    protected Dictionary<Rigidbody, CreatureData> _rigidbodies;
    protected struct CreatureData
    {
        public Vector3 StartPosition { get; }
        public Quaternion StartRotation { get; }

        public CreatureData(Vector3 startPosition, Quaternion startRotation)
        {
            StartPosition = startPosition;
            StartRotation = startRotation;
        }
    }

    protected void InitializedRigidbodies()
    {
        _rigidbodies = new Dictionary<Rigidbody, CreatureData>();
        foreach (Rigidbody rigidbody in GetComponentsInChildren<Rigidbody>())
        {
            _rigidbodies.Add(rigidbody, new CreatureData(rigidbody.transform.localPosition, rigidbody.transform.localRotation));
        }
    }

    public abstract void AddForce(float minForceX, float maxForceX);

}
