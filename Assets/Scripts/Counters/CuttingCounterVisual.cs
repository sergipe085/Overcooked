using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private CuttingCounter cuttingCounter = null;

    private int cutTriggerHash = Animator.StringToHash("Cut");

    private void Start() {
        cuttingCounter.OnCutAction += CuttingCounter_OnCutAction;
    }

    private void CuttingCounter_OnCutAction(int _, int _2) {
        animator.SetTrigger(cutTriggerHash);
    }
}
