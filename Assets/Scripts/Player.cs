using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>, IKitchenObjectParent
{
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs {
        public BaseCounter selectedCounter;
    }

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 15.0f;
    [SerializeField] private LayerMask interactableLayer;

    private Vector3 moveDir = Vector3.zero;
    private Vector3 lookDir = Vector3.zero;

    private BaseCounter selectedCounter = null;

    [SerializeField] private Transform kitchenObjectTransformPoint = null;
    private KitchenObject kitchenObject = null;

    private void Start() {
        GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
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
            selectedCounter.Interact(this);
        }
    }

    private void HandleInteractions() {
        float interactionDistance = 2f;

        selectedCounter = null;
        if (Physics.Raycast(transform.position, lookDir, out RaycastHit hit, interactionDistance, interactableLayer)) {
            BaseCounter counter = hit.transform.GetComponent<BaseCounter>();
            if (counter) {
                selectedCounter = counter;
            }
        }

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs() {
            selectedCounter = selectedCounter
        });
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

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }

    public Transform GetKitchenObjectPoint() {
        return kitchenObjectTransformPoint;
    }
}
