using Mine.Commerce.Infrastructure.Scheduler.Config;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Mine.Commerce.Infrastructure.Scheduler.Extensions
{
    public static class SchedulerExtensions
    {
        public static SchedulerBuilder AddScheduler(this IServiceCollection services)
        {
            return new SchedulerBuilder(services, new Dictionary<Type, Func<SchedulerConfig, TaskConfig>>());
        }
    }
}
