using HealthSystem.Models.Users;
public interface IUserRepository
{
    //Retorna um usuário do repositório
    //email: Login do usuário
    User GetByLogin(string email);

    //Retorna um usuário do repositório
    //cpf: CPF do usuário
    User GetByCPF(string cpf);

    //Retorna um Doctor do repositório
    //coren: COREN do médico
    Doctor GetByCOREN(string coren);

    //Atualiza um usuário no repositório
    //Retorna true se o usuário foi atualizado com sucesso
    //user: Usuário a ser atualizado
    bool Update(User user);

    //Adiciona um usuário no repositório
    //user: Usuário a ser adicionado
    void Add(User user);

    //Retorna um paciente do repositório
    //customerId: Id do paciente
    Customer GetCustomerById(int customerId);

    //Retorna um médico do repositório
    //doctorId: Id do médico
    Doctor GetDoctorById(int doctorId);

    //Retorna uma lista de médicos do repositório
    //area: Área de atuação do médico
    List<Doctor> GetDoctorsByMedicalServiceArea(MedicalServiceArea area);
}
