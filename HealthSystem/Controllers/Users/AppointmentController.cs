using System.Globalization;
using HealthSystem.Models.Users;

public class AppointmentController : IAppointmentController
{
    private readonly IAppointmentService _appointmentService;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUserService _userService;
    private readonly IUserSessionService _userSessionService;
    private readonly IUserRepository _userRepository;
    public AppointmentController(IAppointmentService appointmentService, IUserService userService, IUserSessionService userSessionService, IAppointmentRepository appointmentRepository, IUserRepository userRepository)
    {
        _appointmentService = appointmentService;
        _userRepository = userRepository;
        _userService = userService;
        _userSessionService = userSessionService;
        _appointmentRepository = appointmentRepository;
    }
    public void ViewAppointmentsDoctor()
    {
        var doctor = _userRepository.GetByLogin(_userSessionService.CurrentUser.Login);
        var appointments = _appointmentRepository.GetAppointmentsByDoctorId(doctor.id);
        RenderTitle("Appointments");
        int windowWidth = Console.WindowWidth;
        string border = new('=', windowWidth - 1);
        string borderline = new('_', windowWidth - 1);
        Console.WriteLine("=> Your Appointments");
        Console.WriteLine();
        foreach (var appointment in appointments)
        {
            var customer = _userRepository.GetCustomerById(appointment.PatientId);
            Console.WriteLine(borderline);
            Console.WriteLine();
            Console.WriteLine($"Name: {appointment.medicalService.Name}");
            Console.WriteLine();
            Console.WriteLine($"Appointment Date: {appointment.AppointmentDate}");
            Console.WriteLine();
            Console.WriteLine($"Customer: {customer.PersonalInfo.Name}");
            Console.WriteLine();
            Console.WriteLine($"Price: {appointment.medicalService.Price}");
            Console.WriteLine();
            Console.WriteLine($"Type: {appointment.medicalService.Type}");
            Console.WriteLine();
            Console.WriteLine($"Area: {appointment.medicalService.Area}");
            Console.WriteLine();
            Console.WriteLine($"Description: {appointment.medicalService.Description}");
            Console.WriteLine();
        }
        Console.WriteLine(borderline);
        Console.WriteLine(border);
        Console.WriteLine("> Press any key to continue...");
        Console.ReadKey();
    }
    public void ViewAppointments()
    {
        var user = _userRepository.GetByLogin(_userSessionService.CurrentUser.Login);
        var appointments = _appointmentRepository.GetAppointmentsByUserId(user.id);
        RenderTitle("Appointments");
        int windowWidth = Console.WindowWidth;
        string border = new('=', windowWidth - 1);
        string borderline = new('_', windowWidth - 1);
        Console.WriteLine("=> Your Appointments");
        Console.WriteLine();

        foreach (var appointment in appointments)
        {
            var doctor = _userRepository.GetDoctorById(appointment.DoctorId);
            Console.WriteLine(borderline);
            Console.WriteLine();
            Console.WriteLine($"Name: {appointment.medicalService.Name}");
            Console.WriteLine();
            Console.WriteLine($"Appointment Date: {appointment.AppointmentDate}");
            Console.WriteLine();
            Console.WriteLine($"Doctor: {doctor.PersonalInfo.Name}");
            Console.WriteLine();
            Console.WriteLine($"Price: {appointment.medicalService.Price}");
            Console.WriteLine();
            Console.WriteLine($"Type: {appointment.medicalService.Type}");
            Console.WriteLine();
            Console.WriteLine($"Area: {appointment.medicalService.Area}");
            Console.WriteLine();
            Console.WriteLine($"Description: {appointment.medicalService.Description}");
            Console.WriteLine();
        }
        Console.WriteLine(borderline);
        Console.WriteLine(border);
        Console.WriteLine("> Press any key to continue...");
        Console.ReadKey();
    }
    public bool ScheduleMedicalAppointment(out string message)
    {
        message = string.Empty;
        var CustomerLogin = _userSessionService.CurrentUser.Login;
        var customerUser = _userRepository.GetByLogin(CustomerLogin);

        var type = GetValidMedicalSerivetype();
        MedicalServiceArea area;
        if (type != MedicalServiceType.Exam)
        {
            area = GetValidMedicalSeriveArea();
        }
        else
        {
            area = MedicalServiceArea.NURSE;
        }
        var appointmentDateTime = GetAppointmentDateTimeFromUser();
        var price = CalculatePrice(type, area);

        var availableDoctors = FindAvailableDoctors(area, appointmentDateTime);
        if (!availableDoctors.Any())
        {
            message = "No doctors available for the selected date and time";
            return false;
        }
        var doctorchoosed = SelecDoctor(availableDoctors);

        var appointmentDto = new AppointmentDto
        {
            DoctorId = doctorchoosed.id,
            Price = price,
            Name = $"{type} Appointment in {area}",
            CustomerId = customerUser.id,
            Type = type,
            Area = area,
            AppointmentDateTime = appointmentDateTime,
            Description = $"Appointment with {type} in {area} area, scheduled for {appointmentDateTime} with {doctorchoosed.PersonalInfo.Name}. Price: {price}",

        };

        var confirmation = ConfirmAppointment(appointmentDto, doctorchoosed, customerUser);

        if (!confirmation)
        {
            message = "Appointment canceled";
            return false;
        }

        var success = _appointmentService.ScheduleMedicalAppointment(appointmentDto);
        return success;
    }
    private bool ConfirmAppointment(AppointmentDto appointmentDto, Doctor doctor, User customer)
    {
        NewMethod(appointmentDto, doctor, customer);
        Console.Write("> Input: ");
        string input = Console.ReadLine();
        int option;
        while (!int.TryParse(input, out option) || option < 1 || option > 2)
        {
            NewMethod(appointmentDto, doctor, customer);
            Console.WriteLine("> Please type a valid option: ");
            input = Console.ReadLine();
        }
        return option == 1;

        static void NewMethod(AppointmentDto appointmentDto, Doctor doctor, User customer)
        {
            Console.Clear();
            int windowWidth = Console.WindowWidth;
            string border = new('=', windowWidth - 1);
            RenderTitle("Appointment Confirmation");
            Console.WriteLine("=> Appointment Details");
            Console.WriteLine();
            Console.WriteLine($"Doctor: {doctor.PersonalInfo.Name}");
            Console.WriteLine();
            Console.WriteLine($"Price: {appointmentDto.Price}");
            Console.WriteLine();
            Console.WriteLine($"Name: {appointmentDto.Name}");
            Console.WriteLine();
            Console.WriteLine($"Customer: {customer.PersonalInfo.Name}");
            Console.WriteLine();
            Console.WriteLine($"Type: {appointmentDto.Type}");
            Console.WriteLine();
            Console.WriteLine($"Area: {appointmentDto.Area}");
            Console.WriteLine();
            Console.WriteLine($"Description: {appointmentDto.Description}");
            Console.WriteLine();
            Console.WriteLine($"Appointment Date: {appointmentDto.AppointmentDateTime}");
            Console.WriteLine();
            Console.WriteLine("=> Confirm Appointment?");
            Console.WriteLine();
            Console.WriteLine("[1] Yes");
            Console.WriteLine();
            Console.WriteLine("[2] No");
            Console.WriteLine();
            Console.WriteLine(border);
        }
    }
    private Doctor SelecDoctor(List<Doctor> availableDoctors)
    {
        ShowAvailableDoctorsToCustomer(availableDoctors);
        string input = Console.ReadLine();
        int selectedIndex;
        while (!int.TryParse(input, out selectedIndex) || selectedIndex - 1 < 0 || selectedIndex - 1 >= availableDoctors.Count)
        {
            ShowAvailableDoctorsToCustomer(availableDoctors, "Please type a valid option");
            input = Console.ReadLine();
        }
        selectedIndex--;
        return availableDoctors[selectedIndex];
    }
    private void ShowAvailableDoctorsToCustomer(List<Doctor> availableDoctors, string Input = "Input")
    {
        RenderTitle("Available Doctors");
        int windowWidth = Console.WindowWidth;
        string border = new('=', windowWidth - 1);
        Console.WriteLine("=> Choose a Doctor");
        Console.WriteLine();
        for (int i = 0; i < availableDoctors.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {availableDoctors[i].PersonalInfo.Name}");
            Console.WriteLine();
        }
        Console.WriteLine(border);
        Console.Write($"> {Input}: ");
    }
    private List<Doctor> FindAvailableDoctors(MedicalServiceArea area, DateTime appointmentDateTime)
    {
        var doctorsInArea = _userRepository.GetDoctorsByMedicalServiceArea(area);

        var availableDoctors = new List<Doctor>();

        foreach (var doctor in doctorsInArea)
        {
            if (!IsDoctorBusy(doctor, appointmentDateTime))
            {
                availableDoctors.Add(doctor);
            }
        }

        return availableDoctors;
    }

