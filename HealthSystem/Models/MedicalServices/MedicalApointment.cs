public class MedicalAppointment(DateTime appointmentDate, int patientId, int doctorId, MedicalServices medicalService)
{
	public int AppointmentId { get; }
    public DateTime AppointmentDate { get; } = appointmentDate;
    public int PatientId { get; } = patientId;
    public int DoctorId { get; } = doctorId;
    public MedicalServices MedicalService { get; } = medicalService;
}