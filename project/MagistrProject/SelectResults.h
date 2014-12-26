namespace Output
{
	namespace SelectResult
	{
		//Результаты проверки свершения событий
		class CResult
		{
			int idEvent;
			//Да-событие произошло, нет-не произошло
			bool result;
		public:
			//Расчет: произошли ли события
			void Calculate();
			//Вывод результатов
			void Show();
		};
	}
}