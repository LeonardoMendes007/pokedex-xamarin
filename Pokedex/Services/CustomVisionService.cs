using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Newtonsoft.Json;
using Pokedex.Extensions;
using Pokedex.Models;
using Pokedex.Models.Enums;
using Pokedex.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Shapes;

namespace Pokedex.Services
{
    public class CustomVisionService : IPredictService
    {
        private readonly HttpClient _httpClient;
        //PredictionKey para acessar a api do custom vision.
        private string _predictionKey = "";
        public CustomVisionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> IdentificarPokemon(string path)
        {
            var previsoes = await ObterPredicao(path);

            return ValidarPredicao(previsoes);
        }

        private string ValidarPredicao(List<Prediction> previsoes)
        {
            if (previsoes == null)
                return null;

            var maxProbability = previsoes.OrderByDescending(x => x.Probability).FirstOrDefault();

            if (maxProbability.Probability >= 0.7)
                return maxProbability.TagName;

            return null;
        }

        private async Task<List<Prediction>> ObterPredicao(string path)
        {
            try
            {
                var content = new MultipartFormDataContent();

                var fileContent = new ByteArrayContent(File.ReadAllBytes(path));
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                content.Add(fileContent);
                content.Headers.Add("Prediction-Key", _predictionKey);
                var response = await _httpClient.PostAsync(EndPoints.Prediction.GetDescription(), content);

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Payload>(await response.Content.ReadAsStringAsync()).predictions;

                }
                else
                {
                    throw new Exception(); 
                }
                return null;

            }catch(JsonException ex)
            {
                Console.WriteLine("Erro ao converter json." + ex);
                throw ex;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Erro ao obter predição." + ex);
                throw ex;
            }
           
        }
    }
}
