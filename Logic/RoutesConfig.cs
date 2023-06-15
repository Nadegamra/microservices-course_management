﻿using Newtonsoft.Json;
using System.Text.Json.Nodes;

namespace CourseManagement.Logic
{
    public static class RoutesConfig
    {
        private static Dictionary<string, Route> _routes { get; set; } = new Dictionary<string, Route>();

        static RoutesConfig()
        {
            var stream = new FileStream("RouteConfig.json", FileMode.Open, FileAccess.Read);
            JsonArray jsonArray = JsonArray.Parse(stream).AsArray();

            foreach(var item in jsonArray)
            {
                Route route = JsonConvert.DeserializeObject<Route>(item.ToJsonString());
                route.Method = FromString(route.MethodStr);
                _routes.Add(route.Name, route);
            }
        }
        public static Route GetRoute(string name)
        {
            return _routes[name];
        }
        public static Method FromString(string str)
        {
            switch(str)
            {
                case "GET":
                    return Method.GET;
                case "POST": 
                    return Method.POST;
                case "PUT": 
                    return Method.PUT;
                case "DELETE": 
                    return Method.DELETE;
                case "PATCH": 
                    return Method.PATCH;
            }
            throw new Exception();
        }
    }
    public class Route
    {
        public string Name { get; set; }
        public Method? Method { get; set; }
        public string MethodStr { get; set; }
        public required string Path { get; set; }
        public required string[] Roles { get; set; }
        public bool IsPublic { get; set; }
    }

    public enum Method
    {
        GET,
        POST,
        PUT,
        DELETE,
        PATCH
    }


}
