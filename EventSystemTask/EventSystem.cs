namespace EventSystemTask;

public static class EventSystem
{
    private static readonly Dictionary<string, Delegate> Actions;

    static EventSystem()
    {
        Actions = new Dictionary<string, Delegate>();
    }

    public static void CreateEvent(string eventName)
    {
        if (ContainsEvent(eventName))
        {
            throw new ArgumentException("EventSystem already have an event with the same name", nameof(eventName));
        }
        Actions.Add(eventName, new Action(()=>{}));
    }

    public static void CreateEvent<T>(string eventName)
    {
        if (ContainsEvent(eventName))
        {
            throw new ArgumentException("EventSystem already have an event with the same name", nameof(eventName));
        }
        
        Actions.Add(eventName, new Action<T>((_)=>{}));
    }

    public static bool TryCreateEvent(string eventName)
    {
        if (ContainsEvent(eventName))
        {
            return false;
        }

        CreateEvent(eventName);
        return true;

    }

    public static void RemoveEvent(string eventName)
    {
        if (!ContainsEvent(eventName))
        {
            throw new ArgumentException("EventSystem doesn't contains an event with this name", nameof(eventName));
        }
        Actions.Remove(eventName);
    }
    

    public static bool TryRemoveEvent(string eventName)
    {
        if (!ContainsEvent(eventName))
        {
            return false;
        }
        RemoveEvent(eventName);
        return true;
    }

    public static void RaiseEvent(string eventName)
    {
        if (!ContainsEvent(eventName))
        {
            throw new ArgumentException("EventSystem doesn't contains an event with this name", nameof(eventName));
        }

        if (Actions[eventName] is not Action action)
        {
            throw new ArgumentException("Unable to cast this event to Action");
        }
        
        action.Invoke();
    }
    
    public static void RaiseEvent<T>(string eventName, T obj)
    {
        if (!ContainsEvent(eventName))
        {
            throw new ArgumentException("EventSystem doesn't contains an event with this name", nameof(eventName));
        }

        if (Actions[eventName] is not Action<T> action)
        {
            throw new ArgumentException("Unable to cast this event to Action");
        }
        
        action.Invoke(obj);
    }

    public static bool TryRaiseEvent(string eventName)
    {
        if (!ContainsEvent(eventName))
        {
            return false;
        }
        RaiseEvent(eventName);
        return true;
    }

    public static bool ContainsEvent(string eventName) => Actions.ContainsKey(eventName);

    public static void Clear()
    {
        Actions.Clear();
    }

    public static void Subscribe(string eventName, Action callBack)
    {
        if (!ContainsEvent(eventName))
        {
            throw new ArgumentException("EventSystem doesn't contains an event with this name", nameof(eventName));
        }

        if (Actions[eventName] is not Action action)
        {
            throw new ArgumentException("Unable to cast this event to Action");
        }

        Actions[eventName] = action + callBack;
    }
    
    public static void Subscribe<T>(string eventName, Action<T> callBack)
    {
        if (!ContainsEvent(eventName))
        {
            throw new ArgumentException("EventSystem doesn't contains an event with this name", nameof(eventName));
        }
        
        if (Actions[eventName] is not Action<T> action)
        {
            throw new ArgumentException("Unable to cast this event to Action");
        }

        Actions[eventName] = action + callBack;
    }

    public static void UnSubscribe(string eventName, Action callback)
    {
        if (!ContainsEvent(eventName))
        {
            throw new ArgumentException("EventSystem doesn't contains an event with this name", nameof(eventName));
        }
        
        if (Actions[eventName] is not Action action)
        {
            throw new ArgumentException("Unable to cast this event to Action");
        }

        Actions[eventName] = action - callback;
    }
    
    public static void UnSubscribe<T>(string eventName, Action<T> callback)
    {
        if (!ContainsEvent(eventName))
        {
            throw new ArgumentException("EventSystem doesn't contains an event with this name", nameof(eventName));
        }
        
        if (Actions[eventName] is not Action<T> action)
        {
            throw new ArgumentException("Unable to cast this event to Action");
        }

        Actions[eventName] = action - callback;
    }

    public static string[] GetEvents() => Actions.Keys.ToArray();
}