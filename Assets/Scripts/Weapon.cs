using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private StateMachine _weaponStateMachine;

    private IAttachable _attachable; 

    public IInputReader InputWeapon { get; private set; }

    [field: SerializeField] public Trajectory Trajectory { get; private set; }

    public void Start()
    {
        InputWeapon = new InputWeapon();

        _attachable = GetComponent<IAttachable>();

        _weaponStateMachine = new StateMachine(this);

        When(_weaponStateMachine.idleState, _weaponStateMachine.movingState, () => InputWeapon.IsInputMove);
        When(_weaponStateMachine.movingState, _weaponStateMachine.throwingState, () => InputWeapon.IsInputThrow);
        When(_weaponStateMachine.throwingState, _weaponStateMachine.attachedState, () => _attachable.IsAttached);

        void When(BaseState from, BaseState to, Func<bool> predicate)
        {
            _weaponStateMachine.AddTransition(from, to, predicate);
        }

        _weaponStateMachine.ChangeState(_weaponStateMachine.idleState);
    }

    private void Update()
    {
        if (_weaponStateMachine != null)
            _weaponStateMachine.LogicUpdate();
    }

    public void WeaponDestroy()
    {
        StartCoroutine(WeaponDestroyDelay());
    }

    private IEnumerator WeaponDestroyDelay()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
