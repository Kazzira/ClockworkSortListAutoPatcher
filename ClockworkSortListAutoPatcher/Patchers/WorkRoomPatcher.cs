using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Plugins;

namespace ClockworkSortListAutoPatcher.Patchers;


public class WorkRoomPatcher(
    IPatcherState<ISkyrimMod, ISkyrimModGetter> State
)
{

    private WorkRoomFormListOverrides WorkRoomFormListOverrides = null!;
    private FormListOverride WorkRoom = null!;


    private void AddMiscItemToAssortedSmithingMats(IMiscItemGetter miscItem)
    {
        if (WorkRoomFormListOverrides.AssortedSmithingMats.FormList.Items.Contains(miscItem.FormKey))
        {
            return;
        }

        WorkRoomFormListOverrides.AssortedSmithingMats.FormList.Items.Add(miscItem.FormKey);
        WorkRoomFormListOverrides.AssortedSmithingMats.Overriden = true;

        AddMiscItemToWorkRoom(miscItem);
    }

    private void AddMiscItemToGems(IMiscItemGetter miscItem)
    {
        if (WorkRoomFormListOverrides.Gems.FormList.Items.Contains(miscItem.FormKey))
        {
            return;
        }

        WorkRoomFormListOverrides.Gems.FormList.Items.Add(miscItem.FormKey);
        WorkRoomFormListOverrides.Gems.Overriden = true;

        AddMiscItemToWorkRoom(miscItem);
    }

    private void AddMiscItemToHides(IMiscItemGetter miscItem)
    {
        if (WorkRoomFormListOverrides.Hides.FormList.Items.Contains(miscItem.FormKey))
        {
            return;
        }

        WorkRoomFormListOverrides.Hides.FormList.Items.Add(miscItem.FormKey);
        WorkRoomFormListOverrides.Hides.Overriden = true;

        AddMiscItemToWorkRoom(miscItem);
    }

    private void AddMiscItemToIngots(IMiscItemGetter miscItem)
    {
        if (WorkRoomFormListOverrides.Ingots.FormList.Items.Contains(miscItem.FormKey))
        {
            return;
        }

        WorkRoomFormListOverrides.Ingots.FormList.Items.Add(miscItem.FormKey);
        WorkRoomFormListOverrides.Ingots.Overriden = true;

        AddMiscItemToWorkRoom(miscItem);
    }

    private void AddMiscItemToOres(IMiscItemGetter miscItem)
    {
        if (WorkRoomFormListOverrides.Ores.FormList.Items.Contains(miscItem.FormKey))
        {
            return;
        }

        WorkRoomFormListOverrides.Ores.FormList.Items.Add(miscItem.FormKey);
        WorkRoomFormListOverrides.Ores.Overriden = true;

        AddMiscItemToWorkRoom(miscItem);
    }

    private void AddMiscItemToWorkRoom(IMiscItemGetter miscItem)
    {
        if (WorkRoom.FormList.Items.Contains(miscItem.FormKey))
        {
            return;
        }

        WorkRoom.FormList.Items.Add(miscItem.FormKey);
        WorkRoom.Overriden = true;
    }

    private void InitializeWorkRoomFormListOverrides()
    {
        WorkRoomFormListOverrides = new WorkRoomFormListOverrides(
            ClockworkFormLists.WorkRoom.Ores.ToFormListOverride(State),
            ClockworkFormLists.WorkRoom.Ingots.ToFormListOverride(State),
            ClockworkFormLists.WorkRoom.Gems.ToFormListOverride(State),
            ClockworkFormLists.WorkRoom.Hides.ToFormListOverride(State),
            ClockworkFormLists.WorkRoom.AssortedSmithingMats.ToFormListOverride(State)
        );

        WorkRoom = ClockworkFormLists.Rooms.WorkRoom.ToFormListOverride(State);
    }

    private void OverridesToPatchMod()
    {
        if (WorkRoom.Overriden)
        {
            State.PatchMod.FormLists.Set(WorkRoom.FormList);
        }

        foreach (var formListOverride  in WorkRoomFormListOverrides.GetType().GetProperties())
        {
            var formListOverrideValue = (FormListOverride)formListOverride.GetValue(WorkRoomFormListOverrides)!;

            if (formListOverrideValue.Overriden)
            {
                State.PatchMod.FormLists.Set(formListOverrideValue.FormList);
            }
        }
    }

    private void PatchFormList(List<FormLink<IKeywordGetter>> keywords, Action<IMiscItemGetter> addMiscItemAction)
    {
        if (keywords == null || keywords.Count == 0)
        {
            return;
        }

        var miscItems = State.LoadOrder.PriorityOrder.WinningOverrides<IMiscItemGetter>()
                             .Where(miscItem => miscItem.Keywords?.Any(kw => keywords.Contains(kw)) ?? false)
                             .ToList();

        miscItems.ForEach(addMiscItemAction);
    }


    public void Run()
    {
        InitializeWorkRoomFormListOverrides();

        PatchFormList(Settings.Instance.Value.SmithingMatsWorkRoomKeywords, AddMiscItemToAssortedSmithingMats);
        PatchFormList(Settings.Instance.Value.OreWorkRoomKeywords         , AddMiscItemToOres);
        PatchFormList(Settings.Instance.Value.IngotWorkRoomKeywords       , AddMiscItemToIngots);
        PatchFormList(Settings.Instance.Value.GemWorkRoomKeywords         , AddMiscItemToGems);
        PatchFormList(Settings.Instance.Value.HideWorkRoomKeywords        , AddMiscItemToHides);
        PatchFormList(Settings.Instance.Value.WorkRoomKeywords            , AddMiscItemToWorkRoom);

        OverridesToPatchMod();
    }
}