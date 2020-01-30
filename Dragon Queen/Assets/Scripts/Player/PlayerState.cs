using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{

    public virtual void Enter(PlayerStateMachine playerStateMachine)
    {

    }
    public virtual void Update(PlayerStateMachine playerStateMachine)
    {
        
    }
    public virtual void Exit(PlayerStateMachine playerStateMachine)
    {

    }
}

public class PlayerFreezeState : PlayerState
{
    public override void Enter(PlayerStateMachine playerStateMachine)
    {

    }

    public override void Update(PlayerStateMachine playerStateMachine)
    {
  
    }
    public override void Exit(PlayerStateMachine playerStateMachine)
    {

    }
}

public class PlayerIdleState : PlayerState
{
    public override void Enter(PlayerStateMachine playerStateMachine)
    {

    }

    public override void Update(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.Idle();
    }
    public override void Exit(PlayerStateMachine playerStateMachine)
    {
  
    }
}

public class PlayerAttackState : PlayerState
{
    public override void Enter(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.thirdPersonController.canMove = false;
        playerStateMachine.ResetTimer();
        playerStateMachine._anim.SetBool("attack", true);
    }

    public override void Update(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.Attack();
    }
    public override void Exit(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.thirdPersonController.canMove = true;
        playerStateMachine._anim.SetBool("attack", false);
    }
}

public class PlayerSpellState : PlayerState
{
    public override void Enter(PlayerStateMachine playerStateMachine)
    {
 
    }

    public override void Update(PlayerStateMachine playerStateMachine)
    {

    }
    public override void Exit(PlayerStateMachine playerStateMachine)
    {

    }
}


public class PlayerRunState : PlayerState
{
    public override void Enter(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine._anim.SetBool("run", true);
    }

    public override void Update(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.Run();
    }
    public override void Exit(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine._anim.SetBool("run", false);
    }
}

public class PlayerJumpState : PlayerState
{
    public override void Enter(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.ResetTimer();
        playerStateMachine._anim.SetBool("jump", true);
    }

    public override void Update(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.Jump();
    }
    public override void Exit(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine._anim.SetBool("jump", false);
    }
}


public class PlayerDeadState : PlayerState
{
    public override void Enter(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.thirdPersonController.canMove = false;
        playerStateMachine._anim.SetBool("dead", true);
    }

    public override void Update(PlayerStateMachine playerStateMachine)
    {

    }
    public override void Exit(PlayerStateMachine playerStateMachine)
    {
        playerStateMachine.thirdPersonController.canMove = true;
        playerStateMachine._anim.SetBool("dead", false);
    }
}
