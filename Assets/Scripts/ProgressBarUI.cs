using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter = null;
    [SerializeField] private Image progressBarImage = null;
    [SerializeField] private Transform progressBarContainer = null;

    private void Start() {
        cuttingCounter.OnCutAction += CuttingCounter_OnCutAction;
        Hide();
    }

    private void CuttingCounter_OnCutAction(int currentProgress, int maxProgress) {
        Show();
        progressBarImage.fillAmount = (float)currentProgress / maxProgress;

        if (currentProgress >= maxProgress) {
           Hide();
        }
    }

    private void Show() {
        progressBarContainer.LookAt(Camera.main.transform, -Vector3.up);
        progressBarContainer.gameObject.SetActive(true);
    }

    private void Hide() {
        progressBarImage.fillAmount = 0;
        progressBarContainer.gameObject.SetActive(false); 
    }
}
