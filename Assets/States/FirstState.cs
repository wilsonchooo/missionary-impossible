using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
public class FirstState : State<Enemy>
{
    private static FirstState instance;

    private FirstState()
    {
        if(instance!=null)
        {
            return;
        }

        instance = this;
    }
    public static FirstState Instance
    {
        get
        {
            if(instance==null)
            {
                new FirstState();
            }

            return instance;
        }
    }
    public override void EnterState(Enemy owner)
    {
        Debug.Log("Entering First State");
    }

    public override void ExitState(Enemy owner)
    {
        Debug.Log("Exiting First State");
    }

    public override void UpdateState(Enemy owner)
    {
        if(owner.switchState)
        {
            owner.stateMachine.ChangeState(SecondState.Instance);
        }
    }


}
