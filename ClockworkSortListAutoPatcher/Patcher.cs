using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;

namespace ClockworkSortListAutoPatcher;


public class Patcher(
    IPatcherState<ISkyrimMod, ISkyrimModGetter> State
)
{
    private Patchers.MageStudyPatcher MageStudyPatcher { get; } = new(State);

    public void Run()
    {
        MageStudyPatcher.Run();
    }
}