namespace SqlCafe2.Mapping
{
    public class SkipOnUpdateAttribute : SkipBaseAttribute
    {
        public override SkipModification Affects => SkipModification.Update;
    }
}