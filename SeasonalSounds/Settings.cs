using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace SeasonalSounds
{
    public class Settings
    {
        [SettingName("Vanilla permanently frozen regions EditorID substrings")]
        [Tooltip("Regions with the following EditorID substrings will be considered permanently frozen in vanilla, but unfrozen in modded Skyrim, typically with Seasonal Landscapes - Unfrozen. Anything else will be considered as permanently unfrozen in vanilla. If Seasonal Landscapes - Unfrozen compatibility mode enabled, existing sounds that pass name checks will play during spring, autumn and winter. Summer sounds will be distributed from the template regions.")]
        public List<string> VanillaFrozenEditorIdSubstrings = new();

        [SettingName("Ignored regions")]
        [Tooltip("These regions will be ignored by patcher altogether.")]
        public List<string> IgnoredRegionEditorIdSubstrings = new();

        [SettingName("Sound EditorID substrings to consider")]
        [Tooltip("Only sounds with the following EditorID substrings will be taken into consideration (they will be added for summer to unfrozen regions if Seasonal Landscapes - Unfrozen compatibility mode is enabled and filtered out for winter for anything else).")]
        public List<string> ConsiderableSoundsEditorIdSubstrings = new();

        [SettingName("Sound EditorID substrings to ignore")]
        [Tooltip("These sounds will be ignored by patcher altogether. This has a higher priority over processible sounds list, so it can be used to narrow down the selection of sounds.")]
        public List<string> IgnoredSoundsEditorIdSubstrings = new();

        [SettingName("Frozen wilderness template region EditorID")]
        [Tooltip("The sounds of the specified region will be distributed to the wilderness regions that are frozen only during winter using Seasons of Skyrim (permanently unfrozen in vanilla) and will play only during winter.")]
        public string TemplateWildernessRegionEditorIdForPossiblyFrozenRegions = string.Empty;

        [SettingName("Frozen city template region EditorID")]
        [Tooltip("The sounds of the specified region will be distributed to the city regions that are frozen only during winter using Seasons of Skyrim (permanently unfrozen in vanilla) and will play only during winter.")]
        public string TemplateCityRegionEditorIdForPossiblyFrozenRegions = string.Empty;

        [SettingName("Seasonal Landscapes - Unfrozen Mode")]
        public SeasonalLandscapesUnfrozen SeasonalLandscapesUnfrozenModeSettings { get; set; } = new();

        [SettingName("City Recognition")]
        public CityRecognition CityRecognitionSettings { get; set; } = new();

        [SettingName("Seasons of Skyrim SKSE Settings")]
        public SeasonsOfSkyrim SeasonsOfSkyrimSettings { get; set; } = new();

        [SettingName("Remove vanilla cricket sound in Windhelm")]
        [Tooltip("Vanilla Skyrim bizarrely plays cricket sounds during night in fully frozen Windhelm. If you don't want this, enable this option.")]
        public bool RemoveCricketSoundInWindhelm;

        [SettingName("Verbose logging")]
        [Tooltip("Enables verbose logging.")]
        public bool VerboseLogging;
    }

    public class SeasonalLandscapesUnfrozen
    {
        [SettingName("Enable Seasonal Landscapes - Unfrozen compatibility mode")]
        [Tooltip("If enabled, summer conditional sounds will be distributed to the regions that are usually permanently frozen.")]
        public bool EnableSeasonalLandscapesUnfrozenCompatibilityMode;

        [SettingName("Unfrozen wilderness template region EditorID")]
        [Tooltip("Only relevant in Seasonal Landscapes - Unfrozen compatibility mode. The sounds of the specified region will be distributed to the wilderness regions that are defined in the list above and will play only during summer.")]
        public string TemplateWildernessRegionEditorIdForUnfrozenRegions = string.Empty;

        [SettingName("Unfrozen city template region EditorID")]
        [Tooltip("Only relevant in Seasonal Landscapes - Unfrozen compatibility mode. The sounds of the specified region will be distributed to the city regions that are defined in the list above and will play only during summer.")]
        public string TemplateCityRegionEditorIdForUnfrozenRegions = string.Empty;
    }

    public class CityRecognition
    {
        [SettingName("City regions EditorID substrings")]
        [Tooltip("Regions with the following EditorID substrings will be considered as city regions. For these regions generic city sounds from the template city will be distributed.")]
        public List<string> CityEditorIdSubstrings = new();

        [SettingName("City keywords EditorID substrings")]
        [Tooltip("If region worldspace location has one the defined keywords, the region will be recognized as city region.")]
        public List<string> CityKeywordsEditorIdSubstrings = new();

        [SettingName("Use worldspace parenthood as city marker")]
        [Tooltip("If enabled, regions with the worldspace that is having parent worldspace will be considered as a city region. May be unrealiable, but should save the trouble of having to put every city to the city list.")]
        public bool UseWorldspaceParenthoodAsCityMarker;
    }

    public class SeasonsOfSkyrim
    {
        [SettingName("Use Seasons of Skyrim worldspace whitelist")]
        [Tooltip("If enabled and Seasons of Skyrim's configuration file is present (po3_SeasonsOfSkyrim.ini), will only patch regions that belong to the worldspaces defined in the \"Worldspaces\" setting. Having a worldspace in any of the \"Winter\", \"Spring\", \"Summer\", \"Autumn\" will enable its regions for patching.")]
        public bool UseSeasonsOfSkyrimWorldspaceWhitelist;

        [SettingName("Use Seasons of Skyrim month to season map")]
        [Tooltip("If enabled, will use month to season mapping from Seasons of Skyrim if its configuration file is present (po3_SeasonsOfSkyrim.ini, General section).")]
        public bool UseSeasonsOfSkyrimMonthToSeasonMap;
    }
}