namespace Input
{
	namespace NeedEvent
	{
		//����������� �������
		class CNeedEvent
		{
			int id;
			int idEvent;
		public:
			CNeedEvent();
			//���������� ������������ �������
			void Add(string name);
			//�������� ������������ ������� �� id
			void Del(int id);
			//��������� ������ � �������
			void Update(int id, string name);
			void Show();
		};
	}
}