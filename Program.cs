using System;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace MLConsoleApp
{
    public class ModelInput
    {
        [ColumnName("col0"), LoadColumn(0)]
        public string Col0 { get; set; }

        // mlnet v0.15.1 second column info, works fine
        // [ColumnName("Label"), LoadColumn(1)]
        // public bool Label { get; set; }

        // mlnet v16.2 second columng info, fails to load
        [ColumnName("col1"), LoadColumn(1)]
        public string Col1 { get; set; }
    }

    public class ModelOutput
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }
        public float Probability { get; set; }
        public float Score { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MLContext mlContext = new MLContext();
            DataViewSchema predictionPipelineSchema;
            // v0.15.1 generated model, loads fine
            // ITransformer predictionPipeline = mlContext.Model.Load("models/MLModelv0.15.zip", out predictionPipelineSchema);
            ITransformer predictionPipeline = mlContext.Model.Load("models/MLModelv16.2.zip", out predictionPipelineSchema);

            PredictionEngine<ModelInput, ModelOutput> predictionEngine = 
                mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(predictionPipeline);


            ModelInput input = new ModelInput{ Col0 = "Meh, food was cold." };

            var result = predictionEngine.Predict(input);

            Console.WriteLine($"=============== Single Prediction  ===============");
            Console.WriteLine($"Text: {input.Col0} | Prediction: {(Convert.ToBoolean(result.Prediction) ? "Positive" : "Negative")} review | Probability of being positive: {result.Probability} ");
            Console.WriteLine($"================End of Process.Hit any key to exit==================================");
            Console.ReadLine();

            Console.WriteLine("Goodbye World!");
        }
    }
}
