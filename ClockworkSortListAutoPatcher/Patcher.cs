using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;

namespace ClockworkSortListAutoPatcher;


public class Patcher(
    IPatcherState<ISkyrimMod, ISkyrimModGetter> State
)
{
    private Patchers.KitchenPatcher   KitchenPatcher   { get; } = new(State);
    private Patchers.MageStudyPatcher MageStudyPatcher { get; } = new(State);
    private Patchers.WorkRoomPatcher  WorkRoomPatcher  { get; } = new(State);

    public void Run()
    {
        KitchenPatcher.Run();
        MageStudyPatcher.Run();
        WorkRoomPatcher.Run();
    }
}