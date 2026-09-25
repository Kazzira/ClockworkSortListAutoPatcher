using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.WPF.Reflection.Attributes;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using Mutagen.Bethesda.Plugins;

namespace ClockworkSortListAutoPatcher;


public class Settings
{
    public static Lazy<Settings> Instance  = null!;


    [SettingName("Meat Kitchen Keywords")]
    public List<FormLink<IKeywordGetter>> MeatKitchenKeywords { get; set; } = [
    ];

    [SettingName("Fruits and Vegetables Kitchen Keywords")]
    public List<FormLink<IKeywordGetter>> FruitsAndVegetablesKitchenKeywords { get; set; } = [

    ];

    [SettingName("Prepared Food Kitchen Keywords")]
    public List<FormLink<IKeywordGetter>> PreparedFoodKitchenKeywords { get; set; } = [

    ];

    [SettingName("Seasoning Kitchen Keywords")]
    public List<FormLink<IKeywordGetter>> SeasoningKitchenKeywords { get; set; } = [

    ];

    [SettingName("Drink Kitchen Keywords")]
    public List<FormLink<IKeywordGetter>> DrinkKitchenKeywords { get; set; } = [

    ];

    [SettingName("Cheese Kitchen Keywords")]
    public List<FormLink<IKeywordGetter>> CheeseKitchenKeywords { get; set; } = [

    ];

    [SettingName("Kitchen Keywords")]
    public List<FormLink<IKeywordGetter>> KitchenKeywords { get; set; } = [
        Skyrim.Keyword.VendorItemFood,
        Skyrim.Keyword.VendorItemFoodRaw
    ];

    [SettingName("Gem Work Room Keywords")]
    public List<FormLink<IKeywordGetter>> GemWorkRoomKeywords { get; set; } = [
        Skyrim.Keyword.VendorItemGem
    ];

    [SettingName("Ingot Work Room Keywords")]
    public List<FormLink<IKeywordGetter>> IngotWorkRoomKeywords { get; set; } = [
    ];

    [SettingName("Ore Work Room Keywords")]
    public List<FormLink<IKeywordGetter>> OreWorkRoomKeywords { get; set; } = [

    ];

    [SettingName("Hide Work Room Keywords")]
    public List<FormLink<IKeywordGetter>> HideWorkRoomKeywords { get; set; } = [
        Skyrim.Keyword.VendorItemAnimalHide
    ];

    [SettingName("Smithing Mats Work Room Keywords")]
    public List<FormLink<IKeywordGetter>> SmithingMatsWorkRoomKeywords { get; set; } = [
    ];

    [SettingName("Work Room Keywords")]
    public List<FormLink<IKeywordGetter>> WorkRoomKeywords { get; set; } = [
        Skyrim.Keyword.VendorItemOreIngot,
        Skyrim.Keyword.VendorItemFireword,
        Skyrim.Keyword.VendorItemAnimalPart,
    ];
}