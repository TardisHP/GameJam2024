using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    private Vector3 keyboardMoveAxes => playerInputAction.Player.Move.ReadValue<Vector2>();
    private Player player => GetComponent<Player>();
    private void Awake()
    {
        //实例化InputActions脚本
        playerInputAction = new PlayerInputAction();
    }
    private void OnEnable()
    {
        //将要使用的ActionMap开启
        playerInputAction.Player.Enable();
    }
    public void OnDisable()
    {
        //上述同理
        playerInputAction.Player.Disable();
    }
    public void MovePlayer()
    {
        player.rb.velocity = keyboardMoveAxes * 4f;
    }
}
