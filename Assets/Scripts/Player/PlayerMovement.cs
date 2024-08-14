using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    Vector2 targetPosition;
    bool moving = false;
    public float playerSpeed = 2.5f;
    bool allowedToMove = true;

    Rigidbody2D rb2D;

    private GameStateManager  gameStateManager;


    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        gameStateManager = FindObjectOfType<GameStateManager>();
        gameStateManager.onGameStateChange.AddListener(OnGameStateChange);
    }

    private void Update()
    {
        // DoArrowKeyMovement();
        if(allowedToMove)
        {
            UpdateTargetPosition();
        } 
        
        if(moving)
        {
            MoveToTargetPosition();
        }
    }

    void UpdateTargetPosition()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            if(hit.collider != null)
            {
                if (hit.collider.CompareTag("InteractableObject"))
                {
                    Interactable interactableScript = hit.collider.gameObject.GetComponent<Interactable>();
                    interactableScript.Interact();
                }
                if (hit.collider.CompareTag("Floor"))
                {
                    targetPosition = new Vector2(hit.point.x, hit.point.y);
                    moving = true;
                }
            }
            
        }
    }

    void MoveToTargetPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * playerSpeed);
        if(Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            moving = false;
        }
    }

    void OnGameStateChange(GameState state) {
        switch(state) {
            case GameState.Playing:
                Debug.Log("Player is allowed to move");
                allowedToMove = true;
                break;
            case GameState.Menu:
                Debug.Log("Player is not allowed to move");
                allowedToMove = false;
                break;
            default:
                Debug.Log("Player is allowed to move");
                allowedToMove = true;
                break;
        }
    }

    // void DoArrowKeyMovement()
    // {
    //     float deltaX = 0;
    //     float deltaY = 0;

    //     if(Input.GetKeyDown(KeyCode.UpArrow))
    //     {
    //         deltaX = 0.5f;
    //         deltaY = 0.25f;
    //         rb2D.MovePosition(new Vector2(transform.position.x + deltaX, transform.position.y + deltaY));
    //     }
    //     if(Input.GetKeyDown(KeyCode.DownArrow))
    //     {
    //         deltaX = -0.5f;
    //         deltaY = -0.25f;
    //         rb2D.MovePosition(new Vector2(transform.position.x + deltaX, transform.position.y + deltaY));
    //     }

    //     if(Input.GetKeyDown(KeyCode.LeftArrow))
    //     {
    //         deltaX = -0.5f;
    //         deltaY = 0.25f;
    //         rb2D.MovePosition(new Vector2(transform.position.x + deltaX, transform.position.y + deltaY));
    //     }
    //     if(Input.GetKeyDown(KeyCode.RightArrow))
    //     {
    //         deltaX = 0.5f;
    //         deltaY = -0.25f;

    //         rb2D.MovePosition(new Vector2(transform.position.x + deltaX, transform.position.y + deltaY));
    //     }
    // }

}
