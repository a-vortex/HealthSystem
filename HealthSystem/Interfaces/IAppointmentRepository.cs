public interface IAppointmentRepository
{
    void Add(MedicalAppointment medicalAppointment);
    List<MedicalAppointment> GetDoctorAppointments(int doctorid, DateTime appointmentDateTime);
    // Outros métodos necessários
}