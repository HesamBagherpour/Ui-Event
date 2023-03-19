using HB.Packages.GeneralUtility.General;
using UnityEngine;

namespace Sample
{
    public class Mytest : MonoBehaviour
    {
        [SerializeField] private GameEvent uiEvent;

        private void Start()
        {
            uiEvent.Subscribe((obj) => Debug.Log("Hello ui 1"));
        }

        [ContextMenu("Subscribe ui ")]
        public void TestEmit()
        {
            uiEvent.Emit(null);
        }
    }
}