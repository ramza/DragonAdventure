using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState
{
    public virtual void Enter(EnemyStateMachine enemyStateMachine)
    {

    }
    public virtual void Update(EnemyStateMachine enemyStateMachine)
    {

    }
    public virtual void Exit(EnemyStateMachine enemyStateMachine)
    {

    }
}

public class EnemyDeadState : EnemyState
{
    public override void Enter(EnemyStateMachine enemyStateMachine)
    {

        enemyStateMachine.anim.SetBool("dead", true);

    }
    public override void Update(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.Dead();
    }
    public override void Exit(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.anim.SetBool("dead", false);

    }
}

public class EnemyIdleState : EnemyState
{
    public override void Enter(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.idleTimer = 0;
        enemyStateMachine.timer = 0;
    }
    public override void Update(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.Idle();
    }
    public override void Exit(EnemyStateMachine enemyStateMachine)
    {

    }
}

public class EnemyRunState : EnemyState
{
    public override void Enter(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.timer = 0;
        enemyStateMachine.anim.SetBool("run", true);
    }
    public override void Update(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.Run();
    }
    public override void Exit(EnemyStateMachine enemyStateMachine)
    {
        
        enemyStateMachine.anim.SetBool("run", false);
    }
}

public class EnemyChaseState : EnemyState
{
    public override void Enter(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.anim.SetBool("run", true);
    }
    public override void Update(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.Chase();
    }
    public override void Exit(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.anim.SetBool("run", false);
    }
}

public class EnemyAttackState : EnemyState
{
    public override void Enter(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.anim.SetBool("attack", true);
        enemyStateMachine.timer = 0;
   
    }
    public override void Update(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.Attack();
    }
    public override void Exit(EnemyStateMachine enemyStateMachine)
    {
  
        enemyStateMachine.anim.SetBool("attack", false);
    }
}
