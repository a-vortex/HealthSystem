public interface IAppointmentRepository
{
    void Add(MedicalAppointment medicalAppointment);
    List<MedicalAppointment> GetDoctorAppointments(int doctorid, DateTime appointmentDateTime);
    List<MedicalAppointment> GetAppointmentsByUserId(int userid);
    List<MedicalAppointment> GetAppointmentsByDoctorId(int doctorid);
}