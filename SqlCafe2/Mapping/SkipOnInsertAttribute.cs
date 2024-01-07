namespace SqlCafe2.Mapping
{
    public class SkipOnInsertAttribute : SkipBaseAttribute
    {
        public override SkipModification Affects => SkipModification.Insert;
    }
}