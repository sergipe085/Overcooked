using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private GameObject tomatoPrefab = null;
    [SerializeField] private Transform counterTopPoint = null;

    public void Interact() {
        Debug.Log("Interact with " + transform.name);
        Instantiate(tomatoPrefab, counterTopPoint);
    }
}
