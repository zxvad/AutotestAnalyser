namespace Output
{
	namespace SelectResult
	{
		//���������� �������� ��������� �������
		class CResult
		{
			int idEvent;
			//��-������� ���������, ���-�� ���������
			bool result;
		public:
			//������: ��������� �� �������
			void Calculate();
			//����� �����������
			void Show();
		};
	}
}