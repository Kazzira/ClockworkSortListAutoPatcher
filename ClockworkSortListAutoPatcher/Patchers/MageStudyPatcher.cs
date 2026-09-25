using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.FormKeys.SkyrimSE;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace ClockworkSortListAutoPatcher.Patchers;


public partial class MageStudyPatcher(
    IPatcherState<ISkyrimMod, ISkyrimModGetter> State
)
{
    [GeneratedRegex(@"^10([0-9]{3})*(\D.*$|$)")]
    private static partial Regex TenMatchRegex();

    [GeneratedRegex(@"^11([0-9]{3})*(\D.*$|$)")]
    private static partial Regex ElevenMatchRegex();

    [GeneratedRegex(@"^12([0-9]{3})*(\D.*$|$)")]
    private static partial Regex TwelveMatchRegex();

    [GeneratedRegex(@"^13([0-9]{3})*(\D.*$|$)")]
    private static partial Regex ThirteenMatchRegex();

    [GeneratedRegex(@"^14([0-9]{3})*(\D.*$|$)")]
    private static partial Regex FourteenMatchRegex();

    [GeneratedRegex(@"^15([0-9]{3})*(\D.*$|$)")]
    private static partial Regex FifteenMatchRegex();

    [GeneratedRegex(@"^16([0-9]{3})*(\D.*$|$)")]
    private static partial Regex SixteenMatchRegex();

    [GeneratedRegex(@"^17([0-9]{3})*(\D.*$|$)")]
    private static partial Regex SeventeenMatchRegex();

    [GeneratedRegex(@"^18([0-9]{3})*(\D.*$|$)")]
    private static partial Regex EighteenMatchRegex();

    [GeneratedRegex(@"^19([0-9]{3})*(\D.*$|$)")]
    private static partial Regex NineteenMatchRegex();
    
    [GeneratedRegex(@"^( |<|-)*([A-Z0-9a-z]+.*$)")]
    private static partial Regex BookNameRegex();


    private readonly List<string> ErrorMessages = [];


    private MageStudyRoomFormListOverrides FormListOverrides = null!;
    private FormListOverride MageStudyRoomFormListOverride = null!;
    
    private FormListOverride GetBookLetterFormList(string bookName)
    {
        FormListOverride Error(string message)
        {
            ErrorMessages.Add(message);
            return FormListOverrides.BookLetterYZ;
        }

        var match = BookNameRegex().Match(bookName);

        if (!match.Success)
        {
            return Error($"Book name '{bookName}' does not match the expected pattern.");
        }

        bookName = match.Groups[2].Value;


        return bookName.ToUpper() switch
        {
            var s when s.StartsWith('A') => FormListOverrides.BookLetterA,
            var s when s.StartsWith('B') => FormListOverrides.BookLetterB,
            var s when s.StartsWith('C') => FormListOverrides.BookLetterC,
            var s when s.StartsWith('D') => FormListOverrides.BookLetterD,
            var s when s.StartsWith('E') => FormListOverrides.BookLetterE,
            var s when s.StartsWith('F') => FormListOverrides.BookLetterF,
            var s when s.StartsWith('G') => FormListOverrides.BookLetterG,
            var s when s.StartsWith('H') => FormListOverrides.BookLetterH,
            var s when s.StartsWith('I') => FormListOverrides.BookLetterI,
            var s when s.StartsWith('J') => FormListOverrides.BookLetterJ,
            var s when s.StartsWith('K') => FormListOverrides.BookLetterK,
            var s when s.StartsWith('L') => FormListOverrides.BookLetterL,
            var s when s.StartsWith('M') => FormListOverrides.BookLetterM,
            var s when s.StartsWith('N') => FormListOverrides.BookLetterN,
            var s when s.StartsWith('O') => FormListOverrides.BookLetterO,
            var s when s.StartsWith('P') => FormListOverrides.BookLetterP,
            var s when s.StartsWith('Q') => FormListOverrides.BookLetterQ,
            var s when s.StartsWith('R') => FormListOverrides.BookLetterR,
            var s when s.StartsWith('S') => FormListOverrides.BookLetterS,
            var s when s.StartsWith('T') => FormListOverrides.BookLetterT,
            var s when s.StartsWith('U') => FormListOverrides.BookLetterU,
            var s when s.StartsWith('V') => FormListOverrides.BookLetterV,
            var s when s.StartsWith('W') || s.StartsWith("X") => FormListOverrides.BookLetterWX,
            var s when s.StartsWith('Y') || s.StartsWith("Z") => FormListOverrides.BookLetterYZ,
            "0" => FormListOverrides.BookLetterYZ,
            var s when TenMatchRegex().IsMatch(s) => FormListOverrides.BookLetterT,
            var s when ElevenMatchRegex().IsMatch(s) => FormListOverrides.BookLetterE,
            var s when TwelveMatchRegex().IsMatch(s) => FormListOverrides.BookLetterT,
            var s when ThirteenMatchRegex().IsMatch(s) => FormListOverrides.BookLetterT,
            var s when FourteenMatchRegex().IsMatch(s) => FormListOverrides.BookLetterF,
            var s when FifteenMatchRegex().IsMatch(s) => FormListOverrides.BookLetterF,
            var s when SixteenMatchRegex().IsMatch(s) => FormListOverrides.BookLetterS,
            var s when SeventeenMatchRegex().IsMatch(s) => FormListOverrides.BookLetterS,
            var s when EighteenMatchRegex().IsMatch(s) => FormListOverrides.BookLetterE,
            var s when NineteenMatchRegex().IsMatch(s) => FormListOverrides.BookLetterN,
            var s when s.StartsWith('1') => FormListOverrides.BookLetterO,
            var s when s.StartsWith('2') => FormListOverrides.BookLetterT,
            var s when s.StartsWith('3') => FormListOverrides.BookLetterT,
            var s when s.StartsWith('4') => FormListOverrides.BookLetterF,
            var s when s.StartsWith('5') => FormListOverrides.BookLetterF,
            var s when s.StartsWith('6') => FormListOverrides.BookLetterS,
            var s when s.StartsWith('7') => FormListOverrides.BookLetterS,
            var s when s.StartsWith('8') => FormListOverrides.BookLetterE,
            var s when s.StartsWith('9') => FormListOverrides.BookLetterN,
            _ => Error($"Book name '{bookName}' does not start with a valid letter or number.")
        };
    }

    private FormList GetFormListOverride(FormLinkGetter<IFormListGetter> formListLink)
    {
        return formListLink.Resolve(State.LinkCache).DeepCopy();
    }

    private void InitializeOverrides()
    {
        Console.WriteLine("[ClockworkSortListAutoPatcher] Initializing FormList overrides...");

        FormListOverrides = new MageStudyRoomFormListOverrides(
            AlchemyIngredients: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.AlchemyIngredients), false),
            BookSpellTomes: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookSpellTomes), false),
            BookNotes: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookNotes), false),
            SoulGemsEmpty: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.SoulGemsEmpty), false),
            SoulGemsFilled: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.SoulGemsFilled), false),
            BookLetterA: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.A), false),
            BookLetterB: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.B), false),
            BookLetterC: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.C), false),
            BookLetterD: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.D), false),
            BookLetterE: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.E), false),
            BookLetterF: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.F), false),
            BookLetterG: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.G), false),
            BookLetterH: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.H), false),
            BookLetterI: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.I), false),
            BookLetterJ: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.J), false),
            BookLetterK: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.K), false),
            BookLetterL: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.L), false),
            BookLetterM: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.M), false),
            BookLetterN: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.N), false),
            BookLetterO: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.O), false),
            BookLetterP: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.P), false),
            BookLetterQ: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.Q), false),
            BookLetterR: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.R), false),
            BookLetterS: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.S), false),
            BookLetterT: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.T), false),
            BookLetterU: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.U), false),
            BookLetterV: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.V), false),
            BookLetterWX: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.WX), false),
            BookLetterYZ: new(GetFormListOverride(ClockworkFormLists.MageStudyRoom.BookLetter.YZ), false)
        );

        MageStudyRoomFormListOverride = new(GetFormListOverride(ClockworkFormLists.Rooms.MageStudy), false);
    }

    private void OutputErrorMessagesIfAny()
    {
        if (ErrorMessages.Count > 0)
        {
            Console.WriteLine("");
            Console.WriteLine("[ClockworkSortListAutoPatcher] The following errors were encountered during patching:");

            foreach (var message in ErrorMessages)
            {
                Console.WriteLine($"[ClockworkSortListAutoPatcher] Error: {message}");
            }
        }
    }

    private void AddBookToRoomFormList(IBookGetter book)
    {
        if (book.Name?.String is null)
        {
            return;
        }
    
        var bookLetterList = GetBookLetterFormList(book.Name.String);

        if (!bookLetterList.FormList.Items.Contains(book.FormKey))
        {
            bookLetterList.FormList.Items.Add(book.FormKey);
            bookLetterList.Overriden = true;
        }

        TryAddToMageStudyRoomFormList(book.FormKey);
    }

    private void AddIngredientToFormList(IIngredientGetter ingredient)
    {
        if (!FormListOverrides.AlchemyIngredients.FormList.Items.Contains(ingredient.FormKey))
        {
            FormListOverrides.AlchemyIngredients.FormList.Items.Add(ingredient.FormKey);
            FormListOverrides.AlchemyIngredients.Overriden = true;
        }

        TryAddToMageStudyRoomFormList(ingredient.FormKey);
    }

    private void AddNoteToFormList(IBookGetter note)
    {
        if (!FormListOverrides.BookNotes.FormList.Items.Contains(note.FormKey))
        {
            FormListOverrides.BookNotes.FormList.Items.Add(note.FormKey);
            FormListOverrides.BookNotes.Overriden = true;
        }

        TryAddToMageStudyRoomFormList(note.FormKey);
    }

    private void AddOverridesToPatchMod()
    {
        if (MageStudyRoomFormListOverride.Overriden)
        {
            State.PatchMod.FormLists.Set(MageStudyRoomFormListOverride.FormList);
        }

        foreach (var formListOverride in FormListOverrides.GetType().GetProperties())
        {
            var overrideValue = (FormListOverride)formListOverride.GetValue(FormListOverrides)!;

            if (overrideValue.Overriden)
            {
                State.PatchMod.FormLists.Set(overrideValue.FormList);
            }
        }
    }

    private void AddScrollToFormList(IBookGetter scroll)
    {
        if (!FormListOverrides.BookSpellTomes.FormList.Items.Contains(scroll.FormKey))
        {
            FormListOverrides.BookSpellTomes.FormList.Items.Add(scroll.FormKey);
            FormListOverrides.BookSpellTomes.Overriden = true;
        }

        TryAddToMageStudyRoomFormList(scroll.FormKey);
    }

    private void AddSoulGemToFormList(ISoulGemGetter soulGem)
    {
        bool empty = !soulGem.LinkedTo.IsNull;
        var formListOverride = empty ? FormListOverrides.SoulGemsEmpty : FormListOverrides.SoulGemsFilled;

        if (!formListOverride.FormList.Items.Contains(soulGem.FormKey))
        {
            formListOverride.FormList.Items.Add(soulGem.FormKey);
            formListOverride.Overriden = true;
        }

        TryAddToMageStudyRoomFormList(soulGem.FormKey);
    }

    private void AddSpellTomeToFormList(IBookGetter spellTome)
    {
        if (!FormListOverrides.BookSpellTomes.FormList.Items.Contains(spellTome.FormKey))
        {
            FormListOverrides.BookSpellTomes.FormList.Items.Add(spellTome.FormKey);
            FormListOverrides.BookSpellTomes.Overriden = true;
            Console.WriteLine($"[ClockworkSortListAutoPatcher] Added Spell Tome '{spellTome.EditorID ?? spellTome.FormKey.ToString()}' to SpellTome FormList.");
        }

        TryAddToMageStudyRoomFormList(spellTome.FormKey);
    }

    private void TryAddToMageStudyRoomFormList(FormKey key)
    {
        if (!MageStudyRoomFormListOverride.FormList.Items.Contains(key))
        {
            Console.WriteLine($"[ClockworkSortListAutoPatcher] Added FormKey '{key}' to MageStudyRoom FormList.");

            MageStudyRoomFormListOverride.FormList.Items.Add(key);
            MageStudyRoomFormListOverride.Overriden = true;
        }
    }

    private void PatchBooks()
    {
        var vendorItemNote      = State.LoadOrder.PriorityOrder.WinningOverrides<IKeywordGetter>().First(x => x.EditorID == "VendorItemNote");

        var Condition = (IBookGetter book) => ( book.Keywords?.Contains(Skyrim.Keyword.VendorItemBook) ?? false ) && !(book.Keywords?.Contains(Skyrim.Keyword.VendorItemSpellTome) ?? false ) && !(book.Keywords?.Contains(vendorItemNote) ?? false );
        var books = State.LoadOrder.PriorityOrder.WinningOverrides<IBookGetter>().Where(Condition).ToList();

        books.ForEach(AddBookToRoomFormList);
    }

    private void PatchIngredients()
    {
        var alchemyIngredientCondition = (IIngredientGetter ingredient) => ingredient.Keywords?.Contains(Skyrim.Keyword.VendorItemIngredient) ?? false;
        var alchemyIngredients = State.LoadOrder.PriorityOrder.WinningOverrides<IIngredientGetter>().Where(alchemyIngredientCondition).ToList();

        alchemyIngredients.ForEach(AddIngredientToFormList);
    }

    private void PatchNotes()
    {
        var vendorItemNote      = State.LoadOrder.PriorityOrder.WinningOverrides<IKeywordGetter>().First(x => x.EditorID == "VendorItemNote");
        var noteCondition = (IBookGetter book) => book.Keywords?.Contains(vendorItemNote) ?? false;
        var notes = State.LoadOrder.PriorityOrder.WinningOverrides<IBookGetter>().Where(noteCondition).ToList();

        notes.ForEach(AddNoteToFormList);
    }

    private void PatchScrolls()
    {
        var scrollCondition = (IBookGetter book) => book.Keywords?.Contains(Skyrim.Keyword.VendorItemScroll) ?? false;
        var scrolls = State.LoadOrder.PriorityOrder.WinningOverrides<IBookGetter>().Where(scrollCondition).ToList();

        scrolls.ForEach(AddScrollToFormList);
    }

    private void PatchSoulGems()
    {
        var soulGemCondition = (ISoulGemGetter soulGem) => soulGem.Keywords?.Contains(Skyrim.Keyword.VendorItemSoulGem) ?? false;
        var soulGems = State.LoadOrder.PriorityOrder.WinningOverrides<ISoulGemGetter>().Where(soulGemCondition).ToList();

        soulGems.ForEach(AddSoulGemToFormList);
    }

    private void PatchSpellTomes()
    {
        Console.WriteLine("[ClockworkSortListAutoPatcher] Patching Spell Tomes...");

        var spellTomeCondition = (IBookGetter book) => book.Keywords?.Contains(Skyrim.Keyword.VendorItemSpellTome) ?? false;
        var spellTomes = State.LoadOrder.PriorityOrder.WinningOverrides<IBookGetter>().Where(spellTomeCondition).ToList();

        spellTomes.ForEach(AddSpellTomeToFormList);
    }

    public void Run()
    {
        InitializeOverrides();

        PatchBooks();
        PatchIngredients();
        PatchNotes();
        PatchScrolls();
        PatchSoulGems();
        PatchSpellTomes();

        AddOverridesToPatchMod();

        OutputErrorMessagesIfAny();
    }
}