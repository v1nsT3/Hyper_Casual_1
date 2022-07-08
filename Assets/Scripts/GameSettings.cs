using System;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public event Action OnGameLose;
    public event Action OnGameWin;

    [SerializeField] private WeaponCreater _weaponCreater;
    [field: SerializeField] public int MaxWeaponCount { get; private set; }
    private int _currentWeaponCount = 0;
    private int _currentGameLevel = 1;
    private int _currentRagdollScore = 0;

    private void Start()
    {
        _weaponCreater.OnReduceWeapon += OnReduceWeapon;
        GameStart();
    }

    public void OnReduceWeapon()
    {
        _currentWeaponCount = Math.Clamp(--_currentWeaponCount, 0, MaxWeaponCount);
        if (_currentWeaponCount == 0)
            OnGameLose?.Invoke();
    }

    public void OnAddRegdollScore()
    {
        _currentRagdollScore++;
        if (_currentRagdollScore == _currentGameLevel)
            OnGameWin?.Invoke();
    }

    public void GameStart()
    {
        _currentWeaponCount = MaxWeaponCount;
        _weaponCreater.Construct(this);
    }
}
