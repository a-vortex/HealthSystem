using System;
using HealthSystem.Models.Users;

public class MedicalAppointment
{
    public int AppointmentId { get; set; } // Primary Key
    public DateTime AppointmentDate { get; set; }
    public MedicalService medicalService { get; set; }
    public int PatientId { get; set; } // Foreign Key
    public int DoctorId { get; set; } // Foreign Key
    public Customer? Customer { get; set; }  // Navegation Property
    public Doctor? Doctor { get; set; }  // Navegation Property

    public MedicalAppointment() => medicalService = new MedicalService();

    public MedicalAppointment(DateTime appointmentDate, Customer patient, Doctor doctor,
    string name, float price, string description, MedicalServiceType medicalServiceType, MedicalServiceArea medicalServiceArea)
    {
        AppointmentDate = appointmentDate;
        Customer = patient;
        Doctor = doctor;
        PatientId = patient.id;
        DoctorId = doctor.id;
        medicalService = new MedicalAppointment.MedicalService
        {
            Name = name,
            Price = price,
            Description = description,
            Type = medicalServiceType!,
            Area = medicalServiceArea!
        };
    }

    public class MedicalService
    {
        public string? Name { get; set; }
        public float Price { get; set; }
        public string? Description { get; set; }
        public MedicalServiceType Type { get; set; }
        public MedicalServiceArea Area { get; set; }
    }
}
