using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : Singleton<GameInput>
{
    private PlayerInputActions playerInputActions = null;

    protected override void Awake() {
        base.Awake();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }
}
