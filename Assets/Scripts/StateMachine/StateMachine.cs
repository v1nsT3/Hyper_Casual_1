
using System;
using System.Collections.Generic;

public class StateMachine
{
    private BaseState currentState;
    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();
    private List<Transition> currentTransitions = new List<Transition>();
    private List<Transition> emptyTransitions = new List<Transition>(0);
    public BaseState idleState { get; private set; }
    public BaseState movingState { get; private set; }
    public BaseState throwingState { get; private set; }
    public BaseState attachedState { get; private set; }

    public StateMachine(Weapon weapon)
    {
        idleState = new StateIdle(weapon);
        movingState = new StateMoving(weapon);
        throwingState = new StateThrowing(weapon);
        attachedState = new StateAttached(weapon);
    }

    private class Transition
    {
        public BaseState From;
        public BaseState To;
        public Func<bool> predicate;
        public Transition(BaseState From, BaseState To, Func<bool> predicate)
        {
            this.From = From;
            this.To = To;
            this.predicate = predicate;
        }
    }


    public void AddTransition(BaseState from, BaseState to, Func<bool> predicate)
    {
        if (_transitions.ContainsKey(from.GetType()))
        {
            _transitions[from.GetType()].Add(new Transition(from, to, predicate));
        }
        else
        {
            _transitions[from.GetType()] = new List<Transition>();
            _transitions[from.GetType()].Add(new Transition(from, to, predicate));
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (newState == currentState)
        {
            return;
        }
        currentState?.Exit();
        currentState = newState;
        if (_transitions.ContainsKey(currentState.GetType()))
        {
            currentTransitions = _transitions[currentState.GetType()];
        }
        else
        {
            currentTransitions = emptyTransitions;
        }
        newState.Enter();
    }


    private Transition GetTransition()
    {
        foreach (var transition in currentTransitions)
        {
            if (transition.predicate())
            {
                return transition;
            }
        }
        return null;

    }
    public void LogicUpdate()
    {
        var transition = GetTransition();
        if (transition != null)
        {
            ChangeState(transition.To);
        }
        currentState?.Update();
    }

}
