using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpMagistrProject.Input.NeedEvent
{
    //Необходимые события
    class NeedEvent
    {
        int id;
	    int idEvent;

        public NeedEvent(){}

        //Добавление необходимого события
        public void Add(string name){}
			//Удаление необходимого события по id
        public void Del(int id){}
			//Изменение записи о событии
        public void Update(int id, string name){}
        public void Show(){}
    }
}
