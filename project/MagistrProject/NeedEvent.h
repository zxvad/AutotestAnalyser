namespace Input
{
	namespace NeedEvent
	{
		//Необходимые события
		class CNeedEvent
		{
			int id;
			int idEvent;
		public:
			CNeedEvent();
			//Добавление необходимого события
			void Add(string name);
			//Удаление необходимого события по id
			void Del(int id);
			//Изменение записи о событии
			void Update(int id, string name);
			void Show();
		};
	}
}