using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public EnemyController controller;

    #region States
    public EnemyStateMachine stateMachine { get; private set; }
    public EnemyIdleState idleState { get; private set; }
    public EnemyMoveState moveState { get; private set; }
    public EnemyAttackState attackState { get; private set; }
    #endregion

    public Transform playerPos;

    private void Awake()
    {
        stateMachine = new EnemyStateMachine();
        idleState = new EnemyIdleState(this, stateMachine, "isIdle");
        moveState = new EnemyMoveState(this, stateMachine, "isMove");
        attackState = new EnemyAttackState(this, stateMachine, "isAttack");
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        controller = GetComponent<EnemyController>();

        InitEnemy();
    }
    private void Update()
    {
        stateMachine.currentState.Update();
    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    private void InitEnemy()
    {
        // 初始化状态机
        stateMachine.Initialize(idleState);
        // 初始化属性
    }
}
