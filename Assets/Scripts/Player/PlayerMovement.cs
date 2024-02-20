using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 targetPosition = Vector2.zero;
    public int speed = 10;

    private void Update()
    {
        CheckIfTargetPosition();

        if(Input.GetMouseButtonDown(0))
        {
            // if player clicked on the floor move to position
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void CheckIfTargetPosition()
    {
        if (!targetPosition.Equals(Vector2.zero))
        {
            MoveToTargetPosition();
            if (Vector2.Distance(transform.position, targetPosition) < 0.01)
            {
                targetPosition = Vector2.zero;
            }
        }
    }

    void MoveToTargetPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }
}
