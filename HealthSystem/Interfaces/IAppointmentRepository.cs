public interface IAppointmentRepository
{
    //Adiciona uma consulta médica ao repositório
    //medicalAppointment: consulta médica a ser adicionada
    void Add(MedicalAppointment medicalAppointment);

    //Retorna uma lista de consultas médicas agendadas para um médico em uma data específica
    //doctorid: id do médico
    //appointmentDateTime: data da consulta
    List<MedicalAppointment> GetDoctorAppointments(int doctorid, DateTime appointmentDateTime);

    //Retorna uma lista de consultas médicas agendadas para um paciente
    //userid: id do paciente
    List<MedicalAppointment> GetAppointmentsByUserId(int userid);

    //Retorna uma lista de consultas médicas agendadas para um médico
    //doctorid: id do médico
    List<MedicalAppointment> GetAppointmentsByDoctorId(int doctorid);
}