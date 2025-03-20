using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private BoxCollider2D boundaries;
    [SerializeField] private Transform fruitThrowTransform;
    [SerializeField] private float deadZone = 0.3f; 

    private Bounds bounds;
    private float leftBound, rightBound;
    private float startingLeftBound, startingRightBound;
    private float offset;

    // Drop modunu kontrol eden bayrak
    public bool IsDropping { get; set; } = false;

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
        // Eğer drop modunda ise hareket güncellemesini atla
        if (!IsDropping)
            MoveHandler();
    }

    private void MoveHandler()
    {
        if (Mathf.Abs(UserInput.MoveInput.x) < deadZone) return;

        float targetX = Mathf.Clamp(
            transform.position.x + UserInput.MoveInput.x * moveSpeed * Time.deltaTime,
            leftBound,
            rightBound
        );

        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, targetX, 0.5f),
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
