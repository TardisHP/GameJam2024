using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPlayer : MonoBehaviour
{
    private float coolTimer;
    private bool canAttack;
    private Enemy enemy => GetComponentInParent<Enemy>();
    private void Start()
    {
        coolTimer = 0f;
        canAttack = false;
    }
    private void Update()
    {
        coolTimer += Time.deltaTime;
        if (!canAttack && coolTimer > 2f)
            canAttack = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null && player.canAttack && canAttack)
        {
            canAttack = false;
            coolTimer = 0f;
            enemy.stateMachine.ChangeState(enemy.attackState);
        }
    }
}
