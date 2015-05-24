using System;
using System.Windows.Forms;
using CSharpMagistrProject.Analysis.DoneEvent;
using CSharpMagistrProject.Input.Events;
using CSharpMagistrProject.Input.NeedEvents;
using CSharpMagistrProject.Output.SelectResult;

namespace CSharpMagistrProject.MVC
{
    /// <summary>
    /// Контроллер (MVC)
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Представление (MVC)
        /// </summary>
        private IView _view;

        /// <summary>
        /// Модель (MVC)
        /// </summary>
        private Model _model;

        /// <summary>
        /// Список событий
        /// </summary>
        private Event _listEvent;

        /// <summary>
        /// Необходимые события
        /// </summary>
        private NeedEvent _listNeedEvent;

        /// <summary>
        /// Совершенные события
        /// </summary>
        private DoneEvent _doneEvent;

        /// <summary>
        /// Выборка событий
        /// </summary>
        private SelectEvent _selectEvent;

        /// <summary>
        /// Выборка необходимых событий
        /// </summary>
        private SelectNeedEvent _selectNeedEvent;

        /// <summary>
        /// Выборка результатов
        /// </summary>
        private SelectResults _selectResults;

        /// <summary>
        /// Главный конструктор
        /// </summary>
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

        /// <summary>
        /// Создание формы представления (MVC)
        /// </summary>
        /// <returns>Представление</returns>
        public Form CreateFormView()
        {
            View formView=new View(this);
            _view = formView;
            return formView;
        }


        /// <summary>
        /// Вывод сообщения
        /// </summary>
        /// <param name="message">Строка сообщения</param>
        public static void ShowMsg(string message)
        {
            MessageBox.Show(message);
        }
        
        #region Events

        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="nameEvent">Наименование события</param>
        public void AddEvent(string nameEvent)
        {
            _listEvent.Add(nameEvent);
        }

        /// <summary>
        /// Удаление события
        /// </summary>
        /// <param name="id">id события для удаления</param>
        public void DelEvent(int id)
        {
            _listEvent.Del(id);
        }

        /// <summary>
        /// Изменение события
        /// </summary>
        /// <param name="id">id события для изменения</param>
        /// <param name="newName">Новое наименование события</param>
        public void UpdateNameEvent(int id, string newName)
        {
            _listEvent.Update(id, newName);
        }

        #endregion
        
        #region Select events

        /// <summary>
        /// Вывод всех событий
        /// </summary>
        /// <param name="resultQueryGridView">DataGridView для отображения результатов</param>
        public void ShowEvents(DataGridView resultQueryGridView)
        {
            _selectEvent.Show(resultQueryGridView);
        }

        /// <summary>
        /// Вывод всех необходимых событий
        /// </summary>
        /// <param name="resultQueryGridView">DataGridView для отображения результатов</param>
        public void ShowNeedEvents(DataGridView resultQueryGridView)
        {
            _selectNeedEvent.Show(resultQueryGridView);
        }

        #endregion
        
        #region NeedEvents

        /// <summary>
        /// Добавление необходимого события
        /// </summary>
        /// <param name="idEvent">id события и списка событий для добавления</param>
        public void AddNeedEvent(int idEvent)
        {
            _listNeedEvent.Add(idEvent);
        }

        /// <summary>
        /// Удаление необходимого события 
        /// </summary>
        /// <param name="id">id необходимого события</param>
        public void DelNeedEvent(int id)
        {
            _listNeedEvent.Del(id);
        }

        /// <summary>
        /// Изменение необходимого события
        /// </summary>
        /// <param name="id">id события для изменения</param>
        /// <param name="newIdEvent">id нового события из списка событий</param>
        public void UpdateNeedEvent(int id, int newIdEvent)
        {
            _listNeedEvent.Update(id, newIdEvent);
        }

        #endregion
        
        #region Results

        /// <summary>
        /// вывод результатов
        /// </summary>
        /// <param name="resultQueryGridView">DataGridView для отображения результатов</param>
        public void ShowResults(DataGridView resultQueryGridView)
        {
            _selectResults.Show(resultQueryGridView);
        }

        #endregion
        
        #region Logs

        /// <summary>
        /// Добавить запись в Лог
        /// </summary>
        /// <param name="exception"></param>
        public void AddToLog(Exception exception)
        {
            _model.LogFile.Write(exception);
        }

        #endregion
        

    }
}
