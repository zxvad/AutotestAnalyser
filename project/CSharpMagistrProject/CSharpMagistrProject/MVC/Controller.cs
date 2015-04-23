using System;
using System.Windows.Forms;
using CSharpMagistrProject.Analysis.DoneEvent;
using CSharpMagistrProject.Input.Events;
using CSharpMagistrProject.Input.NeedEvents;
using CSharpMagistrProject.Output.SelectResult;

namespace CSharpMagistrProject.MVC
{
    public class Controller
    {
        private IView _view;

        private Model _model;
        private Event _listEvent;
        private NeedEvent _listNeedEvent;
        private DoneEvent _doneEvent;

        private SelectEvent _selectEvent;
        private SelectNeedEvent _selectNeedEvent;
        private SelectResults _selectResults;

        public Controller()
        {
            _model = new Model();

            _listEvent = new Event(_model.DataBase, _model.DataBase.EventTable);
            _listNeedEvent = new NeedEvent(_model.DataBase, _model.DataBase.EventTable, _model.DataBase.NeedEventTable);
            _doneEvent = new DoneEvent(_model.DataBase, _model.DataBase.DoneEventTable);

            _selectEvent = new SelectEvent(_model.DataBase, _model.DataBase.EventTable);
            _selectNeedEvent = new SelectNeedEvent(_model.DataBase, _model.DataBase.EventTable, _model.DataBase.NeedEventTable);
            _selectResults = new SelectResults(_model.DataBase, _model.DataBase.EventTable, _model.DataBase.NeedEventTable, _model.DataBase.DoneEventTable,_model.DataBase.ResultTable);
        }

        public Form CreateFormView()
        {
            View formView=new View(this);
            _view = formView;
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
            _listEvent.Add(nameEvent);
        }

        public void DelEvent(int id)
        {
            _listEvent.Del(id);
        }

        public void UpdateNameEvent(int id, string newName)
        {
            _listEvent.Update(id,newName);
        }

        // Methods for Select events

        public void ShowEvents(DataGridView resultQueryGridView)
        {
            _selectEvent.Show(resultQueryGridView);
        }

        public void ShowNeedEvents(DataGridView resultQueryGridView)
        {
            _selectNeedEvent.Show(resultQueryGridView);
        }

        // Methods for NeedEvents
        
        public void AddNeedEvent(int idEvent)
        {
            _listNeedEvent.Add(idEvent);
        }

        public void DelNeedEvent(int id)
        {
            _listNeedEvent.Del(id);
        }

        public void UpdateNeedEvent(int id, int newIdEvent)
        {
            _listNeedEvent.Update(id,newIdEvent);
        }

        // Methods for Results

        public void ShowResults(DataGridView resultQueryGridView)
        {
            _selectResults.Show(resultQueryGridView);
        }

        // Methods for Logs

        public void AddToLog(Exception exception)
        {
            _model.LogFile.Write(exception);
        }


    }
}
