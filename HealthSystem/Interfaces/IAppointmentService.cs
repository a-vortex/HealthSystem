public interface IAppointmentService
{
    //Continua a lógica de agendamento de consulta médica
    //Retorna true se a consulta foi agendada com sucesso
    //appointmentDto: Dto da consulta médica a ser agendada
    bool ScheduleMedicalAppointment(AppointmentDto appointmentDto);
}