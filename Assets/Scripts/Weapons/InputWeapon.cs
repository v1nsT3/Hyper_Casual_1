using System;
using UnityEngine;

public class InputWeapon : IInputReader
{
    float IInputReader.GetAxisTouch => Input.GetAxis("Mouse X");

    bool IInputReader.IsInputMove => Input.GetKey(KeyCode.Mouse0);

    bool IInputReader.IsInputThrow => Input.GetKeyUp(KeyCode.Mouse0);

}
