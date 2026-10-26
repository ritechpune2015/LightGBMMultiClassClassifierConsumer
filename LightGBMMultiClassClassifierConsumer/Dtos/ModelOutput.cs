namespace LightGBMMultiClassClassifierConsumer.Dtos
{
    public class ModelOutput
    {
        public string PredictedLabel { get; set; } = "";
        public float[] Score { get; set; } = [];
    }
}
