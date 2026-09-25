using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Records;

namespace ClockworkSortListAutoPatcher.Patchers;

using KitchenItemType = OneOf.OneOf<IIngredientGetter, IIngestibleGetter>;


static class KitchenItemTypeExtensions
{
    extension(KitchenItemType kitchenItemType)
    {
        public IFormKeyGetter AsFormKeyGetter() =>
            kitchenItemType.Match<IFormKeyGetter>(
                ingredient => ingredient,
                ingestible => ingestible
            );

        public IReadOnlyList<IFormLinkGetter<IKeywordGetter>>? Keywords =>
            kitchenItemType.Match(
                ingredient => ingredient.Keywords,
                ingestible => ingestible.Keywords
            );
        
        public static KitchenItemType FromMajorRecordGetter(IMajorRecordGetter majorRecord) => majorRecord switch
        {
            IIngredientGetter ingredient => KitchenItemType.FromT0(ingredient),
            IIngestibleGetter ingestible => KitchenItemType.FromT1(ingestible),
            _ => throw new ArgumentException($"Unsupported major record type: {majorRecord.GetType().Name}")
        };
    }
}

public class KitchenPatcher(
    IPatcherState<ISkyrimMod, ISkyrimModGetter> State
)
{
    private KitchenFormListOverrides KitchenFormListOverrides = null!;
    private FormListOverride Kitchen = null!;


    private void AddItemToCheese(IFormKeyGetter miscItem)
    {
        if (KitchenFormListOverrides.FoodCheese.FormList.Items.Contains(miscItem.FormKey))
        {
            return;
        }

        KitchenFormListOverrides.FoodCheese.FormList.Items.Add(miscItem.FormKey);
        KitchenFormListOverrides.FoodCheese.Overriden = true;

        AddItemToKitchen(miscItem);
    }

    private void AddItemToDrink(IFormKeyGetter kitchenItem)
    {
        if (KitchenFormListOverrides.FoodDrink.FormList.Items.Contains(kitchenItem.FormKey))
        {
            return;
        }

        KitchenFormListOverrides.FoodDrink.FormList.Items.Add(kitchenItem.FormKey);
        KitchenFormListOverrides.FoodDrink.Overriden = true;

        AddItemToKitchen(kitchenItem);
    }

    private void AddItemToFruitVegetable(IFormKeyGetter kitchenItem)
    {
        if (KitchenFormListOverrides.FoodFruitVegetable.FormList.Items.Contains(kitchenItem.FormKey))
        {
            return;
        }

        KitchenFormListOverrides.FoodFruitVegetable.FormList.Items.Add(kitchenItem.FormKey);
        KitchenFormListOverrides.FoodFruitVegetable.Overriden = true;

        AddItemToKitchen(kitchenItem);
    }

    private void AddItemToMeat(IFormKeyGetter kitchenItem)
    {
        if (KitchenFormListOverrides.FoodMeat.FormList.Items.Contains(kitchenItem.FormKey))
        {
            return;
        }

        KitchenFormListOverrides.FoodMeat.FormList.Items.Add(kitchenItem.FormKey);
        KitchenFormListOverrides.FoodMeat.Overriden = true;

        AddItemToKitchen(kitchenItem);
    }

    private void AddItemToPreparedFood(IFormKeyGetter kitchenItem)
    {
        if (KitchenFormListOverrides.FoodPrepared.FormList.Items.Contains(kitchenItem.FormKey))
        {
            return;
        }

        KitchenFormListOverrides.FoodPrepared.FormList.Items.Add(kitchenItem.FormKey);
        KitchenFormListOverrides.FoodPrepared.Overriden = true;

        AddItemToKitchen(kitchenItem);
    }

    private void AddItemToKitchen(IFormKeyGetter kitchenItem)
    {
        if (Kitchen.FormList.Items.Contains(kitchenItem.FormKey))
        {
            return;
        }

        Kitchen.FormList.Items.Add(kitchenItem.FormKey);
        Kitchen.Overriden = true;
    }

    private void InitializeFormListOverrides()
    {
        KitchenFormListOverrides = new(
            ClockworkFormLists.Kitchen.FoodCheese.ToFormListOverride(State),
            ClockworkFormLists.Kitchen.FoodMeat.ToFormListOverride(State),
            ClockworkFormLists.Kitchen.FoodPrepared.ToFormListOverride(State),
            ClockworkFormLists.Kitchen.FoodDrink.ToFormListOverride(State),
            ClockworkFormLists.Kitchen.FoodFruitVegetable.ToFormListOverride(State)

        );

        Kitchen = ClockworkFormLists.Rooms.Kitchen.ToFormListOverride(State);
    }

    private void OverrideToPatchMod()
    {
        if (Kitchen.Overriden)
        {
            State.PatchMod.FormLists.Set(Kitchen.FormList);
        }

        foreach (var formListOverride in KitchenFormListOverrides.GetType().GetProperties())
        {
            var formListOverrideValue = (FormListOverride)formListOverride.GetValue(KitchenFormListOverrides)!;

            if (formListOverrideValue.Overriden)
            {
                State.PatchMod.FormLists.Set(formListOverrideValue.FormList);
            }
        }
    }

    private void PatchFormList<TRecordType>(List<FormLink<IKeywordGetter>> keywords, Action<IFormKeyGetter> addItemAction)
        where TRecordType : class, IMajorRecordGetter
    {
        if (keywords == null || keywords.Count == 0)
        {
            return;
        }

        var items = State.LoadOrder.PriorityOrder.WinningOverrides<TRecordType>()
                         .Select(KitchenItemType.FromMajorRecordGetter)
                         .Where(kitem => kitem.Keywords?.Any(kw => keywords.Contains(kw)) ?? false)
                         .Select(kitem => kitem.AsFormKeyGetter())
                         .ToList();
        
        items.ForEach(addItemAction);
    }

    public void Run()
    {
        InitializeFormListOverrides();

        PatchFormList<IIngestibleGetter>(Settings.Instance.Value.MeatKitchenKeywords               , AddItemToMeat);
        PatchFormList<IIngestibleGetter>(Settings.Instance.Value.FruitsAndVegetablesKitchenKeywords, AddItemToFruitVegetable);
        PatchFormList<IIngestibleGetter>(Settings.Instance.Value.PreparedFoodKitchenKeywords       , AddItemToPreparedFood);
        PatchFormList<IIngestibleGetter>(Settings.Instance.Value.SeasoningKitchenKeywords          , AddItemToCheese);
        PatchFormList<IIngredientGetter>(Settings.Instance.Value.SeasoningKitchenKeywords          , AddItemToCheese);
        PatchFormList<IIngestibleGetter>(Settings.Instance.Value.DrinkKitchenKeywords              , AddItemToDrink);
        PatchFormList<IIngestibleGetter>(Settings.Instance.Value.CheeseKitchenKeywords             , AddItemToCheese);

        PatchFormList<IIngredientGetter>(Settings.Instance.Value.KitchenKeywords                   , AddItemToKitchen);
        PatchFormList<IIngestibleGetter>(Settings.Instance.Value.KitchenKeywords                   , AddItemToKitchen);

        OverrideToPatchMod();
    }
}