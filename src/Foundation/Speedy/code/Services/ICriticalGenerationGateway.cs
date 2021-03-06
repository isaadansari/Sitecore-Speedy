﻿namespace Sitecore.Foundation.Speedy.Services
{
    public interface ICriticalGenerationGateway
    {
        string GenerateCritical(string url, string width = "1800", string height = "1200", bool fontReplace = false);
    }
}