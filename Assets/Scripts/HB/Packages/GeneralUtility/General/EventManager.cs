using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HB.Packages.GeneralUtility.General
{
    public class EventManager : MonoSingleton<EventManager>
    {
        private Dictionary<string, EventData<object>> _eventDictionary = new Dictionary<string, EventData<object>>();


        public void RegisterEvent(string eventName, UnityAction<object> listener)
        {
            if (_eventDictionary.TryGetValue(eventName, out var currentEvent))
            {
                currentEvent.AddListener(listener);
            }
            else
            {
                currentEvent = new EventData<object>();
                currentEvent.AddListener(listener);
                _eventDictionary.Add(eventName, currentEvent);
            }
            Debug.unityLogger.Log($"EventManager | RegisterEvent | eventName: {eventName}");
        }

        public void RemoveEvent(string eventName, UnityAction<object> listener)
        {
            EventData<object> currentEvent = null;
            if (_eventDictionary.TryGetValue(eventName, out currentEvent))
            {
                currentEvent.RemoveListener(listener);
                Debug.unityLogger.Log($"EventManager | RemoveEvent | eventName: {eventName}");
            }
            else
            {
                Debug.unityLogger.LogWarning($"EventManager | RemoveEvent | eventName: {eventName}", "not found");
            }
        }

        public void SendEvent(string eventName, object val)
        {
            if (_eventDictionary == null)
            {
                Debug.unityLogger.LogWarning($"EventManager | SendEvent | eventName: {eventName}" , "not found");
                return;
            }

            EventData<object> currentEvent = null;
            if (_eventDictionary.TryGetValue(eventName, out currentEvent))
            {
                currentEvent.Invoke(val);
            }
            Debug.unityLogger.Log($"EventManager | SendEvent | eventName: {eventName}");
        }
    }
    
    public class EventData<T> : UnityEvent<T>
    {
    }
}