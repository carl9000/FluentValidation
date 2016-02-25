﻿namespace FluentValidation.Validators {
	using System;
	using FluentValidation.Internal;

	public class EnumValidator : PropertyValidator {
		private readonly Type _enumType;

		public EnumValidator(Type enumType) : base("Property {PropertyName} it not a valid enum value.") {
			this._enumType = enumType;
		}

		protected override bool IsValid(PropertyValidatorContext context) {
            if (context.PropertyValue == null) return true;

            Type enumType = Nullable.GetUnderlyingType(_enumType) ?? _enumType;

            if (!enumType.IsEnum()) return false;
			return Enum.IsDefined(enumType, context.PropertyValue);
		}
	}
}