using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 组件
    #region Components
    public Rigidbody2D rb;
    public PlayerController controller;
    public Animator animator;
    #endregion
    // 状态
    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        moveState = new PlayerMoveState(this, stateMachine, "isMove");
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        // 初始化状态机
        stateMachine.Initialize(moveState);
    }
    private void Update()
    {
        stateMachine.currentState.Update();
        controller.MovePlayer();
    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
}
