using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 事件类型
/// (根据需要取名称，不得重复)
/// </summary>
public enum EventType
{
    StartGame,
    ClickBlock
}


/// <summary>
/// 事件管理器
/// </summary>
public class EventManager {

    /// <summary>
    /// 事件监听池
    /// </summary>
    private static Dictionary<EventType, DelegateEvent> eventTypeListeners = new Dictionary<EventType, DelegateEvent>();

    /// <summary>
    /// 添加事件
    /// </summary>
    /// <param name="type">事件类型</param>
    /// <param name="listenerFunc">监听函数</param>
    public static void addEventListener(EventType type,DelegateEvent.EventHandler listenerFunc)
    {
        DelegateEvent delegateEvent;
        if(eventTypeListeners.ContainsKey(type))
        {
            delegateEvent = eventTypeListeners[type];
        }else
        {
            delegateEvent = new DelegateEvent();
            eventTypeListeners[type] = delegateEvent;
        }
        delegateEvent.addListener(listenerFunc);
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="type">事件类型</param>
    /// <param name="listenerFunc">监听函数</param>
    public static void removeEventListener(EventType type,DelegateEvent.EventHandler listenerFunc)
    {
        if (listenerFunc == null)
        {
            return;
        }
        if(!eventTypeListeners.ContainsKey(type))
        {
            return;
        }
        DelegateEvent delegateEvent = eventTypeListeners[type];
        delegateEvent.removeListener(listenerFunc);
    }
    
    /// <summary>
    /// 触发某一类型的事件  并传递数据
    /// </summary>
    /// <param name="type">事件类型</param>
    /// <param name="data">事件的数据(可为null)</param>
    public static void dispatchEvent(EventType type,object data)
    {
        if(!eventTypeListeners.ContainsKey(type))
        {
            return;
        }
        //创建事件数据
        EventData eventData = new EventData();
        eventData.type = type;
        eventData.data = data;

        DelegateEvent delegateEvent = eventTypeListeners[type];
        delegateEvent.Handle(eventData);
    }

}

/// <summary>
/// 事件类
/// </summary>
public class DelegateEvent
{
    /// <summary>
    /// 定义委托函数
    /// </summary>
    /// <param name="data"></param>
    public delegate void EventHandler(EventData data);
    /// <summary>
    /// 定义基于委托函数的事件
    /// </summary>
    public event EventHandler eventHandle;

    /// <summary>
    /// 触发监听事件
    /// </summary>
    /// <param name="data"></param>
    public void Handle(EventData data)
    {
        if(eventHandle!=null)
             eventHandle(data);
    }

    /// <summary>
    /// 删除监听函数
    /// </summary>
    /// <param name="removeHandle"></param>
    public void removeListener(EventHandler removeHandle)
    {
        if (eventHandle != null)
            eventHandle -= removeHandle;
    }

    /// <summary>
    /// 添加监听函数
    /// </summary>
    /// <param name="addHandle"></param>
    public void addListener(EventHandler addHandle)
    {
        eventHandle += addHandle;
    }
}

/// <summary>
/// 事件数据
/// </summary>
public class EventData
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public EventType type;
    /// <summary>
    /// 事件传递的数据
    /// </summary>
    public object data;
}
