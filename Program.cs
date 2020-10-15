using System;
using System.Threading;
using System.Threading.Tasks;

namespace DemoLive.ProgramacaoAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex();
            ExAsync();
            //ExAsyncNaoLike();

            Console.ReadLine();
        }

        private static void Ex()
        {
            Console.WriteLine("*** - Iniciando a Live! - ***");
            Console.WriteLine("João, você pode ver a live?!");
            var joao = JoaoDeixaLike();

            Console.WriteLine("Maria, você pode ver a live?!");
            var maria = MariaDeixaLike();
        }
        private async  static void ExAsync()
        {
            //Asincrona
            Console.WriteLine("*** - Iniciando a Live! - ***");

            Console.WriteLine("João, você pode ver a live?!");
            var joaoAsync = JoaoDeixaLikeAsync();

            Console.WriteLine("Maria, você pode ver a live?!");
            var mariaAsync = MariaDeixaLikeAsync();

            await joaoAsync;
            await mariaAsync;
        }

        private async static void ExAsyncNaoLike()
        {
            //Asincrona
            Console.WriteLine("*** - Iniciando a Live! - ***");

            Console.WriteLine("João, você pode ver a live?!");
            var joaoAsync = JoaoDeixaLikeAsync();

            Console.WriteLine("Maria, você pode ver a live?!");
            var mariaAsync = MariaDeixaLikeAsync();

            var wait = Task.Delay(9000);

            var finalizouPrimeiro = await Task.WhenAny(joaoAsync, wait);

            if( finalizouPrimeiro == wait)
            {
                Console.WriteLine("João, você está aí?????");
            }
            else
            {
                await joaoAsync;
                await mariaAsync;
            }
           
        }


        private static string JoaoDeixaLike()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("João começa a assistir a live");
            Thread.Sleep(2000);
            Console.WriteLine("João gostou da live!");
            Thread.Sleep(2000);
            Console.WriteLine("João deixa o like!");
            Console.ResetColor();

            return "Deixou Like";
        }

        private static string MariaDeixaLike()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Maria começa a assistir a live");
            Thread.Sleep(2000);
            Console.WriteLine("Maria gostou da live!");
            Thread.Sleep(2000);
            Console.WriteLine("Maria deixa o like!");
            Console.ResetColor();

            return "Deixou Like";
        }

        private static async Task MariaDeixaLikeAsync()
        {
            Console.WriteLine("Maria começa a assistir a live");
            await Task.Delay(2000);
            Console.WriteLine("Maria gostou da live!");
            await Task.Delay(3000);
            Console.WriteLine("Maria deixa o like!");
        }

        private static async Task JoaoDeixaLikeAsync()
        {
            Console.WriteLine("João começa a assistir a live");
            await Task.Delay(9000);
            Console.WriteLine("João gostou da live!");
            await Task.Delay(3000);
            Console.WriteLine("João deixa o like!");
        }
    }
}
