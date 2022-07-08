using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCreater : MonoBehaviour
{
    public event Action OnReduceWeapon;

    [field: SerializeField] public Transform Target { get; private set; }
    [SerializeField] private Weapon _prefabWeapon;
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private bool _autoExpand = false;

    private PoolMono<Weapon> _pool;

    public void Construct(GameSettings gameSettings)
    {
        _pool = new PoolMono<Weapon>(_prefabWeapon, gameSettings.MaxWeaponCount, transform);
        _pool.AutoExpand = _autoExpand;
        _currentWeapon = _pool.GetFreeElement();
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

    public void CreateWeapon()
    {
        _currentWeapon = _pool.GetFreeElement();
        _currentWeapon.transform.position = transform.position;
        _currentWeapon.transform.rotation = transform.rotation;
        OnReduceWeapon?.Invoke();
    }
}
