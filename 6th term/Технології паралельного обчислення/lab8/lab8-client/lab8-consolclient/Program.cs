using System.Diagnostics;
using Newtonsoft.Json;

namespace lab8_consolclient

{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            const int SIZE = 2700;

            #region Call WITHOUT matrices in body
            var stopwatch = Stopwatch.StartNew();
            await Without(SIZE);
            stopwatch.Stop();
            Console.WriteLine($"Execution time without matrices in body: {stopwatch.ElapsedMilliseconds} мс");
            #endregion

            #region Call WITH matrices in body
            stopwatch = Stopwatch.StartNew();
            await With(SIZE);
            stopwatch.Stop();
            Console.WriteLine($"Execution time with matrices in body: {stopwatch.ElapsedMilliseconds} мс");
            #endregion
        }

        public static async Task Without(int size)
        {
            var httpClient = new HttpClient();
            var model = new
            {
                size = size
            }; 
            var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:7254/test/without", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                int[,] matrix = JsonConvert.DeserializeObject<int[,]>(responseContent);
                Console.WriteLine($"Success, a {matrix.GetLength(0)}x{matrix.GetLength(1)} matrix is obtained");
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
        }

        public static async Task With(int size)
        {
            var httpClient = new HttpClient();
            var model = new TestInputModal
            {
                MatrixA = JsonConvert.SerializeObject(GetRandomMatrix(size)),
                MatrixB = JsonConvert.SerializeObject(GetRandomMatrix(size))
            };
            var content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://localhost:7254/test/with", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                int[,] matrix = JsonConvert.DeserializeObject<int[,]>(responseContent);
                Console.WriteLine($"Success, a {matrix.GetLength(0)}x{matrix.GetLength(1)} matrix is obtained");
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
        }

        private static int[,] GetRandomMatrix(int n)
        {
            var resultMatrix = new int[n, n];
            Random random = new Random();
            for (int i = 0; i < resultMatrix.GetLength(0); i++)
                for (int j = 0; j < resultMatrix.GetLength(1); j++)
                    resultMatrix[i, j] = random.Next(1, 10);

            return resultMatrix;
        }
    }
}