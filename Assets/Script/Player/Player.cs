using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    [SerializeField]
    [Header("Components")]  
    public Rigidbody2D rb;
    public PlayerController controller;
    public Animator animator;
    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerSneakState sneakState { get; private set; }
    public PlayerRunState runState { get; private set; }
    #endregion

    #region Attributes
    [SerializeField]
    [Header("Attributes")]
    public int health;  // 血量
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        moveState = new PlayerMoveState(this, stateMachine, "isMove");
        sneakState = new PlayerSneakState(this, stateMachine, "isSneak");
        runState = new PlayerRunState(this, stateMachine, "isRun");
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        InitPlayer();
    }
    private void Update()
    {
        stateMachine.currentState.Update();
    }
    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    private void InitPlayer()
    {
        // 初始化状态机
        stateMachine.Initialize(moveState);
        // 初始化属性
        health = 5;
    }
}
