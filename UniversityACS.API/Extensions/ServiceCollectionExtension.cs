using UniversityACS.Application.Services.ApplicationUserServices;
using UniversityACS.Application.Services.DepartmentServices;
using UniversityACS.Application.Services.DisciplineServices;
using UniversityACS.Application.Services.ScientificAndPedagogicalActivityServices;
using UniversityACS.Application.Services.SyllabusServices;
using UniversityACS.Application.Services.TraineeshipServices;

namespace UniversityACS.API.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationUserService, ApplicationUserService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IDisciplineService, DisciplineService>();
        services.AddScoped<IScientificAndPedagogicalActivityService, ScientificAndPedagogicalActivityService>();
        services.AddScoped<ISyllabusService, SyllabusService>();
        services.AddScoped<ITraineeshipService, TraineeshipService>();

        return services;
    }
}