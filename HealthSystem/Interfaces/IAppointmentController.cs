public interface IAppointmentController
{
    //Inicia a lógica de agendamento de consulta médica
    //Retorna true se a consulta foi agendada com sucesso
    //Retorna false e uma mensagem de erro se a consulta não foi agendada com sucesso
    bool ScheduleMedicalAppointment(out string message);

    //Renderiza a lista de consultas agendadas no console do paciente
    void ViewAppointments();

    //Renderiza a lista de consultas agendadas no console do médico
    void ViewAppointmentsDoctor();
}