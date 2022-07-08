
using UnityEngine;

public class StateAttached : BaseState
{
    public StateAttached(Weapon weapon) : base(weapon)
    {
    }

    public override void Enter()
    {
        _weapon.WeaponDestroy();
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        
    }
}
