public interface IAppointmentController
{
    bool ScheduleMedicalAppointment(out string message);
    void ViewAppointments();
    void ViewAppointmentsDoctor();
}