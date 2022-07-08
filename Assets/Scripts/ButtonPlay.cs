using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField] private GameObject _panelPause;

    public void PlayGame()
    {
        _panelPause.SetActive(false);
    }
}
