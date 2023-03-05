using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject selectedObject = null;

    private void Start() {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanger;
    }

    private void Player_OnSelectedCounterChanger(object sender, Player.OnSelectedCounterChangedEventArgs args) {
        if (args.selectedCounter != null && args.selectedCounter.transform == transform.parent) {
            Show();
            return;
        }

        Hide();
    }

    private void Show() {
        selectedObject.SetActive(true);
    }

    private void Hide() {
        selectedObject.SetActive(false);
    }
}
