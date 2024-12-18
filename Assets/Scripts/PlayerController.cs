using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private BoxCollider2D boundaries;
    [SerializeField] private Transform fruitThrowTransform;

    private Bounds bounds;

    private float leftBound;
    private float rightBound;

    private float startingLeftBound;
    private float startingRightBound;

    private float offset;

    private void Awake()
    {
        bounds = boundaries.bounds;

        offset = transform.position.x - fruitThrowTransform.position.x;

        leftBound = bounds.min.x + offset;
        rightBound = bounds.max.x + offset;

        startingLeftBound = leftBound;
        startingRightBound = rightBound;
    }

    private void Update()
    {
        MoveHandler();
    }

    private void MoveHandler()
    {
        Vector3 newPosition = transform.position + new Vector3(UserInput.MoveInput.x * moveSpeed * Time.deltaTime, 0f, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, leftBound, rightBound);

        transform.position = newPosition;
    }

    public void ChangeBoundary(float extraWidth)
    {
        leftBound = startingLeftBound;
        rightBound =startingRightBound; 

        leftBound += ThrowFruitController.instance.Bounds.extents.x + extraWidth;
        rightBound -= ThrowFruitController.instance.Bounds.extents.x +extraWidth;
    }
}
