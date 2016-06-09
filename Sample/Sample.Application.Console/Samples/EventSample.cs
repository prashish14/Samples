using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Sample.Application.Console.Samples
{
    public class EventSample
    {
        public EventSample()
        {
        }

        public void Run()
        {
            MailManager mailManager = new MailManager();
            Fax fax = new Fax(mailManager);
            mailManager.SimulateNewMail("Pavel", "Katya", "Hello, world!");
            fax.Unregister(mailManager);
        }
    }

    public class NewMailEventArgs : EventArgs
    {
        private string _from;
        private string _to;
        private string _message;

        public string From 
        {
            get { return _from; }
        }
        public string To
        {
            get { return _to; }
        }
        public string Message
        {
            get { return _message; }
        }

        public NewMailEventArgs(string from, string to, string message)
        {
            _from = from;
            _to = to;
            _message = message;
        }
    }

    public class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;

        public virtual void OnNewMail(NewMailEventArgs e)
        {
            EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMail); //thread save, volatile - compiler: don't optimise

            if (temp != null) 
                temp(this, e);
        }

        public void SimulateNewMail(string from, string to, string subject)
        {
            NewMailEventArgs e = new NewMailEventArgs(from, to, subject);

            OnNewMail(e);
        }
    }

    public class Fax
    {
        public Fax(MailManager mailManager)
        {
            mailManager.NewMail += FaxMessage;
        }

        public void FaxMessage(Object sender, NewMailEventArgs e)
        {
            System.Console.WriteLine("From: {0}, To: {1}, Message: {2}", e.From, e.To, e.Message);
        }

        public void Unregister(MailManager mailManager)
        {
            mailManager.NewMail -= FaxMessage;
        }
    }

    // explicit managment of register/ unregister events
    //TODO: explicit managment example
}
