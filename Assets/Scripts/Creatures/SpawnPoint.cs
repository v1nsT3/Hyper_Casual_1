using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [field : SerializeField] public float minAngle { get; private set; }
    [field : SerializeField] public float maxAngle { get; private set; }

}
