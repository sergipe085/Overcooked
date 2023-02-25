using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class GameInput : Singleton<GameInput>
{
    private PlayerInputActions playerInputActions = null;
    public event EventHandler OnInteractAction = null;
    public event EventHandler OnInteractAlternateAction = null;

    protected override void Awake() {
        base.Awake();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += InteractPerformed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternatePerformed;
    }

    private void InteractPerformed(CallbackContext ctx) {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternatePerformed(CallbackContext ctx) {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}
