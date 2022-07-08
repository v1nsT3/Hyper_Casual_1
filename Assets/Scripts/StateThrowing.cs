using UnityEngine;

public class StateThrowing : BaseState
{
    private IThrowable _throwable;
    private Vector3[] _pathf;
    public StateThrowing(Weapon weapon) : base(weapon)
    {
        _throwable = weapon.GetComponentInChildren<IThrowable>();
    }

    public override void Enter()
    {
        _pathf = _weapon.Trajectory.GetTrajectory();
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {
        _throwable.Throw(_pathf);
    }
}
