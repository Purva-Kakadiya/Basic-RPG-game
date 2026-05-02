using System.Net;
using UnityEngine;

public class GameInput : MonoBehaviour {

    [SerializeField] private Player player;

    private Vector2 inputVector;
    private float emoteTimer;
    private bool isWalking;
    private InputSystem_Actions inputActions;
    private const float BUTTON_PRESSED = 1f;

    private void Awake() { 
        inputActions = new InputSystem_Actions();
        inputActions.Player.Enable();
    }

    private void FixedUpdate() {
        if (BUTTON_PRESSED == inputActions.Player.Jump.ReadValue<float>()) {
            player.Jump();
        }
        if(BUTTON_PRESSED == inputActions.Player.Inventory.ReadValue<float>()) {
            player.OpneCloseInventory();
        }
    }

    public Vector2 GetMovementNormalized() {

        inputVector = inputActions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        if(inputVector != Vector2.zero) {
            isWalking = true;
        } else {
            isWalking = false;
        }
        return inputVector;

    }

    public bool GetSayHi() {
        if(inputActions.Player.Emote.WasPressedThisFrame()) {
            emoteTimer = 5f;
            return true;
        }
        if(emoteTimer <= 0f) {
            return false;
        }
        emoteTimer -= Time.deltaTime;
        return true;
    }

    public bool GetIsWalking() {
        return isWalking;
    }

}