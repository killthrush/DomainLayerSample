namespace Domain.Base
{
    /// <summary>
    /// A relative indication of how dirty an object is
    /// </summary>
    public enum DirtRating
    {
        SqueakyClean = 0,
        SortaCleanButSmellsFunny = 1,
        Smudged = 2,
        NominallyBesmirched = 3,
        PrettyDirty = 4,
        UtterlyFilthy = 5
    }
}