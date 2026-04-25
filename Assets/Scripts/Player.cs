using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour {

    [SerializeField] private LayerMask Ground;
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private float groundDistance = 0.2f;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float fallSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;

    private BoxCollider boxCollider;
    private float downForce;

    private void Awake() {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update() {
        transform.position += Vector3.down * downForce;

        Vector2 inputVector = gameInput.GetMovementNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * movementSpeed * Time.deltaTime;
    }

    private void FixedUpdate() {
        if (IsGrounded()) {
            downForce = 0f;
        } else {
            downForce = fallSpeed * Time.deltaTime;
        }
    }

    public bool IsGrounded() {
        RaycastHit hit;
        Vector3 boxSize = new Vector3(boxCollider.bounds.size.x, 0.01f, boxCollider.bounds.size.z / 2);
        if (Physics.BoxCast(feetPosition.position, boxSize, Vector3.down, out hit, Quaternion.identity, groundDistance, Ground)) {
            return true;
        }
        return false;
    }

    public void Jump() {
        transform.position += Vector3.up * jumpForce * Time.deltaTime;
    }

}
