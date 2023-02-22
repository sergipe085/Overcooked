using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    [SerializeField] private ContainerCounter containerCounter = null;
    [SerializeField] private Animator animator = null;
    private int OpenCloseAnimatorHash = Animator.StringToHash("OpenClose");

    private void Start() {
        containerCounter.OnPlayerGrabbedObject += ContainerCounter_OnPlayerGrabbedObject;
    }

    private void ContainerCounter_OnPlayerGrabbedObject() {
        animator.SetTrigger(OpenCloseAnimatorHash);
    }
}
