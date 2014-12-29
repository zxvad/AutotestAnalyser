#pragma once

namespace Input
{
	namespace Event
	{
		//������ �������
		class CEvent
		{
			int idEvent;
			string name;
			string sourceTable;
			string queryText;
		public:
			CEvent();

		private:
			//��������� ����� id ��� ������� ������ � ��
			int NewID();

		public:
			//���������� �������
			void Add(string name);

			//�������� ������������ ������� �� id
			void Del(int id);
			//��������� ������ � �������
			void Update(int id, string newName);

			//����� ������ �������
			void Show();
		};
	}
}