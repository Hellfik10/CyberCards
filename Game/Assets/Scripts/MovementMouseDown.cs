using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMouseDown : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacleLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, _obstacleLayer);

            if (hit.collider != null)
            {
                Vector3 targetPosition = hit.collider.transform.position;

                if (IsAdjacent(transform.position, targetPosition))
                {
                    transform.position = targetPosition;
                }
            }
        }
    }

    private bool IsAdjacent(Vector3 currentPosition, Vector3 targetPosition)
    {
        float cellSizeX = 1.8f; // Размер ячейки по горизонтали
        float cellSizeY = 2.4f; // Размер ячейки по вертикали

        // Округление координат до ближайших целых значений
        int currentX = Mathf.RoundToInt(currentPosition.x / cellSizeX);
        int currentY = Mathf.RoundToInt(currentPosition.y / cellSizeY);

        int targetX = Mathf.RoundToInt(targetPosition.x / cellSizeX);
        int targetY = Mathf.RoundToInt(targetPosition.y / cellSizeY);

        // Проверка, находится ли целевая позиция в пределах соседней ячейки
        return Mathf.Abs(currentX - targetX) + Mathf.Abs(currentY - targetY) == 1;
    }
}
