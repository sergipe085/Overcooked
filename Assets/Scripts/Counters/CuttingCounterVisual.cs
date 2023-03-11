using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private CuttingCounter cuttingCounter = null;

    private int cutTriggerHash = Animator.StringToHash("Cut");

    private void Start() {
        cuttingCounter.OnChangeProgressAction += CuttingCounter_OnCutAction;
    }

    private void CuttingCounter_OnCutAction(float _, float _2) {
        animator.SetTrigger(cutTriggerHash);
    }
}
