public class MedicalAppointment
{
    public int AppointmentId { get; }
    public DateTime AppointmentDate { get; }
    public int PatientId { get; }
    public int DoctorId { get; }
    public MedicalService MedicalService { get; } = new MedicalService();

    public MedicalAppointment() { }
    public MedicalAppointment(DateTime appointmentDate, int patientId, int doctorId, MedicalService medicalService)
    {
        AppointmentDate = appointmentDate;
        PatientId = patientId;
        DoctorId = doctorId;
        MedicalService = medicalService;
    }
}
