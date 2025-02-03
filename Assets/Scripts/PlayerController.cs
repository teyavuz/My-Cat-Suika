using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private BoxCollider2D boundaries;
    [SerializeField] private Transform fruitThrowTransform;
    [SerializeField] private float deadZone = 0.1f; // <- Ekledik

    private Bounds bounds;
    private float leftBound, rightBound;
    private float startingLeftBound, startingRightBound;
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
        if (Mathf.Abs(UserInput.MoveInput.x) < deadZone) return; // <- Ekledik

        float targetX = Mathf.Clamp(
            transform.position.x + UserInput.MoveInput.x * moveSpeed * Time.deltaTime,
            leftBound,
            rightBound
        );

        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, targetX, 0.5f), // <- Daha yumuşak hareket
            transform.position.y,
            transform.position.z
        );
    }

    public void ChangeBoundary(float extraWidth)
    {
        leftBound = startingLeftBound + ThrowFruitController.instance.Bounds.extents.x + extraWidth;
        rightBound = startingRightBound - ThrowFruitController.instance.Bounds.extents.x - extraWidth;
    }
}