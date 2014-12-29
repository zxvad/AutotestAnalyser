namespace Analysis
{
	//Совершенные события
	class CDoneEvent
	{
		int id;
		int idEvent;
	public:
		//анализ исходного сигнала, нахождение совершенных событий
		void Set();
		//вывод списка совершенных событий
		void Show();
	};
}