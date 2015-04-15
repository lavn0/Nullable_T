using System;
using System.Runtime;

namespace UnnulableClassTest
{
	[Serializable]
	public class Unnullable<T>
	{
		private bool hasValue;
		internal T value;

#if !FEATURE_CORECLR
		[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
		public Unnullable(T value)
		{
			if (value == null)
			{
				throw new NullReferenceException("Null Initialized Unnullable<T>");
			}

			this.value = value;
			this.hasValue = true;
		}

		public bool HasValue
		{
			get
			{
				return hasValue;
			}
		}

		public T Value
		{
#if !FEATURE_CORECLR
			[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
			get
			{
				if (!HasValue)
				{
					//ThrowHelper.ThrowInvalidOperationException(ExceptionResource.InvalidOperation_NoValue);
				}
				return value;
			}
		}

#if !FEATURE_CORECLR
		[TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
#endif
		public T GetValueOrDefault()
		{
			return value;
		}

		public T GetValueOrDefault(T defaultValue)
		{
			return HasValue ? value : defaultValue;
		}

		public override bool Equals(object other)
		{
			if (!HasValue) return other == null;
			if (other == null) return false;
			return value.Equals(other);
		}

		public override int GetHashCode()
		{
			return HasValue ? value.GetHashCode() : 0;
		}

		public override string ToString()
		{
			return HasValue ? value.ToString() : "";
		}

		public static implicit operator T(Unnullable<T> value)
		{
			return value.Value;
		}

		public static explicit operator Unnullable<T>(T value)
		{
			return new Unnullable<T>(value);
		}
	}
}