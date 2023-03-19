using System;
using System.Collections;
using System.Collections.Generic;
using Infinite8.Packages.GeneralUtility.General;
using UnityEngine;

public class Mytest : MonoBehaviour
{
    [SerializeField] private GameEvent uiEvent;

    private void Start()
    {
        uiEvent.Subscribe((obj) => Debug.Log("Hello ui"));
    }

    [ContextMenu("Test")]
    public void TestEmit()
    {
        uiEvent.Emit(null);
    }
}