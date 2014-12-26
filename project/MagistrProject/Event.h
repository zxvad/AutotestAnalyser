#pragma once

namespace Input
{
	namespace Event
	{
		//Список событий
		class CEvent
		{
			int idEvent;
			string name;
			string sourceTable;
			string queryText;
		public:
			CEvent();

		private:
			//Возврщает новый id для вставки записи в БД
			int NewID();

		public:
			//Добавление события
			void Add(string name);

			//Удаление необходимого события по id
			void Del(int id);
			//Изменение записи о событии
			void Update(int id, string newName);

			//Вывод списка событий
			void Show();
		};
	}
}