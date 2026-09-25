using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Plugins;

namespace ClockworkSortListAutoPatcher;


public static class ClockworkFormLists
{
    public static class Rooms
    {
        public static readonly FormLinkGetter<IFormListGetter> Kitchen   = FormKey.Factory("03EA01:Clockwork.esp").ToLink<IFormListGetter>();
        public static readonly FormLinkGetter<IFormListGetter> MageStudy = FormKey.Factory("03E9F6:Clockwork.esp").ToLink<IFormListGetter>();
        public static readonly FormLinkGetter<IFormListGetter> WorkRoom  = FormKey.Factory("03EA00:Clockwork.esp").ToLink<IFormListGetter>();
    }
    public static class MageStudyRoom
    {
        public static class BookLetter
        {
            public static readonly FormLinkGetter<IFormListGetter> A = FormKey.Factory("02DC85:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> B = FormKey.Factory("02DC86:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> C = FormKey.Factory("02DC87:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> D = FormKey.Factory("02DC88:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> E = FormKey.Factory("02DC89:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> F = FormKey.Factory("02DC8A:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> G = FormKey.Factory("02DC8B:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> H = FormKey.Factory("02DC8C:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> I = FormKey.Factory("02DC8D:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> J = FormKey.Factory("02DC8E:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> K = FormKey.Factory("02DC8F:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> L = FormKey.Factory("02DC90:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> M = FormKey.Factory("02DC91:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> N = FormKey.Factory("02DC92:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> O = FormKey.Factory("02DC93:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> P = FormKey.Factory("02DC94:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> Q = FormKey.Factory("02DC95:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> R = FormKey.Factory("02DC96:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> S = FormKey.Factory("02DC97:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> T = FormKey.Factory("02DC98:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> U = FormKey.Factory("02DC99:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> V = FormKey.Factory("02DC9A:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> WX = FormKey.Factory("02DC9B:Clockwork.esp").ToLink<IFormListGetter>();
            public static readonly FormLinkGetter<IFormListGetter> YZ = FormKey.Factory("02DC9C:Clockwork.esp").ToLink<IFormListGetter>();
        }
    
        public static readonly FormLinkGetter<IFormListGetter> AlchemyIngredients = FormKey.Factory("02CC1F:Clockwork.esp").ToLink<IFormListGetter>();
        public static readonly FormLinkGetter<IFormListGetter> BookSpellTomes     = FormKey.Factory("02E214:Clockwork.esp").ToLink<IFormListGetter>();
        public static readonly FormLinkGetter<IFormListGetter> BookNotes          = FormKey.Factory("02E215:Clockwork.esp").ToLink<IFormListGetter>();
        public static readonly FormLinkGetter<IFormListGetter> Scrolls            = FormKey.Factory("02D711:Clockwork.esp").ToLink<IFormListGetter>();
        public static readonly FormLinkGetter<IFormListGetter> SoulGemsEmpty      = FormKey.Factory("02CC20:Clockwork.esp").ToLink<IFormListGetter>();
        public static readonly FormLinkGetter<IFormListGetter> SoulGemsFilled     = FormKey.Factory("02CC21:Clockwork.esp").ToLink<IFormListGetter>();
    }
}