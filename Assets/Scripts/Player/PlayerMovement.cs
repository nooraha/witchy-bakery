using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    Vector2 targetPosition;
    bool moving = false;
    public float playerSpeed = 2.5f;


    private void Update()
    {
        UpdateTargetPosition();
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

}
