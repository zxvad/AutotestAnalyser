namespace CSharpMagistrProject.Reading
{
    /// <summary>
    /// Данные о сигнале
    /// </summary>
    public struct SignalDescription
    {
        public float ENGINEER_VALUE;
        public float ENGINEER_MIN_VALUE;
        public float ENGINEER_MAX_VALUE;
        public float WARNING_MIN_VALUE;
        public float WARNING_MAX_VALUE;
        public float ALARM_MIN_VALUE;
        public float ALARM_MAX_VALUE;
        public float MODULE_BREAK_VALUE;
        public float MAINTAIN_MIN;
        public float MAINTAIN_MAX;
        public float FILTER_KOEFF;
        public float SENS_EMUL_VALUE;
        public float ENGINEER_VALUE_BUFFER;

        public bool WARNING_MIN_VAL_F;
        public bool WARNING_MAX_VAL_F;
        public bool ALARM_MIN_VALUE_F;
        public bool ALARM_MAX_VALUE_F;
        public bool ROBOT_SERVICE_MODE;
        public bool ROBOT_NEED_TO_SET;

        public bool SENSOR_CIRCUIT_BREAK;
        public bool SENSOR_KZ_VALUE;
        public bool MODULE_RESET_VALUE;
        public bool DISENS_INVERS_ON;
        public bool MODULE_ON_OFF;

        public bool ANALOGSENS_UNDERRANGE;
        public bool SENS_SERVICE_MODE;
        public bool WARN_MIN_CONTROLON;
        public bool WARN_MAX_CONTROLON;
        public bool ALARM_MIN_CONTROLON;
        public bool ALARM_MAX_CONTROLON;

        
        public int MODULE_ERRORCODE;
        public int WARNMIN_TIMEOUT;
        public int WARNMAX_TIMEOUT;
        public int ALARMMIN_TIMEOUT;
        public int ALARMMAX_TIMEOUT;
        public int PANELS_ALARM_CODE;
        public int SETTINGS_TIMEOUT;
        public int ROBOT_TIMER_VALUE;
    }
}