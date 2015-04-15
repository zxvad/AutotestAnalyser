using System;
using System.Windows.Forms;
using CSharpMagistrProject.Analysis.DoneEvent;
using CSharpMagistrProject.Check.CheckSystem;
using CSharpMagistrProject.Input.Events;
using CSharpMagistrProject.Input.NeedEvents;
using CSharpMagistrProject.Output.SelectResult;

namespace CSharpMagistrProject.MVC
{
    public class Controller
    {
        private IView view;

        private Model model;
        private Event listEvent;
        private NeedEvent listNeedEvent;
        private DoneEvent doneEvent;

        private SelectEvent selectEvent;
        private SelectNeedEvent selectNeedEvent;
        private SelectResults selectResults;

        public Controller()
        {
            model = new Model();

            listEvent = new Event(model.DataBase, model.DataBase.EventTable);
            listNeedEvent = new NeedEvent(model.DataBase, model.DataBase.EventTable, model.DataBase.NeedEventTable);
            doneEvent = new DoneEvent(model.DataBase, model.DataBase.DoneEventTable);

            selectEvent = new SelectEvent(model.DataBase, model.DataBase.EventTable);
            selectNeedEvent = new SelectNeedEvent(model.DataBase, model.DataBase.EventTable, model.DataBase.NeedEventTable);
            selectResults = new SelectResults(model.DataBase, model.DataBase.EventTable, model.DataBase.NeedEventTable, model.DataBase.DoneEventTable,model.DataBase.ResultTable);
        }

        public Form CreateFormView()
        {
            View formView=new View(this);
            view = formView;
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

        // Methods for Select events

        public void ShowEvents(DataGridView resultQueryGridView)
        {
            selectEvent.Show(resultQueryGridView);
        }

        public void ShowNeedEvents(DataGridView resultQueryGridView)
        {
            selectNeedEvent.Show(resultQueryGridView);
        }

        // Methods for NeedEvents
        
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

        // Methods for Results

        public void ShowResults(DataGridView resultQueryGridView)
        {
            selectResults.Show(resultQueryGridView);
        }

        // Methods for Logs

        public void AddToLog(Exception exception)
        {
            model.logFile.Write(exception);
        }


    }
}
