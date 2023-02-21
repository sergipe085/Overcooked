using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rig = null;
    [SerializeField] private float moveSpeed = 5.0f;

    private Vector3 moveDir = Vector2.zero;

    private void Update() {
        Vector2 inputVector = GameInput.Instance.GetMovementVectorNormalized();
        moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float rotateSpeed = 10.0f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }

    private void FixedUpdate() {
        rig.velocity = moveDir * moveSpeed;
    }

    public bool IsWalking() {
        return moveDir.magnitude != 0.0f;
    }
}
