public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUserRepository _userRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository, IUserRepository userRepository)
    {
        _appointmentRepository = appointmentRepository;
        _userRepository = userRepository;
    }

    public bool ScheduleMedicalAppointment(AppointmentDto appointmentDto)
    {
        var customer = _userRepository.GetCustomerById(appointmentDto.CustomerId);
        var doctor = _userRepository.GetDoctorById(appointmentDto.DoctorId);

        var medicalAppointment = new MedicalAppointment
        {
            AppointmentDate = appointmentDto.AppointmentDateTime,
            PatientId = customer.id,
            Customer = customer,
            Doctor = doctor,
            medicalService = new MedicalAppointment.MedicalService
            {
                Name = appointmentDto.Name,
                Price = appointmentDto.Price,
                Description = appointmentDto.Description,
                Type = appointmentDto.Type,
                Area = appointmentDto.Area
            }

        };

        _appointmentRepository.Add(medicalAppointment);
        return true;
    }
}