
using Microsoft.Extensions.DependencyInjection;
using Todo.Data.Interface;
using Todo.Data;
using Todo.Service.Interface;
using Todo.Service;

namespace Todo.Helper
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
