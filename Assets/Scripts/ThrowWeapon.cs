using System.Collections;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour, IThrowable
{
    [SerializeField] private float _throwSpeed = 15f;

    public void Throw(Vector3[] pathf)
    {
        StartCoroutine(ThrowDelay(pathf));
    }

    private IEnumerator ThrowDelay(Vector3[] pathf)
    {
        int index = 0;

        while (index != pathf.Length - 1)
        {
            
            Vector3 target = transform.position - pathf[index];
            float dist = Vector3.Distance(transform.position, pathf[index]);
            if (dist < 0.1f)
                index++;

            transform.position = Vector3.MoveTowards(transform.position, pathf[index], Time.deltaTime * _throwSpeed);
            transform.rotation = Quaternion.LookRotation(target * -1);

            yield return null;
        }
    }
}
