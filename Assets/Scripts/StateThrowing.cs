using UnityEngine;

public class StateThrowing : BaseState
{
    private IThrowable _throwable;
    public StateThrowing(Weapon weapon) : base(weapon)
    {
        _throwable = weapon.GetComponent<IThrowable>();
    }

    public override void Enter()
    {
        _throwable.Throw(_weapon.Trajectory.GetTrajectory());
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        
    }
}
