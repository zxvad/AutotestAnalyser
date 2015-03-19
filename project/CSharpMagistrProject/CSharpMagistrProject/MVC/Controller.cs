using System.Windows.Forms;
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
            listEvent = new Event(model.dataBase, "EventTable");
            listNeedEvent=new NeedEvent(model.dataBase,"EventTable","NeedEventTable");
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

        public void ShowEvents(DataGridView resultQueryGridView)
        {
            listEvent.Show(resultQueryGridView);
        }

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
    }
}
