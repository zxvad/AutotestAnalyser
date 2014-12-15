#include "stdio.h"
#include "conio.h"
#include "time.h"
#include "string"
#include "iostream"

using namespace std;

void ShowError(string err)
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
		void Add(string name);
		//�������� ������������ ������� �� id
		void Del(int id);
		//��������� ������ � �������
		void Update(int id, string name);
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
	int idEvent;
	string name;
	public:
		CEvent();
		//���������� �������
		void Add(string name);
		//�������� ������������ ������� �� id
		void Del(int id);
		//��������� ������ � �������
		void Update(int id, string name);
		//����� ������ �������
		void Show();
};

class CDataBase
{
private:
	string userName;
	string password;
	string server;
	string DBName;
public:
	bool isConnected;

public:
	CDataBase(string server, string DBName, string userName, string password)
	{
		this->server = server;
		this->DBName = DBName;
		this->userName =userName;
		this->password = password;

		this->isConnected=false;

		this->Connect();
	};
private:
	void Connect()
	{
		string ConnectionString="Provider=SQLNCLI10; Persist Security Info=True";
		ConnectionString+="; Data Source=" + this->server;
		ConnectionString+="; Password=" + this->password;
		ConnectionString+="; User ID=" + this->userName;
		ConnectionString+="; Initial Catalog=" + this->DBName;

		try 
		{
			// ... ���������� � �� ����� ���������

			this->isConnected=true;
		}
		catch(...)
		{
			ShowError("������ ���������� � ��");
		};
		
	};
private: 
	void Close()
	{
		try
		{
			// .....�������� ����������

			this->isConnected=false;
		}
		catch (...)
		{
			ShowError("������ �������� ��");
		}

	};
private:
	void DoQuery(string SQLQuery)
	{
		if (this->isConnected)
		{
			// ... ���������� ������� 
		} 
		else
		{
			ShowError("��� ���������� � ��");
		};

	};

};


//������ ������� �� �����������
void Analiz()
	{
	};



int main ()
	{
		CDataBase DB("VAS-PC\sqlexpress", "MagistrDB","testuser","1");

	
	//getch();
	return 0;
	}