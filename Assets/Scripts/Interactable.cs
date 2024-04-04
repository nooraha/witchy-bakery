using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent interaction;
    private float distanceToPlayer;
    private GameObject player;
    private bool clicked = false;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnMouseDown()
    {
        clicked = true;
    }

    private void Interact()
    {
        if (interaction != null)
        {
            interaction.Invoke();
        }
    }

    private void Update()
    {
        if (clicked)
        {
            clicked = false;
            Interact();

            //distanceToPlayer = Vector2.Distance(gameObject.transform.position, player.transform.position);
            //if (distanceToPlayer < 2)
            //{
            //    clicked = false;
            //    Interact();
            //}
        }
    }
}
