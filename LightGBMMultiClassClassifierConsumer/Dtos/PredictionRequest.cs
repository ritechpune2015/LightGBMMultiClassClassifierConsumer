namespace LightGBMMultiClassClassifierConsumer.Dtos
{
    public class PredictionRequest
    {
        public string TicketText { get; set; } = "";
        public string Category { get; set; } = "";
    }
}
