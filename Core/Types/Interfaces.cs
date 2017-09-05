using System;
using System.Collections.Generic;

namespace SampleHorse.Core.Types
{
    internal interface ISampleInterface
    {
        /*public*/ int Counter { get; set; }
        /*public*/ void DoSomething();
    }

    /*------------------------*/
    //Incoming message
    public interface IListenerInterface
    {
        string Listen();
    }

    //Send message
    public interface ITalkingInterface
    {
        void Talk(string msg);
    }

    //Interface composition
    public interface IChatInterface : IListenerInterface, ITalkingInterface
    { }


    /*Usages*/
    public class ChatTransport : IChatInterface, IListenerInterface, ITalkingInterface
    {
        public string Listen()
        {
            return Console.ReadLine();
        }

        public void Talk(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class ChatApplication
    {
        private readonly ITalkingInterface talker;
        private readonly IListenerInterface listener;

        public ChatApplication(IChatInterface chat)
        {
            //Interface segregation
            this.talker = chat;
            this.listener = chat;
        }

        public void SendMessage(string msg)
        {
            //Using segregated contract
            talker.Talk(msg);
        }

        public string GetMessage()
        {
            //Using segregated contract
            return listener.Listen();
        }
    }


}
