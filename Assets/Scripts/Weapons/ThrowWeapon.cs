using System.Collections;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour, IThrowable
{
    [SerializeField] private float _throwSpeed = 15f;
    private int _index = 0;

    private void OnDisable()
    {
        _index = 0;
    }

    public void Throw(Vector3[] pathf)
    {

        if (_index != pathf.Length - 1)
        {

            Vector3 target = transform.position - pathf[_index];
            float dist = Vector3.Distance(transform.position, pathf[_index]);
            if (dist < 0.2f)
                _index++;

            transform.position = Vector3.MoveTowards(transform.position, pathf[_index], Time.deltaTime * _throwSpeed);
            transform.rotation = Quaternion.LookRotation(target * -1);
        }
    }
}
