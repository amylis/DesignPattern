﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SingletonPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public WeatherForecast Get()
        {
            // 实例化一个对象实例
            //WeatherForecast weather = WeatherForecast.GetInstance();

            // 多线程去调用
            for (int i = 0; i < 3; i++)
            {
                var th = new Thread(
                new ParameterizedThreadStart((state) =>
                {
                    //WeatherForecast.GetInstance();
                    
                    // 此刻的心情
                    Feeling feeling = new Feeling();
                    Console.WriteLine(feeling.Date);
                })
                );
                th.Start(i);
            }
            return null;
        }
    }
}
