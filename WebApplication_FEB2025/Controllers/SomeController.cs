using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebApplication_FEB2025.Controllers
{
    public class SomeController : Controller
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew(); 
            stopwatch.Start();

            Thread.Sleep(1000);
            Console.WriteLine( "Conexion a la BD terminada!" );

            Thread.Sleep(1000);
            Console.WriteLine("Envio de mail Terminado !!");

            Console.WriteLine("Todo termino.");

            stopwatch.Stop();
            return Ok("termino el proceso sincrono a los : "+ stopwatch.Elapsed + " seg");
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            var task1 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine( "Conexion a BD terminada");



            });

            task1.Start();
            Console.Out.WriteLineAsync( " Hago otra cosa"  );

            await task1;

            Console.Out.WriteLineAsync(" Todo termino");

            return Ok();
        }


        [HttpGet("async/int")]
        public async Task<IActionResult> GetAsyncInt()
        {
            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a BD terminada");
                return (8);


            });

            task1.Start();
            Console.Out.WriteLineAsync(" Hago otra cosa");

           var result = await task1;

            Console.Out.WriteLineAsync(" Todo termino");

            return Ok(result);
        }

        [HttpGet("asyncTwoTasks")]
        public async Task<IActionResult> GetAsyncTwoTasks()
        {
            Console.WriteLine("**********inicio ************");
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Conexion a BD Terminada");
                return (2);


            });
            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Envio Mail Terminado");
                return (4);


            });

            task1.Start();
            task2.Start();
            Console.Out.WriteLineAsync(" Hago otra cosa");

            var result1 = await task1;
            var result2 = await task2;

            Console.Out.WriteLineAsync(" Todo termino");
            stopwatch.Stop();

            return Ok(result1 + " " + result2 + " " + stopwatch.Elapsed);
        }
    }
}