    private bool IsDoctorBusy(Doctor doctor, DateTime appointmentDateTime)
    {
        var appointments = _appointmentRepository.GetDoctorAppointments(doctor.id, appointmentDateTime.Date);

        // Verificar se há algum conflito de horário
        foreach (var appointment in appointments)
        {
            if (appointment.AppointmentDate == appointmentDateTime)
            {
                return true;
            }
        }

        return false;
    }
    private float CalculatePrice(MedicalServiceType type, MedicalServiceArea area)
    {
        float price = 0;
        switch (type)
        {
            case MedicalServiceType.Consultation:
                price = 100;
                break;
            case MedicalServiceType.Exam:
                price = 50;
                break;
            case MedicalServiceType.Surgery:
                price = 500;
                break;
        }
        return area switch
        {
            MedicalServiceArea.Acupuncture => price * 1.2f,
            MedicalServiceArea.Allergy => price * 1.2f,
            MedicalServiceArea.Anesthesiology => price * 3.2f,
            MedicalServiceArea.Cardiology => price * 2.2f,
            MedicalServiceArea.Dermatology => price * 2.2f,
            MedicalServiceArea.Endocrinology => price * 1.2f,
            MedicalServiceArea.Gastroenterology => price * 2.2f,
            MedicalServiceArea.GeneralPractice => price * 1.2f,
            MedicalServiceArea.Hematology => price * 1.2f,
            MedicalServiceArea.InfectiousDisease => price * 3.2f,
            MedicalServiceArea.InternalMedicine => price * 3.2f,
            MedicalServiceArea.Nephrology => price * 4.2f,
            MedicalServiceArea.Neurology => price * 5.2f,
            MedicalServiceArea.ObstetricsAndGynecology => price * 1.2f,
            MedicalServiceArea.Oncology => price * 1.2f,
            MedicalServiceArea.Ophthalmology => price * 2.2f,
            MedicalServiceArea.Orthopedics => price * 1.2f,
            MedicalServiceArea.Otolaryngology => price * 1.2f,
            MedicalServiceArea.Pediatrics => price * 2.2f,
            MedicalServiceArea.PhysicalMedicineAndRehabilitation => price * 1.2f,
            MedicalServiceArea.Psychiatry => price * 2.2f,
            MedicalServiceArea.Urology => price * 1.2f,
            _ => price * 1.5f
        };
    }
    public static DateTime GetAppointmentDateTimeFromUser()
    {
        DateTime appointmentDateTime;
        string dateInput, timeInput;
        NewMethod(out dateInput, out timeInput);
        DateTime date;
        DateTime time;
        while (!(DateTime.TryParseExact(dateInput, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) &&
                DateTime.TryParseExact(timeInput, "HH", CultureInfo.InvariantCulture, DateTimeStyles.None, out time)))
        {
            NewMethod(out dateInput, out timeInput, "a valid");
        }
        appointmentDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, 0, 0);
        return appointmentDateTime;

