using UnityEngine;

public interface IAttachable
{
    public bool IsAttached { get; }
    public void Attach(Rigidbody rigidbody);
}
