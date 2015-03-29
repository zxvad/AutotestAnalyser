using System;
using System.Windows.Forms;
using CSharpMagistrProject.Check.CheckSystem;
using CSharpMagistrProject.Input.Events;
using CSharpMagistrProject.Input.NeedEvents;

namespace CSharpMagistrProject.MVC
{
    public class Controller
    {
        private IView view;

        private Model model;
        private Event listEvent;
        private NeedEvent listNeedEvent;

        public Controller()
        {
            model=new Model();
            listEvent = new Event(model.GetDataBase(), "EventTable");
            listNeedEvent=new NeedEvent(model.GetDataBase(),"EventTable","NeedEventTable");
            }
        public Form CreateFormView()
        {
            View formView=new View();
            view = formView;
            view.Controller = this;
            return formView;
        }



        public static void ShowMsg(string message)
        {
            MessageBox.Show(message);
            // ... добавить лог
        }

        // Methods for Events

        public void AddEvent(string nameEvent)
        {
            listEvent.Add(nameEvent);
        }

        public void DelEvent(int id)
        {
            listEvent.Del(id);
        }

        public void UpdateNameEvent(int id, string newName)
        {
            listEvent.Update(id,newName);
        }

        public void ShowEvents(DataGridView resultQueryGridView)
        {
            listEvent.Show(resultQueryGridView);
        }

        // Methods for NeedEvents

        public void ShowNeedEvents(DataGridView resultQueryGridView)
        {
            listNeedEvent.Show(resultQueryGridView);
        }

        public void AddNeedEvent(int idEvent)
        {
            listNeedEvent.Add(idEvent);
        }

        public void DelNeedEvent(int id)
        {
            listNeedEvent.Del(id);
        }

        public void UpdateNeedEvent(int id, int newIdEvent)
        {
            listNeedEvent.Update(id,newIdEvent);
        }

        // Methods for Logs

        public void AddToLog(Exception exception)
        {
            model.logFile.Write(exception);
        }


    }
}
