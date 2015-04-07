

namespace CSharpMagistrProject.Reading
{
    //Данные о сигнале
	//все что не отмечено BOOL/int это должно быть FLOAT
    public struct SignalDescription
    {
        public int ENGINEER_VALUE,
            ENGINEER_MIN_VALUE,
            ENGINEER_MAX_VALUE,
            WARNING_MIN_VALUE,
            WARNING_MAX_VALUE,
            ALARM_MIN_VALUE,
            ALARM_MAX_VALUE;
		//это флаги и они должны BOOL быть
        public float WARNING_MIN_VAL_F,//BOOL
            WARNING_MAX_VAL_F,//BOOL
            ALARM_MIN_VALUE_F,//BOOL
            ALARM_MAX_VALUE_F;//BOOL

        public int ROBOT_SERVICE_MODE,//BOOL
            ROBOT_NEED_TO_SET,//BOOL
            ROBOT_TIMER_VALUE,//int
            SENSOR_CIRCUIT_BREAK,//BOOL
            SENSOR_KZ_VALUE,//BOOL
            MODULE_BREAK_VALUE,
            MODULE_RESET_VALUE,//BOOL
            MODULE_ERRORCODE,//int
            MODULE_ON_OFF,//BOOL
            MAINTAIN_MIN,
            MAINTAIN_MAX,
            ANALOGSENS_UNDERRANGE,//BOOL
            ENGINEER_VALUE_BUFFER,
            SENS_SERVICE_MODE,//BOOL
            WARN_MIN_CONTROLON,//BOOL
            WARNMIN_TIMEOUT,//int
            WARN_MAX_CONTROLON,//BOOL
            WARNMAX_TIMEOUT,//int
            ALARM_MIN_CONTROLON,//BOOL
            ALARMMIN_TIMEOUT,//int
            ALARM_MAX_CONTROLON,//BOOL
            ALARMMAX_TIMEOUT,//int
            PANELS_ALARM_CODE,//int
            SETTINGS_TIMEOUT,//int
            FILTER_KOEFF,
            SENS_EMUL_VALUE,
            DISENS_INVERS_ON;//BOOL
    };
}
