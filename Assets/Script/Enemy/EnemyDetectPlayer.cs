using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour
{
    private Enemy enemy => GetComponentInParent<Enemy>();
    private Vector3 lastPosition;
    public Transform home;
    public Player player;
    private void Update()
    {
        if (player.isPlaySound)
        {
            enemy.controller.Move(player.transform);
        }
        else
        {
            if (transform.position == lastPosition)
                enemy.controller.Move(home);
        }
        lastPosition = transform.position;
    }
}
