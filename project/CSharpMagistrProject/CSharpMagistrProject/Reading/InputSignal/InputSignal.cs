using System;

namespace CSharpMagistrProject.Reading.InputSignal
{
    /// <summary>
    /// Класс исходного сигнала
    /// </summary>
	public class InputSignal
    {
        /// <summary>
        /// Id записи
        /// </summary>
	    public int Id { get; set; }

        /// <summary>
        /// Ключ сигнала
        /// </summary>
	    public int IdSignalsToAutomatisation { get; set; }
        
        /// <summary>
        /// Id события из списка событий
        /// </summary>
	    public int IdEvent { get; set; }

        /// <summary>
        /// Описание сигнала
        /// </summary>
	    public SignalDescription TagFieldName { get; set; }

        /// <summary>
        /// Индикатор типа перехода значения сигнала
        /// </summary>
	    public bool SignalSwitchType { get; set; }

        /// <summary>
        /// Время внесения записи
        /// </summary>
	    public DateTime ChangeDate { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Id записи</param>
        /// <param name="idSignalsToAutomatisation">Ключ сигнала</param>
        /// <param name="idEvent">Id события из списка событий</param>
        /// <param name="tagFieldName">Описание сигнала</param>
        /// <param name="signalSwitchType">Индикатор типа перехода значения сигнала</param>
        /// <param name="changeDate">Время внесения записи</param>
	    public InputSignal(int id, int idSignalsToAutomatisation, int idEvent, SignalDescription tagFieldName, bool signalSwitchType, DateTime changeDate)
	    {
	        Id = id;
	        IdSignalsToAutomatisation = idSignalsToAutomatisation;
	        IdEvent = idEvent;
	        SignalSwitchType = signalSwitchType;
	        ChangeDate = changeDate;
	        TagFieldName = tagFieldName;
	    }
    }
}
