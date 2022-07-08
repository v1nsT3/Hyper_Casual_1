public abstract class BaseState 
{
    protected Weapon _weapon;
    public BaseState(Weapon weapon)
    {
        _weapon = weapon;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
}
