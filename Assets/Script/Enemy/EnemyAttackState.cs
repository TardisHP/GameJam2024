using UnityEngine;

public class EnemyAttackState : EnemyState
{
    private Vector2 attackDirection;
    public EnemyAttackState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemy, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        attackDirection = enemy.playerPos.position - enemy.transform.position;
        attackDirection.Normalize();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.rb.velocity = Vector2.zero;
    }

    public override void Update()
    {
        base.Update();
        enemy.rb.AddForce(attackDirection * 5);
        if (triggerCalled)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
