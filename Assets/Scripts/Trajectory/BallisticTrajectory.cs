using UnityEngine;

public class BallisticTrajectory : Trajectory
{
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;
    public override void Hide()
    {
        _positions = new Vector3[_lineRenderer.positionCount];
        _lineRenderer.GetPositions(_positions);
        _lineRenderer.positionCount = 0;
    }

    public override Vector3[] GetTrajectory() => _positions;

    public override void Show()
    {
        int sigmentsNumber = 20;
        Vector3[] points = new Vector3[sigmentsNumber];
        _lineRenderer.positionCount = points.Length;

        for (int i = 0; i < _lineRenderer.positionCount; i++)
        {
            float paremeter = (float)i / sigmentsNumber;
            points[i] = Bezier.GetPoint(_origin.position, p1.position, p2.position, _target.position, paremeter);
        }
        _lineRenderer.SetPositions(points);
    }


}
