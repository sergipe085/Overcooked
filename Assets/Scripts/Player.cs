using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 15.0f;
    [SerializeField] private LayerMask interactableLayer;

    private Vector3 moveDir = Vector3.zero;
    private Vector3 lookDir = Vector3.zero;

    private ClearCounter selectedCounter = null;

    private void OnEnable() {
        GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
    }

    private void OnDisable() {
        GameInput.Instance.OnInteractAction -= GameInput_OnInteractAction;
    }

    private void Update() {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking() {
        return moveDir.magnitude != 0.0f;
    }

    private void GameInput_OnInteractAction(object sender, EventArgs args) {
        if (selectedCounter) {
            selectedCounter.Interact();
        }
    }

    private void HandleInteractions() {
        float interactionDistance = 2.8f;

        selectedCounter = null;
        if (Physics.Raycast(transform.position, lookDir, out RaycastHit hit, interactionDistance, interactableLayer)) {
            ClearCounter counter = hit.transform.GetComponent<ClearCounter>();
            if (counter) {
                selectedCounter = counter;
            }
        }
    }

    private void HandleMovement() {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        moveDir = new Vector3(inputVector.x, 0f, inputVector.y).normalized;

        if (moveDir.magnitude != 0.0f) {
            lookDir = moveDir;
        }
        
        float playerHeight = 0.7f;
        float playerRadius = 0.5f;
        float moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove) {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove) {
                moveDir = moveDirX;
            }
            else {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove) {
                    moveDir = moveDirZ;
                }
            }
        }

        if (canMove) {
            transform.position += moveDir * moveDistance;
        }

        transform.forward = Vector3.Slerp(transform.forward, lookDir, Time.deltaTime * rotateSpeed);
    }
}
