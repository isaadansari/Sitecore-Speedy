﻿using Sitecore.Foundation.Speedy.Extensions;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Sitecore.Foundation.Speedy.Settings
{
    public static class SpeedyGenerationSettings
    {
        public static string GetCriticalApiEndpoint()
        {
            return GetGlobalSettingsItem().Fields[SpeedyConstants.GlobalSettings.Fields.EndpointUrl].Value;
        }

        public static string GetCriticalApiEndpointUsername()
        {
            return GetGlobalSettingsItem().Fields[SpeedyConstants.GlobalSettings.Fields.EndpointUsername].Value;
        }

        public static string GetCriticalApiEndpointPassword()
        {
            return GetGlobalSettingsItem().Fields[SpeedyConstants.GlobalSettings.Fields.EndpointPassword].Value;
        }

        public static bool ShouldRegenerateOnEachSave()
        {
            var item = GetGlobalSettingsItem();
            return item.Fields[SpeedyConstants.GlobalSettings.Fields.ShouldRegenerateOnEverySaveEvent].HasValue && item.Fields[SpeedyConstants.GlobalSettings.Fields.ShouldRegenerateOnEverySaveEvent].Value == "1";
        }

        public static bool IsPublicFacingEnvironment()
        {
            return bool.Parse(Sitecore.Configuration.Settings.GetSetting("Speedy.IsPublicFacingEnvironment"));
        }

        public static bool IsSpeedyEnabledForPage(this Item item)
        {
            return item.IsEnabled(SpeedyConstants.Fields.SpeedyEnabled);
        }

        public static bool IsOnePassCookieEnabled(this Item item)
        {
            return item.IsEnabled(SpeedyConstants.Fields.OnePassCookieEnabled);
        }

        public static bool IsCriticalStylesEnabledAndPossible(this Item item)
        {
            return item.IsEnabled(SpeedyConstants.Fields.EnableStylesheetLoadDefer) && item.Fields[SpeedyConstants.Fields.CriticalCss].HasValue;
        }

        public static bool IsCriticalJavascriptEnabledAndPossible(this Item item)
        {
            return item.IsEnabled(SpeedyConstants.Fields.EnableJavascriptLoadDefer);
        }

        private static Item GetGlobalSettingsItem()
        {
            return GetMaster().GetItem(SpeedyConstants.GlobalSettings.SpeedyGlobalSettingsId);
        }

        private static Database GetMaster()
        {
            return Sitecore.Configuration.Factory.GetDatabase("master");
        }

        public static string GetCookieExpiration()
        {
            return GetGlobalSettingsItem().Fields[SpeedyConstants.GlobalSettings.Fields.CookieExpiration].Value;
        }

        public static string GetDeferJSLoadForMilliseconds()
        {
            return GetGlobalSettingsItem().Fields[SpeedyConstants.GlobalSettings.Fields.DeferJSLoadForMilliseconds].Value;
        }

        public static string GetDeferCSSLoadForMilliseconds()
        {
            return GetGlobalSettingsItem().Fields[SpeedyConstants.GlobalSettings.Fields.DeferCSSLoadForMilliseconds].Value;
        }

        public static string GetDeferFallbackMilliseconds()
        {
            return GetGlobalSettingsItem().Fields[SpeedyConstants.GlobalSettings.Fields.DeferFallbackForMilliseconds].Value;
        }

        public static string GetFallbackExperienceSelector()
        {
            return Sitecore.Context.Item.Fields[SpeedyConstants.Fields.FallbackSelectorFieldName].Value;
        }
    }
}