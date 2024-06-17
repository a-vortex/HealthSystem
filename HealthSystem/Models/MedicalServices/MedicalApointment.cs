using System;
using HealthSystem.Models.Users;

public class MedicalAppointment
{
    public int AppointmentId { get; set; } //Primary Key
    public DateTime AppointmentDate { get; set; }
    public int PatientId { get; set; } //Foreign Key
    public int DoctorId { get; set; } //Foreign Key
    public int MedicalServiceId { get; set; } //Foreign Key

    public MedicalService? MedicalService { get; set; } // Navegation Property
    public Customer? Customer { get; set; }  // Navegation Property
    public Doctor? Doctor { get; set; }  // Navegation Property
    // These navegation properties are used to create the relationship between the entities
    // and are used by Entity Framework to create the database schema

    public MedicalAppointment() { }
    public MedicalAppointment(DateTime appointmentDate, Customer patient, Doctor doctor, MedicalService medicalService)
    {
        AppointmentDate = appointmentDate;
        MedicalService = medicalService;
        Customer = patient;
        Doctor = doctor;
        MedicalServiceId = medicalService.MedicalServiceId;
        PatientId = patient.id;
        DoctorId = doctor.id;
    }
}
