using UnityEngine;
using UnityEngine.Events;

namespace HB.Packages.GeneralUtility.General
{
    [CreateAssetMenu(fileName = "ev_title", menuName = "Events/voidEvent")]
    public class GameEvent : ScriptableObject
    {
        public UnityEvent<object> unityEvent = new UnityEvent<object>();

        public void Subscribe(UnityAction<object> callback)
        {
            unityEvent.AddListener(callback);
        }

        public void Unsubscribe(UnityAction<object> callback)
        {
            unityEvent.RemoveListener(callback);
        }

        public void Emit(object data)
        {
            unityEvent?.Invoke(data);
        }

        [ContextMenu("Show All Listener")]
        public void ShowAllListener()
        {
            for (int i = 0; i < unityEvent.GetPersistentEventCount(); i++)
            {
                Debug.Log(unityEvent.GetPersistentMethodName(i));
            }
        }
    }
}