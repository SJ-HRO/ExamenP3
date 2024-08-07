﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using SQLite;

namespace ExamenP3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<Services.ChuckNorrisService>();
            builder.Services.AddSingleton<ViewModels.MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<JokesPage>();
            builder.Services.AddSingleton<FavoriteCharacterPage>();
            return builder.Build();
        }
    }
}
