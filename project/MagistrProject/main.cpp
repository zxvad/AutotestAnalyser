#include "stdio.h"
#include "conio.h"
#include "time.h"
#include "vector"
#include "iostream"

using namespace std;

void Error(char *err)
	{
	printf("\n ������: %s",err);
	};

//������ � �������
struct SignalDescription
	{
	int ENGINEER_VALUE,
		ENGINEER_MIN_VALUE,
		ENGINEER_MAX_VALUE,
		WARNING_MIN_VALUE,
		WARNING_MAX_VALUE,
		ALARM_MIN_VALUE,
		ALARM_MAX_VALUE;
	float WARNING_MIN_VAL_F,
		  WARNING_MAX_VAL_F,
		  ALARM_MIN_VALUE_F,
		  ALARM_MAX_VALUE_F;
    int ROBOT_SERVICE_MODE,
		ROBOT_NEED_TO_SET,
		ROBOT_TIMER_VALUE,
		SENSOR_CIRCUIT_BREAK,
		SENSOR_KZ_VALUE,
		MODULE_BREAK_VALUE,
		MODULE_RESET_VALUE,
		MODULE_ERRORCODE,
		MODULE_ON_OFF,
		MAINTAIN_MIN,
		MAINTAIN_MAX,
		ANALOGSENS_UNDERRANGE,
		ENGINEER_VALUE_BUFFER,
		SENS_SERVICE_MODE,
		WARN_MIN_CONTROLON,
		WARNMIN_TIMEOUT,
		WARN_MAX_CONTROLON,
		WARNMAX_TIMEOUT,
		ALARM_MIN_CONTROLON,
		ALARMMIN_TIMEOUT,
		ALARM_MAX_CONTROLON,
		ALARMMAX_TIMEOUT,
		PANELS_ALARM_CODE,
		SETTINGS_TIMEOUT,
		FILTER_KOEFF,
		SENS_EMUL_VALUE,
		DISENS_INVERS_ON;
	};

//����� ��������� �������
class �InputSignal
	{
	int id;
	int ID_SIGNALS_TO_AUTOMATISATION;
	SignalDescription TAG_FIELD_NAME;
	bool SIGNAL_SWITCH_TYPE;
	tm CHANGE_DATE;
	};

//����������� �������
class CDoneEvent
	{
	int id;
	int idEvent;
	tm CHANGE_DATE;
	public:
		//������ ��������� �������, ���������� ����������� �������
		void Set();
		//����� ������ ����������� �������
		void Show();
	};

//����������� �������
class CNeedEvent
	{
	int id;
	int idEvent;
	public:
		CNeedEvent();
		//���������� ������������ �������
		void Add(char *name);
		//�������� ������������ ������� �� id
		void Del(int id);
		//��������� ������ � �������
		void Update(int id, char *name);
		void Show();
	};

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

//������ �������
class CEvent
	{
	int id;
	char *name;
	public:
		CEvent();
		//���������� �������
		void Add(char *name);
		//�������� ������������ ������� �� id
		void Del(int id);
		//��������� ������ � �������
		void Update(int id, char *name);
		//����� ������ �������
		void Show();
	};

//������ ������� �� �����������
void Analiz()
	{
	};



int main ()
	{

	
	//getch();
	
	}