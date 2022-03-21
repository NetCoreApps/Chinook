using System;
using ServiceStack;
using Chinook.ServiceModel;

namespace Chinook.ServiceInterface;

public class MyServices : Service
{
    public object Any(Hello request)
    {
        return new HelloResponse { Result = $"Hello, {request.Name}!" };
    }
}