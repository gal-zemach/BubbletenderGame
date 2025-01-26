using System;
using System.Collections.Generic;

public static class EventManager
{
    private static Dictionary<string, Action> eventDictionary = new Dictionary<string, Action>();

    public static void Subscribe(string eventName, Action listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent += listener;
            eventDictionary[eventName] = thisEvent;
        }
        else
        {
            eventDictionary.Add(eventName, listener);
        }
    }

    public static void Unsubscribe(string eventName, Action listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent -= listener;
            if (thisEvent == null)
            {
                eventDictionary.Remove(eventName);
            }
            else
            {
                eventDictionary[eventName] = thisEvent;
            }
        }
    }

    public static void Broadcast(string eventName)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}