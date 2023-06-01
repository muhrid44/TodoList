using UpscaleTest.Repository;
using UpscaleTest.Service;

namespace UpscaleTest.Helper
{
    public static class DependencyInjectionRegistrationClass
    {
        public static void Registration(IServiceCollection service)
        {
            service.AddScoped<IServiceTodo, ServiceTodo>();
            service.AddScoped<IRepositoryTodo, RepositoryTodo>();

        }
    }
}
