using System;
using ZooKeeperNet;

namespace ZookeeperDemo01
{
    class Watcher : IWatcher
    {
        public void Process(WatchedEvent @event)
        {
            //if (@event.Type == EventType.NodeDataChanged)
            //{
            Console.WriteLine("已经触发了" + @event.Type + "事件！" + DateTime.Now);
            //}
        }
    }
}
