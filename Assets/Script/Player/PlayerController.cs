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
        //ʵ����InputActions�ű�
        playerInputAction = new PlayerInputAction();
    }
    private void OnEnable()
    {
        //��Ҫʹ�õ�ActionMap����
        playerInputAction.Player.Enable();
    }
    public void OnDisable()
    {
        //����ͬ��
        playerInputAction.Player.Disable();
    }
    public void MovePlayer()
    {
        player.rb.velocity = keyboardMoveAxes * 4f;
    }
}
