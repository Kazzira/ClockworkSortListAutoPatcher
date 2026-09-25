using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Synthesis;

namespace ClockworkSortListAutoPatcher.Patchers;


internal record FormListOverride(
    FormList FormList,
    bool Overriden
)
{
    public bool Overriden { get; set; } = Overriden;
}


internal record KitchenFormListOverrides(
    FormListOverride FoodCheese,
    FormListOverride FoodMeat,
    FormListOverride FoodPrepared,
    FormListOverride FoodDrink,
    FormListOverride FoodFruitVegetable
);

internal record MageStudyRoomFormListOverrides(
    FormListOverride AlchemyIngredients,
    FormListOverride BookSpellTomes,
    FormListOverride BookNotes,
    FormListOverride Scrolls,
    FormListOverride SoulGemsEmpty,
    FormListOverride SoulGemsFilled,
    FormListOverride BookLetterA,
    FormListOverride BookLetterB,
    FormListOverride BookLetterC,
    FormListOverride BookLetterD,
    FormListOverride BookLetterE,
    FormListOverride BookLetterF,
    FormListOverride BookLetterG,
    FormListOverride BookLetterH,
    FormListOverride BookLetterI,
    FormListOverride BookLetterJ,
    FormListOverride BookLetterK,
    FormListOverride BookLetterL,
    FormListOverride BookLetterM,
    FormListOverride BookLetterN,
    FormListOverride BookLetterO,
    FormListOverride BookLetterP,
    FormListOverride BookLetterQ,
    FormListOverride BookLetterR,
    FormListOverride BookLetterS,
    FormListOverride BookLetterT,
    FormListOverride BookLetterU,
    FormListOverride BookLetterV,
    FormListOverride BookLetterWX,
    FormListOverride BookLetterYZ
);

internal record WorkRoomFormListOverrides(
    FormListOverride Ores,
    FormListOverride Ingots,
    FormListOverride Gems,
    FormListOverride Hides,
    FormListOverride AssortedSmithingMats
);


static class FormListLinkExtensions
{
    public static FormListOverride ToFormListOverride(this FormLinkGetter<IFormListGetter> formListLink, IPatcherState<ISkyrimMod, ISkyrimModGetter> State)
    {
        return new(formListLink.Resolve(State.LinkCache).DeepCopy(), false);
    }
}