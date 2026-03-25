using System.Drawing;

//Colorful.Console.WriteAsciiAlternating("SSY", new Colorful.FrequencyBasedColorAlternator(3, Color.Yellow, Color.GreenYellow));
Serve.Run(RunOptions.Default.ConfigureBuilder(builder =>
{
    builder.WebHost.UseUrls(builder.Configuration["AppSettings:Urls"]);
}));
