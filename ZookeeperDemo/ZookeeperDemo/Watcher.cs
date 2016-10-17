using System;
using System.Collections.Generic;
using System.Text;
using ZooKeeperNet;

namespace ZookeeperDemo
{
    class Watcher1 : IWatcher
    {
        public void Process(WatchedEvent @event)
        {
            //if (@event.Type == EventType.NodeDataChanged)
            //{
                Console.WriteLine("已经触发了" + @event.Type + "事件！"+DateTime.Now);
            //}
        }
    }
    class Watcher2 : IWatcher {
        private ZooKeeper zk;
        public Watcher2(ZooKeeper zk) {
            this.zk = zk;
        }

        public void Process(WatchedEvent @event) {
            //if (@event.Type == EventType.NodeDataChanged)
            //{
            Console.WriteLine("已经触发了" + @event.Type + @event.ToString() + "事件！Watcher2" + DateTime.Now);
            Console.Write(string.Join(",", zk.GetChildren("/root", this)));
            if (zk.Exists("/root/childone", true) != null) {
                zk.GetData("/root/childone", true, null);
            }
            
            Console.WriteLine();
            //}
        }
    }
}
