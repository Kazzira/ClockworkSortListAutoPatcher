using Mutagen.Bethesda.Skyrim;

namespace ClockworkSortListAutoPatcher.Patchers;


internal record FormListOverride(
    FormList FormList,
    bool Overriden
)
{
    public bool Overriden { get; set; } = Overriden;
}

internal record MageStudyRoomFormListOverrides(
    FormListOverride AlchemyIngredients,
    FormListOverride BookSpellTomes,
    FormListOverride BookNotes,
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