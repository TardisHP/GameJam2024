using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectHide : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    private bool canHide;
    private Vector3 hidePos;
    private void Start()
    {
        canHide = false;
    }
    private void Update()
    {
        if (canHide && Input.GetKeyDown(KeyCode.Space))
        {
            Hide();
        }
    }
    private void Hide()
    {
        player.transform.position = hidePos;
        player.canAttack = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HidePlace hidePlace = collision.gameObject.GetComponent<HidePlace>();
        if (hidePlace != null)
        {
            canHide = true;
            hidePos = hidePlace.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        HidePlace hidePlace = collision.gameObject.GetComponent<HidePlace>();
        if (hidePlace != null)
        {
            canHide = false;
        }
    }
}
