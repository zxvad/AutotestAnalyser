#pragma once
using namespace std;
#include "string"

namespace DB
{
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
		CDataBase(string server, string DBName, string userName, string password);
	private:
		void Connect();
		void Close();
	public:
		void DoQuery(string queryText);
	};
}