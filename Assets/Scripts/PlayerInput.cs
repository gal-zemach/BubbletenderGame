using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [Header("Keys")]
    public KeyCode GoUpstairsButton = KeyCode.W;
    public KeyCode GoDownstairsButton = KeyCode.S;

    [Header("Actions")]
    public UnityEvent GoUpstairsAction;
    public UnityEvent GoDownstairsAction;

    void Update()
    {
        if (Input.GetKeyDown(GoUpstairsButton))
        {
            GoUpstairsAction?.Invoke();
        }

        if (Input.GetKeyDown(GoDownstairsButton))
        {
            GoDownstairsAction?.Invoke();
        }
    }
}
