

namespace CSharpMagistrProject.Reading
{
    class SignalDescription
    {
        //Данные о сигнале
        public struct SignalDescriptionStruct
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
    }
}
