using System.Collections.Generic;
using UnityEngine;

public class WeaponCreater : MonoBehaviour
{
    [field: SerializeField] public Transform Target { get; private set; }
    [SerializeField] private List<GameObject> _weapons = new List<GameObject>();
    [SerializeField] private GameObject _currentWeapon;

    void Start()
    {
        CreateWeapon(_weapons[0]);
    }

    private void OnDrawGizmos()
    {
        //int sigmentsNumber = 20;
        //Vector3 preveousePoint = p0.position;
        //for (int i = 0; i < sigmentsNumber + 1; i++)
        //{
        //    float paremeter = (float)i / sigmentsNumber;
        //    Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, target.position, paremeter);
        //    Gizmos.DrawLine(preveousePoint, point);
        //    preveousePoint = point;
        //}
    }

    public void CreateWeapon(GameObject weapon)
    {
        if (_currentWeapon != null)
            Destroy(_currentWeapon);

        _currentWeapon = Instantiate(weapon, transform);
    }
}
