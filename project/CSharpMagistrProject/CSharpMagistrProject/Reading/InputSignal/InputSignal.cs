using System;


namespace CSharpMagistrProject.Reading.InputSignal
{
    //Класс исходного сигнала
    public class InputSignal
    {
        public int id;
        public int ID_SIGNALS_TO_AUTOMATISATION;

        //Предполагается, что класс уже содержит idEvent произошедшего события из таблицы EventTable в БД
        public int idEvent;

        public SignalDescription TAG_FIELD_NAME;
        public bool SIGNAL_SWITCH_TYPE;
        public DateTime CHANGE_DATE;
    }
}
