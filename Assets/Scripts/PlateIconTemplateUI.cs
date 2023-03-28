using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateIconTemplateUI : MonoBehaviour
{
    [SerializeField] private Image iconImage = null;

    public void UpdateImage(Sprite sprite) {
        iconImage.sprite = sprite;
    }
}
