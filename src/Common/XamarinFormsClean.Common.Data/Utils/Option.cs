using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace XamarinFormsClean.Common.Data.Utils
{
    public static class Option
    {
        public static Option<T> None<T>() => default;
        public static Option<T> Some<T>(T value) => new Option<T>(value);

        public static Option<T> From<T>(T value) =>
            value == null ? None<T>() : Some(value);

        public static Option<T> From<T>(T value, Predicate<T> selector) =>
            selector(value) ? Some(value) : None<T>();
    }
    
    [DebuggerDisplay("IsSome={IsSome}, Value={Value}")]
    public struct Option<T> : IEquatable<Option<T>>, IEquatable<T>
    {
        public T Value { get; }

        public bool IsSome { get; }
        public readonly bool IsNone => !IsSome;

        public readonly T ValueOrDefault => IsSome ? Value : default;

        internal Option(T value) =>
            (Value, IsSome) = (value, true);

        public void Deconstruct(out T value) => value = Value;
        public void Deconstruct(out T value, out bool isSome) =>
            (value, isSome) = (Value, IsSome);

        public override string ToString() =>
            Value?.ToString() ?? string.Empty;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() =>
            IsNone ? 0 : (Value?.GetHashCode() ?? 0);

        public override bool Equals(object obj) =>
            (obj is Option<T> other) && Equals(other);

        public bool Equals(Option<T> other)
        {
            if (IsNone && other.IsNone) return true;

            return IsSome && other.IsSome && Value != null && Value.Equals(other.Value);
        }

        public bool Equals(T other)
        {
            if (Value != null)
            {
                return Value.Equals(other);
            }

            return other == null;
        }

        public static bool operator ==(Option<T> left, Option<T> right)
        {
            return left.Equals(right);
        }

        public static bool operator ==(Option<T> left, T right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Option<T> left, Option<T> right) =>
            !(left == right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Option<T> left, T right) =>
            !(left == right);

        public static implicit operator Option<T>(T value) =>
            new Option<T>(value);
    }
}