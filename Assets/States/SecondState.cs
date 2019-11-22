using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;
public class SecondState : State<Enemy>
{
    private static SecondState instance;

    private SecondState()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }
    public static SecondState Instance
    {
        get
        {
            if (instance == null)
            {
                new SecondState();
            }

            return instance;
        }
    }
    public override void EnterState(Enemy owner)
    {
        Debug.Log("Entering Second State");
    }

    public override void ExitState(Enemy owner)
    {
        Debug.Log("Exiting Second State");
    }

    public override void UpdateState(Enemy owner)
    {
        if (!owner.switchState)
        {
            owner.stateMachine.ChangeState(FirstState.Instance);
        }
    }


}
