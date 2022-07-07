using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    [field: SerializeField] public LineRenderer lineRenderer { get; private set; }
    
    public void ShowTrajectory(Transform p0, Transform p1, Transform p2, Transform p3)
    {
        int sigmentsNumber = 20;
        Vector3[] points = new Vector3[sigmentsNumber];
        lineRenderer.positionCount = points.Length;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            float paremeter = (float)i / sigmentsNumber;
            points[i] = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, paremeter);
        }
        lineRenderer.SetPositions(points);
    }

    public void HideTrajectory()
    {
        lineRenderer.positionCount = 0;
    }
}
