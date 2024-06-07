public abstract class MedicalAppointment
{
        public DateTime AppointmentDate { get; set; }
        public string? PatientName { get; set; }
        public string? DoctorName { get; set; }

        public abstract void ScheduleAppointment();
        public abstract void CancelAppointment();
}