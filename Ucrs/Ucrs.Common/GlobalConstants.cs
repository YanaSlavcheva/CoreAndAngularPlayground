namespace Ucrs.Common
{
    public static class GlobalConstants
    {
        public const int EmailMaxLength = 80;
        public const int EmailMinLength = 6;
        public const string EmailRegEx = "^[A-Za-z0-9]+[\\._A-Za-z0-9-]+@([A-Za-z0-9]+[-\\.]?[A-Za-z0-9]+)+(\\.[A-Za-z0-9]+[-\\.]?[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
    }
}
