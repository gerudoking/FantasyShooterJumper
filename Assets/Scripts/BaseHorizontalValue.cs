using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BaseHorizontalInfo", menuName = "ScriptableObjects/BaseHorizontalValue", order = 1)]
public class BaseHorizontalValue : ScriptableObject
{
    public float speed = 0;
    private float originalSpeed = 0;

    public void SetupSpeed() {
        originalSpeed = speed;
    }

    public void ChangeSpeed(float newSpeed) {
        speed = newSpeed;
    }

    public void ResetSpeed() {
        speed = originalSpeed;
    }
}
