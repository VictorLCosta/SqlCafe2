using System;

namespace SqlCafe2.DataProviders
{
    [Flags]
    public enum SqlProviderFlags
    {
        IsTransactionSupported = 0x0,
        IsMultipleResultSupported = 0x1,
        IsParameterNameRequired = 0x2,
        IsUseNamedParameter = 0x3,
        IsUsePositionalParameter = 0x4,
        IsUseParameterName = 0x5,
        SupportsStoredProcedures = 0x6,
        SupportsJsonDataTypes = 0x7,
        SupportsBulkCopy = 0x8,
        SupportsFullTextSearch = 0x9
    }
}