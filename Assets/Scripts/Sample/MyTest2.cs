using HB.Packages.GeneralUtility.General;
using UnityEngine;

namespace Sample
{
    public class MyTest2 : MonoBehaviour
    {
        [SerializeField] private GameEvent uiEvent;
        private void Start()
        {
            uiEvent.Subscribe((obj) => Debug.Log("Hello ui my test 2"));
        }
    }
}