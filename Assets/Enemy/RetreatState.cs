using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : BaseState
{
    public void EnterState(Enemy enemy)
    {
        Debug.Log("Start Retreating");
		enemy.Animator.SetTrigger("RetreatState");
    }

    public void UpdateState(Enemy enemy)
    {
        Debug.Log("Retreating");
    }

    public void ExitState(Enemy enemy)
    {
        Debug.Log("Stop Retreating");
    }
}