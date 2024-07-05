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
    /// <summary>
    /// �ƶ����
    /// </summary>
    /// <param name="speed">�ƶ��ٶ�</param>
    public void MovePlayer(float speed)
    {
        player.rb.velocity = keyboardMoveAxes * speed;
    }
}
