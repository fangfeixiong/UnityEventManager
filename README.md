# UnityEventManager
unity C# 事件管理器

添加事件

    void Start()
    {
        EventManager.addEventListener(EventType.ClickBlock, eventClickBlock);
    }

    public void eventClickBlock(EventData data)
    {
        Debug.Log("clickBlock");
    }
    
删除事件

    void Start()
    {
        EventManager.removeEventListener(EventType.ClickBlock, eventClickBlock);
    }

    public void eventClickBlock(EventData data)
    {
        Debug.Log("clickBlock");
    }
    
触发事件

    void OnMouseDown()
    {
        //不带参数
        EventManager.dispatchEvent(EventType.ClickBlock, null);
        //带参数（参数为object类型）
        EventManager.dispatchEvent(EventType.ClickBlock, "测试参数");
    }
    
# Authors
* PlayLive (新浪微博 @放飞吧小熊)
* @2015 [PlayLive](http://playlive.github.io/)