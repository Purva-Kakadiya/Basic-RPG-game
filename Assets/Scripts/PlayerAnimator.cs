using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    [SerializeField] private GameInput gameInput;

    private Animator animator;
    private float emoteTimer;
    private const string SAY_HI = "SayHi";
    private const string IS_WALKING = "IsWalking";

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        animator.SetBool(SAY_HI, gameInput.GetSayHi());
        animator.SetBool(IS_WALKING, gameInput.GetIsWalking());
    }

}