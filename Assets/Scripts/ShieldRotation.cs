using UnityEngine;

public class ShieldRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 5f;

    private void Update()
    {
        transform.rotation *= Quaternion.Euler(0, 0, Time.deltaTime * _rotateSpeed);
    }
}
