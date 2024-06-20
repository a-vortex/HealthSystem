using HealthSystem.Data;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly HealthSystemDbContext _context;

    public AppointmentRepository(HealthSystemDbContext context)
    {
        _context = context;
    }

    public void Add(MedicalAppointment medicalAppointment)
    {
        _context.MedicalAppointments.Add(medicalAppointment);
        _context.SaveChanges();
    }

    public List<MedicalAppointment> GetDoctorAppointments(int doctorid, DateTime appointmentDateTime)
    {
        return _context.MedicalAppointments
            .Where(a => a.DoctorId == doctorid && a.AppointmentDate == appointmentDateTime)
            .ToList();
    }
}