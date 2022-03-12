using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Protocol.Code;

public class NetMsgCenter : MonoBehaviour
{
    public static NetMsgCenter Instance { get; set; }    
    private ClientPeer client { get; set; }
    
    private void Awake()
    {
        Instance = this;
        client = new ClientPeer();
        client.Connect("127.0.0.1", 6666);
    }

    private void FixedUpdate()
    {
        if(client == null) return;
        // 如果消息队列不为空，一直执行处理的方法
        while (client.netMsgQueue.Count > 0)
        {
            NetMsg msg = client.netMsgQueue.Dequeue();
            ProcessServerSendMsg(msg);
        }
    }

    #region 发送消息

    public void SendMsg(int opCode, int subCode, object value)
    {
        client.SendMsg(opCode, subCode, value);
    }

    public void SendMsg(NetMsg msg)
    {
        client.SendMsg(msg);
    }

    #endregion

    #region 处理服务器发来的消息

    private AccountHandler accountHandler = new AccountHandler();
    private MatchHandler matchHandler = new MatchHandler();
    private ChatHandler chatHandler = new ChatHandler();
    private FightHandler fightHandler = new FightHandler();
    
    /// <summary>
    /// 处理服务器发来的消息
    /// </summary>
    /// <param name="msg"></param>
    private void ProcessServerSendMsg(NetMsg msg)
    {
        switch (msg.opCode)
        {
            case OpCode.Account:
            {
                accountHandler.OnReceive(msg.subCode, msg.value);
                break;
            }
            case OpCode.Chat:
            {
                chatHandler.OnReceive(msg.subCode, msg.value);
                break;
            }
            case OpCode.Fight:
            {
                fightHandler.OnReceive(msg.subCode, msg.value);
                break;
            }
            case OpCode.Match:
            {
                matchHandler.OnReceive(msg.subCode, msg.value);
                break;
            }
        }
    }

    #endregion
}