        static void NewMethod(out string dateInput, out string timeInput, string the = "the")
        {
            int windowWidth = Console.WindowWidth;
            string border = new('=', windowWidth - 1);
            RenderTitle("Schedule an appointment");
            Console.Write($"=> Enter {the} appointment date (yyyy-MM-dd): ");
            Console.WriteLine();
            Console.WriteLine(border);
            dateInput = Console.ReadLine();

            RenderTitle("Schedule an appointment");
            Console.Write($"=> Enter {the} appointment time (HH): ");
            Console.WriteLine();
            Console.WriteLine(border);
            timeInput = Console.ReadLine();
        }
    }
    private MedicalServiceType GetValidMedicalSerivetype()
    {
        RenderMedicalType("Medical Services");
        string input = Console.ReadLine();
        int option;
        while (!int.TryParse(input, out option) || !Enum.IsDefined(typeof(MedicalServiceType), option - 1))
        {
            RenderMedicalType("Medical Services", "Please type a valid option");
            input = Console.ReadLine();
        }
        option--;
        Enum.TryParse<MedicalServiceType>(option.ToString(), out MedicalServiceType medicalServiceType);
        return medicalServiceType;
    }
    private MedicalServiceArea GetValidMedicalSeriveArea()
    {
        RenderMedicalArea("Medical Services");
        string input = Console.ReadLine();
        int option;
        while (!int.TryParse(input, out option) || !Enum.IsDefined(typeof(MedicalServiceArea), option))
        {
            RenderMedicalArea("Medical Services", "Please type a valid option");
            input = Console.ReadLine();
        }

        Enum.TryParse<MedicalServiceArea>(option.ToString(), out MedicalServiceArea medicalServiceArea);
        return medicalServiceArea;
    }
    private void RenderMedicalArea(string _title, string input = "Input")
    {
        RenderTitle(_title);
        int windowWidth = Console.WindowWidth;
        string border = new('=', windowWidth - 1);
        var values = Enum.GetValues(typeof(MedicalServiceArea));
        Console.WriteLine("Choose a Medical Service Area");
        Console.WriteLine();
        foreach (var value in values)
        {
            // Pula a impressão do valor no índice 0
            if (value.Equals(MedicalServiceArea.NURSE))
            {
                continue;
            }

            Console.WriteLine($"[{(int)value}] {value}");
            Console.WriteLine();
        }
        Console.WriteLine(border);
        Console.Write("> " + input + ": ");
    }
    private void RenderMedicalType(string _title, string input = "Input")
    {
        RenderTitle(_title);
        int windowWidth = Console.WindowWidth;
        string border = new('=', windowWidth - 1);
        var values = Enum.GetValues(typeof(MedicalServiceType));
        Console.WriteLine("Choose a Medical Service Type");
        Console.WriteLine();
        foreach (var value in values)
        {
            Console.WriteLine($"[{((int)value) + 1}] {value}");
            Console.WriteLine();
        }
        Console.WriteLine(border);
        Console.Write("> " + input + ": ");
    }
    private static void RenderTitle(string _title)
    {
        Console.Clear();
        int windowWidth = Console.WindowWidth;
        string border = new('=', windowWidth - 1);
        Console.WriteLine(border);
        Console.WriteLine("|| " + _title);
        Console.WriteLine(border);
        Console.WriteLine();
    }
}