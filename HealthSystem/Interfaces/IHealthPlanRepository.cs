public interface IHealthPlanRepository
{
    //Retorna um plano de saúde do repositório
    //id: id do plano de saúde
    HealthPlan GetById(int id);

    //Retorna todos os planos de saúde do repositório
    IEnumerable<HealthPlan> GetAll();
}