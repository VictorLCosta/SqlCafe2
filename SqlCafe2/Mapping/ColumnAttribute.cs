using System;
using SqlCafe2.Enums;

namespace SqlCafe2.Mapping
{
    [AttributeUsage(
		AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Interface,
		AllowMultiple = true, Inherited = true)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute()
        {
            IsColumn = true;
        }

        public ColumnAttribute(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }

        public DataType DataType { get; set; }

        public string DbType { get; set; }

        public int? Order { get; set; }

        public bool IsColumn { get; set; }

        private bool? _isPrimaryKey;
		
		public bool IsPrimaryKey
		{
			get => _isPrimaryKey ?? false;
			set => _isPrimaryKey = value;
		}

        internal bool HasIsPrimaryKey() => _isPrimaryKey.HasValue;

        private bool? _canBeNull;
		
		public  bool CanBeNull
		{
			get => _canBeNull ?? true;
			set => _canBeNull = value;
		}

        private bool? _skipOnInsert;
		
		public bool SkipOnInsert
		{
			get => _skipOnInsert ?? false;
			set => _skipOnInsert = value;
		}

        internal bool HasSkipOnInsert() => _skipOnInsert.HasValue;

        private bool? _skipOnUpdate;
		
		public bool SkipOnUpdate
		{
			get => _skipOnUpdate ?? false;
			set => _skipOnUpdate = value;
		}

		internal bool HasSkipOnUpdate() => _skipOnUpdate.HasValue;

        private int? _length;

		public  int Length
		{
			get => _length ?? 0;
			set => _length = value;
		}

		internal bool HasLength() => _length.HasValue;

        private int? _precision;
		
		public int Precision
		{
			get => _precision ?? 0;
			set => _precision = value;
		}

        internal bool HasPrecision() => _precision.HasValue;
    }
}