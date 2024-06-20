public class AppointmentDto
{
    public int CustomerId { get; set; } //
    public int DoctorId { get; set; }
    public DateTime AppointmentDateTime { get; set; } //
    public string? Name { get; set; }
    public float Price { get; set; }
    public string? Description { get; set; } //
    public MedicalServiceType Type { get; set; } //
    public MedicalServiceArea Area { get; set; } //
}
