using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject = null;
    [SerializeField] private Image progressBarImage = null;
    [SerializeField] private Transform progressBarContainer = null;
    private IHasProgress hasProgress = null;

    private void Start() {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();

        if (hasProgress == null) {
            Debug.LogError("Game Object " + hasProgressGameObject + "does not implement IHasProgress interface");
        }

        hasProgress.OnChangeProgressAction += IHasProgress_OnChageProgressAction;
        Hide();
    }

    private void IHasProgress_OnChageProgressAction(float currentProgress, float maxProgress) {
        Show();
        progressBarImage.fillAmount = currentProgress / maxProgress;

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
