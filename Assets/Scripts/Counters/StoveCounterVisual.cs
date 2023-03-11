using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter = null;
    [SerializeField] private GameObject stoveOnGameObject = null;
    [SerializeField] private GameObject stoveParticlesGameObject = null;

    private void Start() {
        stoveCounter.OnStartStoveAction += StoveCounter_OnStartStoveAction;
        stoveCounter.OnEndStoveAction += StoveCounter_OnEndStoveAction;

        Hide();
    }

    private void StoveCounter_OnStartStoveAction() {
        Show();
    }

    private void StoveCounter_OnEndStoveAction() {
        Hide();
    }

    private void Show() {
        stoveOnGameObject.SetActive(true);
        stoveParticlesGameObject.SetActive(true);
    }

    private void Hide() {
        stoveOnGameObject.SetActive(false);
        stoveParticlesGameObject.SetActive(false);
    }
}
