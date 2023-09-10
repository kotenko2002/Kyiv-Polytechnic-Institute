using lab8.Entities;
using lab8.Stripe;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace lab8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpPost("without")]
        public async Task<string> GetTestMatrix(TestSizaModel model)
        {
            int[,] matrixA = GetRandomMatrix(model.Size);
            int[,] matrixB = GetRandomMatrix(model.Size);

            int[,] resultMatrix = StripeAlgorithm.Multiply(matrixA, matrixB, 20);
            string responseJson = JsonConvert.SerializeObject(resultMatrix);

            return responseJson;
        }

        [HttpPost("with")]
        public async Task<string> PostTestMatrix(TestInputModel model)
        {
            int[,] matrixA = JsonConvert.DeserializeObject<int[,]>(model.MatrixA);
            int[,] matrixB = JsonConvert.DeserializeObject<int[,]>(model.MatrixB);

            int[,] resultMatrix = StripeAlgorithm.Multiply(matrixA, matrixB, 20);
            string responseJson = JsonConvert.SerializeObject(resultMatrix);

            return responseJson;
        }

        private int[,] GetRandomMatrix(int n)
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
