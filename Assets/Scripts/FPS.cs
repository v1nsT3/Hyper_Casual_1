using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public int CurrentFPS { get; private set; }

    private int _framRange = 60;
    private int[] _fpsBuffer;
    private int _fpsBufferIndex;

    private void Awake()
    {
        //Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        InitializedBuffer();
    }

    private void Update()
    {
        UpdateBuffer();
        CalculateFps();
    }

    private void InitializedBuffer()
    {
        if (_framRange <= 0)
            _framRange = 1;

        _fpsBuffer = new int[_framRange];
        _fpsBufferIndex = 0;
    }

    private void UpdateBuffer()
    {
        _fpsBuffer[_fpsBufferIndex++] = (int)(1 / Time.unscaledDeltaTime);
        if(_fpsBufferIndex >= _framRange)
        {
            _fpsBufferIndex = 0;
        }
    }

    private void CalculateFps()
    {
        int sum = 0;
        for (int i =0; i<_framRange; i++)
        {
            sum += _fpsBuffer[i];
        }

        CurrentFPS = sum / _framRange;
    }

}
