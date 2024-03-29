﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{

    public class StateMachine<T>
    {
        public State<T> currentState { get; private set; }
        public T Owner;

        public StateMachine(T own)
        {
            Owner = own;
            currentState = null;
        }

        public void ChangeState(State<T> newstate)
        {
            if (currentState != null)
                currentState.ExitState(Owner);
            currentState = newstate;
            currentState.EnterState(Owner);
        }

        public void Update()
        {
            if (currentState != null)
                currentState.UpdateState(Owner);
        }
    }
    public abstract class State<T>
    {
        public abstract void EnterState(T owner);
        public abstract void ExitState(T owner);
        public abstract void UpdateState(T owner);

    }
}