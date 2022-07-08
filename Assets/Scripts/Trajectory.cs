using System.Collections.Generic;
using UnityEngine;

public abstract class Trajectory : MonoBehaviour
{
    [SerializeField] protected Transform _origin;
    protected Transform _target;

    [SerializeField] protected LineRenderer _lineRenderer;

    protected Vector3[] _positions;
    public abstract void Show();

    public abstract void Hide();

    public abstract Vector3[] GetTrajectory();

    private void Start()
    {
        _target = GetComponentInParent<WeaponCreater>().Target;
        _lineRenderer = GetComponentInParent<LineRenderer>();
    }
}
