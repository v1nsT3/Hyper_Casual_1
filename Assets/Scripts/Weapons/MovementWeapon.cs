using UnityEngine;

public class MovementWeapon : MonoBehaviour, IMovable
{
    [SerializeField] private Transform _root;
    [SerializeField] private float _sensevity = 5f;
    [SerializeField] private float _maxOffsetX = 1f;
    [SerializeField] private float _maxAngleY = 30f;

    private void OnDisable()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Move(IInputReader inputReader)
    {
        float touchX = inputReader.GetAxisTouch;
        touchX = Mathf.Clamp(touchX, -1, 1);
        Vector3 pos = _root.transform.position;
        pos += new Vector3(touchX * _sensevity * Time.deltaTime, 0, 0);
        pos.x = Mathf.Clamp(pos.x, -_maxOffsetX, _maxOffsetX);
        _root.transform.rotation = Quaternion.AngleAxis(pos.x * _maxAngleY, Vector3.up);
        _root.transform.position = pos;
    }
}
