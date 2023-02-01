using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private Animator animator;
    private PlayerMoveEvents playerMoveEvents;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerMoveEvents = gameObject.GetComponent<PlayerMoveEvents>();
        playerMoveEvents.OnPositionChanged += PlayerMoveEvents_OnPositionChanged;
        playerMoveEvents.OnRunChanged += PlayerMoveEvents_OnRunChanged;
    }

    private void PlayerMoveEvents_OnRunChanged(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
    }

    private void PlayerMoveEvents_OnPositionChanged(float horizontal, float vertical)
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }

}
