using UnityEngine;

public class StateMoving : BaseState
{
    private IMovable _movable;
    public StateMoving(Weapon weapon) : base(weapon)
    {
        _movable = weapon.GetComponent<IMovable>();
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        _weapon.Trajectory.Hide();
    }

    public override void Update()
    {
        _movable.Move(_weapon.InputWeapon);
        _weapon.Trajectory.Show();
    }
}
