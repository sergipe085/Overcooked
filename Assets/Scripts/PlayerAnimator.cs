using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private Player player = null;
    
    private int IsWalkingParameter = Animator.StringToHash("IsWalking");

    private void Update() {
        bool isWalking = player.IsWalking();
        animator.SetBool(IsWalkingParameter, isWalking);
    }
}
