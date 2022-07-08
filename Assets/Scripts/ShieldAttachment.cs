using UnityEngine;

public class ShieldAttachment : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IAttachable attachable))
        {
            attachable.Attach(_rigidbody);
        }
    }
}
