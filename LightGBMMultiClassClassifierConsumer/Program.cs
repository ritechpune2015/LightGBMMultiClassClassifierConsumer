using LightGBMMultiClassClassifierConsumer.Dtos;
using Microsoft.Extensions.ML;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
string modelPath = Path.Combine(AppContext.BaseDirectory, "AIModels", "HelpDeskLightGbmModel.zip");

if (!File.Exists(modelPath))
{
    throw new FileNotFoundException(
        "Trained salary model was not found. " +
        "Train the model and copy it into the API Models folder.",
        modelPath);
}


builder.Services.AddPredictionEnginePool<PredictionRequest,
        ModelOutput>().FromFile(modelName: "HelpDesk", filePath: modelPath, watchForChanges: false);


var app = builder.Build();
app.MapDefaultControllerRoute();
app.Run();
