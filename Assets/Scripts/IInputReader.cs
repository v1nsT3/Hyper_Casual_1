using UnityEngine;

public interface IInputReader 
{
    public float GetAxisTouch { get; }
    public bool IsInputMove { get; }
    public bool IsInputThrow { get; }
}
