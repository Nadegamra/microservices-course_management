using FastEndpoints;

namespace CourseManagement.Logic
{
    public class EndpointExtended<T1,T2,T3>: Endpoint<T1,T2,T3> where T1: notnull where T2: notnull where T3: notnull,IMapper
    {
        public void ConfigureEndpoint(string name)
        {
            Route route = RoutesConfig.GetRoute(name);

            switch (route.Method)
            {
                case Method.GET:
                    Get(route.Path);
                    break;
                case Method.POST:
                    Post(route.Path);
                    break;
                case Method.PUT:
                    Put(route.Path);
                    break;
                case Method.DELETE:
                    Delete(route.Path);
                    break;
                case Method.PATCH:
                    Patch(route.Path);
                    break;
            }
            
            if (route.IsPublic)
            {
                AllowAnonymous();
            }
            else
            {
                Roles(route.Roles);
            }
        }
    }

    public class EndpointExtended<T1, T2> : Endpoint<T1, T2> where T1 : notnull where T2 : notnull
    {
        public void ConfigureEndpoint(string name)
        {
            Route route = RoutesConfig.GetRoute(name);

            switch (route.Method)
            {
                case Method.GET:
                    Get(route.Path);
                    break;
                case Method.POST:
                    Post(route.Path);
                    break;
                case Method.PUT:
                    Put(route.Path);
                    break;
                case Method.DELETE:
                    Delete(route.Path);
                    break;
                case Method.PATCH:
                    Patch(route.Path);
                    break;
            }

            if (route.IsPublic)
            {
                AllowAnonymous();
            }
            else
            {
                Roles(route.Roles);
            }
        }
    }

    public class EndpointExtended<T1> : Endpoint<T1> where T1 : notnull
    {
        public void ConfigureEndpoint(string name)
        {
            Route route = RoutesConfig.GetRoute(name);

            switch (route.Method)
            {
                case Method.GET:
                    Get(route.Path);
                    break;
                case Method.POST:
                    Post(route.Path);
                    break;
                case Method.PUT:
                    Put(route.Path);
                    break;
                case Method.DELETE:
                    Delete(route.Path);
                    break;
                case Method.PATCH:
                    Patch(route.Path);
                    break;
            }

            if (route.IsPublic)
            {
                AllowAnonymous();
            }
            else
            {
                Roles(route.Roles);
            }
        }
    }
}
