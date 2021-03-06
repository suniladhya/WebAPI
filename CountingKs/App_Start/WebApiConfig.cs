﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace CountingKs
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "FoodListApi",
                routeTemplate: "api/nutrition/foods",
                defaults: new { controller = "foods" }
            );
            config.Routes.MapHttpRoute(
                name: "FoodApi",
                routeTemplate: "api/nutrition/foods/{foodId}",
                defaults: new { controller = "foods" },
                constraints: new { foodId = @"\d+" }
            );
            config.Routes.MapHttpRoute(
                name: "Measures",
                routeTemplate: "api/nutrition/foods/{foodId}/measures/{id}",
                defaults: new { controller = "measures", id = RouteParameter.Optional },
                constraints: new { foodId = @"\d+",id = @"\d+" }
            );
            config.Routes.MapHttpRoute(
                name: "DiariesAPI",
                routeTemplate: "api/user/diaries/{diaryId}",
                defaults: new { controller = "diaries", diaryId = RouteParameter.Optional },
                //constraints: new { foodId = @"\d+", id = @"\d+" }
            );
            
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}