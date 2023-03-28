using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraEffects : Singleton<CameraEffects>
{
    public void ScreenShake(float duration, float strength, int vibrato) {
        transform.DORewind();
        transform.DOShakePosition(duration, strength, vibrato, 0);
    }

    public void DOMiniShake() {
        ScreenShake(0.3f, 0.2f, 13);
    }

    public void DOBigShake() {
        ScreenShake(0.3f, 0.4f, 13);
    }
}
