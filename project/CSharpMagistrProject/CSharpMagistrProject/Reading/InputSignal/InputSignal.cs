using System;


namespace CSharpMagistrProject.Reading.InputSignal
{
    //Класс исходного сигнала
	public class InputSignal
    {
        public InputSignal(int id, int idSignalsToAutomatisation, int idEvent, SignalDescription tagFieldName, bool signalSwitchType, DateTime changeDate)
        {
            Id = id;
            IdSignalsToAutomatisation = idSignalsToAutomatisation;
            IdEvent = idEvent;
            SignalSwitchType = signalSwitchType;
            ChangeDate = changeDate;
            tagFieldName = TagFieldName;
        }

        public int Id { get; set; }
        public int IdSignalsToAutomatisation { get; set; }

        //Предполагается, что класс уже содержит idEvent произошедшего события из таблицы EventTable в БД
        public int IdEvent { get; set; }

        public SignalDescription TagFieldName { get; set; }
        public bool SignalSwitchType { get; set; }
        public DateTime ChangeDate { get; set; }
        
    }
}
