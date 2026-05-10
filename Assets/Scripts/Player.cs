using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour {

    [SerializeField] private LayerMask Ground;
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private Transform feetPosition;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float fallSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private UI_Inventory uiInventory;
    //[SerializeField] private Canvas InventoryManager;

    private BoxCollider boxCollider;
    private CharacterController characterController;
    private float downForce;
    private float verticalVelocity;
    private Inventory inventory;
    private float inventoryCooldownTimer;
    private const float inventoryCooldown = 0.5f;
    private bool isInventoryOpen = false;

    private void Awake() {
        boxCollider = GetComponent<BoxCollider>();
        characterController = GetComponent<CharacterController>();
        inventory = new Inventory();
        //uiInventory.SetInventory(inventory);
    }

    private void Update() {
        transform.position += Vector3.down * downForce;

        Vector2 inputVector = gameInput.GetMovementNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        characterController.Move(moveDir * movementSpeed * Time.deltaTime);

        if (IsGrounded()) {
            verticalVelocity = 0f;
        } else {
            if (verticalVelocity > 0f) {
                verticalVelocity -= fallSpeed * Time.deltaTime;
            } else {
                verticalVelocity -= fallSpeed * 2 * Time.deltaTime;
            }
        }
        characterController.Move(Vector3.up * verticalVelocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.F)) {
            Item newItem = new Item { itemType = Item.ItemType.Dagger, amount = 1 };
            inventory.AddItem(newItem);
            uiInventory.AddItemToInventory(newItem);
        }
        if(inventoryCooldownTimer > 0f) {
            inventoryCooldownTimer -= Time.deltaTime;
        } else {
            inventoryCooldownTimer = 0f;
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
        if (IsGrounded()) {
            verticalVelocity = jumpForce;
            characterController.Move(Vector3.up * verticalVelocity * Time.deltaTime);
        }
    }

    public void OpneCloseInventory() {
        if (inventoryCooldownTimer <= 0f) {
            if (isInventoryOpen) {
                InventoryManager.gameObject.SetActive(false);
                inventoryCooldownTimer = inventoryCooldown;
                isInventoryOpen = false;
            } else {
                InventoryManager.gameObject.SetActive(true);
                inventoryCooldownTimer = inventoryCooldown;
                isInventoryOpen = true;
            }
        }
    }

    public Inventory GetInventory() {
        return inventory;
    }

}
