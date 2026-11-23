using System.Data;
using System.Globalization;
using Skybrud.Essentials.Data.Extensions;

namespace TestProject1.Data;

[TestClass]
public class DataRowExtensionsTests {

    private static DataRow CreateRow(params (string Name, Type Type, object? Value)[] columns) {
        DataTable table = new();
        foreach (var col in columns) {
            table.Columns.Add(col.Name, col.Type);
        }
        DataRow row = table.NewRow();
        foreach (var col in columns) {
            row[col.Name] = col.Value ?? DBNull.Value;
        }
        table.Rows.Add(row);
        return row;
    }

    #region GetValue / TryGetValue

    [TestMethod]
    public void GetValue_NullRow_ThrowsArgumentNullException() {
        DataRow row = null!;
        Assert.ThrowsException<ArgumentNullException>(() => row.GetValue("Id"));
    }

    [TestMethod]
    [DataRow(null)]
    public void GetValue_InvalidColumnName_ThrowsArgumentNullException(string? columnName) {
        DataRow row = CreateRow(("Id", typeof(int), 1));
        Assert.ThrowsException<ArgumentNullException>(() => row.GetValue(columnName!));
    }

    [TestMethod]
    [DataRow("")]
    [DataRow("   ")]
    public void GetValue_InvalidColumnName_ThrowsArgumentException(string? columnName) {
        DataRow row = CreateRow(("Id", typeof(int), 1));
        Assert.ThrowsException<ArgumentException>(() => row.GetValue(columnName!));
    }

    [TestMethod]
    public void GetValue_ExistingMissingAndDbNull_ReturnsExpected() {
        DataRow row = CreateRow(
            ("Present", typeof(int), 42),
            ("NullCol", typeof(int), DBNull.Value)
        );

        Assert.AreEqual(42, row.GetValue("Present"));
        Assert.IsNull(row.GetValue("NullCol"));
        Assert.IsNull(row.GetValue("DoesNotExist"));

        Assert.IsTrue(row.TryGetValue("Present", out object? presentVal));
        Assert.AreEqual(42, presentVal);

        Assert.IsFalse(row.TryGetValue("NullCol", out object? nullVal));
        Assert.IsNull(nullVal);

        Assert.IsFalse(row.TryGetValue("DoesNotExist", out object? missingVal));
        Assert.IsNull(missingVal);
    }

    #endregion

    #region String

    [TestMethod]
    public void String_Accessors_WorkAsExpected() {
        DataRow row = CreateRow(
            ("Str", typeof(string), "Hello"),
            ("Empty", typeof(string), ""),
            ("Num", typeof(int), 123),
            ("Null", typeof(string), DBNull.Value)
        );

        Assert.AreEqual("Hello", row.GetString("Str"));
        Assert.AreEqual("", row.GetString("Empty"));
        Assert.AreEqual("123", row.GetString("Num"));
        Assert.IsNull(row.GetString("Null"));
        Assert.IsNull(row.GetString("Missing"));
        Assert.AreEqual("fallback", row.GetString("Missing", "fallback"));

        Assert.AreEqual("Hello", row.GetRequiredString("Str"));
        Assert.AreEqual("", row.GetRequiredString("Empty"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredString("Null"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredString("Missing"));
    }

    #endregion

    #region Signed Integers (Int16, Int32, Int64)

    [TestMethod]
    public void Int16_Accessors_WorkAsExpected() {
        DataRow row = CreateRow(
            ("Valid", typeof(short), (short) 12),
            ("FromString", typeof(string), "-34"),
            ("Overflow", typeof(int), 100_000),
            ("Invalid", typeof(string), "abc"),
            ("Null", typeof(short), DBNull.Value)
        );

        Assert.AreEqual((short) 12, row.GetInt16("Valid"));
        Assert.AreEqual((short) -34, row.GetInt16("FromString"));
        Assert.AreEqual((short) 0, row.GetInt16("Overflow"));
        Assert.AreEqual((short) 99, row.GetInt16("Invalid", 99));
        Assert.IsNull(row.GetInt16OrNull("Null"));
        Assert.IsNull(row.GetInt16OrNull("Missing"));
        Assert.AreEqual((short) 12, row.GetRequiredInt16("Valid"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredInt16("Overflow"));
    }

    [TestMethod]
    public void Int32_Accessors_WorkAsExpected() {
        DataRow row = CreateRow(
            ("Valid", typeof(int), 42),
            ("FromString", typeof(string), "1024"),
            ("Invalid", typeof(string), "not-an-int"),
            ("Null", typeof(int), DBNull.Value)
        );

        Assert.AreEqual(42, row.GetInt32("Valid"));
        Assert.AreEqual(1024, row.GetInt32("FromString"));
        Assert.AreEqual(0, row.GetInt32("Invalid"));
        Assert.AreEqual(-1, row.GetInt32("Invalid", -1));
        Assert.AreEqual(42, row.GetInt32OrNull("Valid"));
        Assert.IsNull(row.GetInt32OrNull("Null"));
        Assert.IsNull(row.GetInt32OrNull("Missing"));
        Assert.AreEqual(42, row.GetRequiredInt32("Valid"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredInt32("Null"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredInt32("Missing"));
    }

    [TestMethod]
    public void Int64_Accessors_WorkAsExpected() {
        DataRow row = CreateRow(
            ("Valid", typeof(long), 9_000_000_000L),
            ("FromString", typeof(string), "-9000000000"),
            ("Invalid", typeof(string), "invalid"),
            ("Null", typeof(long), DBNull.Value)
        );

        Assert.AreEqual(9_000_000_000L, row.GetInt64("Valid"));
        Assert.AreEqual(-9_000_000_000L, row.GetInt64("FromString"));
        Assert.AreEqual(0L, row.GetInt64("Invalid"));
        Assert.AreEqual(7L, row.GetInt64("Missing", 7L));
        Assert.IsNull(row.GetInt64OrNull("Null"));
        Assert.AreEqual(9_000_000_000L, row.GetRequiredInt64("Valid"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredInt64("Invalid"));
    }

    #endregion

    #region Unsigned Integers (UInt16, UInt32, UInt64)

    [TestMethod]
    public void UnsignedIntegers_Accessors_WorkAsExpected() {
        DataRow row = CreateRow(
            ("U16", typeof(ushort), (ushort) 65000),
            ("U32", typeof(uint), 4_000_000_000U),
            ("U64", typeof(ulong), 18_000_000_000_000_000_000UL),
            ("Negative", typeof(int), -5)
        );

        Assert.AreEqual((ushort) 65000, row.GetUInt16("U16"));
        Assert.AreEqual((ushort) 0, row.GetUInt16("Negative"));
        Assert.IsNull(row.GetUInt16OrNull("Negative"));
        Assert.AreEqual((ushort) 65000, row.GetRequiredUInt16("U16"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredUInt16("Negative"));

        Assert.AreEqual(4_000_000_000U, row.GetUInt32("U32"));
        Assert.AreEqual(10U, row.GetUInt32("Negative", 10U));
        Assert.IsNull(row.GetUInt32OrNull("Negative"));
        Assert.AreEqual(4_000_000_000U, row.GetRequiredUInt32("U32"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredUInt32("Negative"));

        Assert.AreEqual(18_000_000_000_000_000_000UL, row.GetUInt64("U64"));
        Assert.AreEqual(20UL, row.GetUInt64("Negative", 20UL));
        Assert.IsNull(row.GetUInt64OrNull("Negative"));
        Assert.AreEqual(18_000_000_000_000_000_000UL, row.GetRequiredUInt64("U64"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredUInt64("Negative"));
    }

    #endregion

    #region Floating Point & Decimal (Float, Double, Decimal)

    [TestMethod]
    public void FloatingPointAndDecimal_AreCultureInvariant() {
        CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
        try {
            // Danish culture uses comma as decimal separator; parsing should remain invariant (dot)
            Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");

            DataRow row = CreateRow(
                ("FloatStr", typeof(string), "12.5"),
                ("DoubleStr", typeof(string), "1234.56"),
                ("DecimalStr", typeof(string), "99.95"),
                ("Invalid", typeof(string), "NaN-ish")
            );

            Assert.AreEqual(12.5f, row.GetFloat("FloatStr"));
            Assert.AreEqual(12.5f, row.GetFloatOrNull("FloatStr"));
            Assert.AreEqual(1.5f, row.GetFloat("Invalid", 1.5f));
            Assert.AreEqual(12.5f, row.GetRequiredFloat("FloatStr"));
            Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredFloat("Invalid"));

            Assert.AreEqual(1234.56d, row.GetDouble("DoubleStr"));
            Assert.AreEqual(1234.56d, row.GetDoubleOrNull("DoubleStr"));
            Assert.IsNull(row.GetDoubleOrNull("Invalid"));
            Assert.AreEqual(1234.56d, row.GetRequiredDouble("DoubleStr"));
            Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredDouble("Invalid"));

            Assert.AreEqual(99.95m, row.GetDecimal("DecimalStr"));
            Assert.AreEqual(99.95m, row.GetDecimalOrNull("DecimalStr"));
            Assert.AreEqual(5.5m, row.GetDecimal("Invalid", 5.5m));
            Assert.AreEqual(99.95m, row.GetRequiredDecimal("DecimalStr"));
            Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredDecimal("Invalid"));
        } finally {
            Thread.CurrentThread.CurrentCulture = originalCulture;
        }
    }

    #endregion

    #region Boolean

    [TestMethod]
    public void Boolean_Accessors_HandleBooleansStringsAndNumbers() {
        DataRow row = CreateRow(
            ("BoolTrue", typeof(bool), true),
            ("BoolFalse", typeof(bool), false),
            ("StrTrue", typeof(string), "true"),
            ("StrOne", typeof(string), "1"),
            ("IntOne", typeof(int), 1),
            ("IntZero", typeof(int), 0),
            ("Invalid", typeof(string), "maybe"),
            ("NonConvertible", typeof(object), new object()),
            ("Null", typeof(bool), DBNull.Value)
        );

        Assert.IsTrue(row.GetBoolean("BoolTrue"));
        Assert.IsFalse(row.GetBoolean("BoolFalse"));
        Assert.IsTrue(row.GetBoolean("StrTrue"));
        Assert.IsTrue(row.GetBoolean("StrOne"));
        Assert.IsTrue(row.GetBoolean("IntOne"));
        Assert.IsFalse(row.GetBoolean("IntZero"));

        Assert.IsFalse(row.GetBoolean("Invalid"));
        Assert.IsTrue(row.GetBoolean("Invalid", true));
        Assert.IsNull(row.GetBooleanOrNull("Invalid"));
        Assert.IsNull(row.GetBooleanOrNull("NonConvertible"));
        Assert.IsNull(row.GetBooleanOrNull("Null"));

        Assert.IsTrue(row.GetRequiredBoolean("BoolTrue"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredBoolean("Invalid"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredBoolean("Missing"));
    }

    #endregion

    #region Guid

    [TestMethod]
    public void Guid_Accessors_HandleGuidsAndStrings() {
        Guid expected = Guid.NewGuid();
        DataRow row = CreateRow(
            ("GuidCol", typeof(Guid), expected),
            ("StrCol", typeof(string), expected.ToString()),
            ("Invalid", typeof(string), "not-a-guid"),
            ("Null", typeof(Guid), DBNull.Value)
        );

        Assert.AreEqual(expected, row.GetGuid("GuidCol"));
        Assert.AreEqual(expected, row.GetGuid("StrCol"));
        Assert.AreEqual(Guid.Empty, row.GetGuid("Invalid"));
        Assert.AreEqual(expected, row.GetGuid("Invalid", expected));
        Assert.AreEqual(expected, row.GetGuidOrNull("StrCol"));
        Assert.IsNull(row.GetGuidOrNull("Invalid"));
        Assert.IsNull(row.GetGuidOrNull("Null"));

        Assert.AreEqual(expected, row.GetRequiredGuid("GuidCol"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredGuid("Invalid"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredGuid("Missing"));
    }

    #endregion

    #region DateTime / DateTimeOffset / TimeSpan

    [TestMethod]
    public void DateTime_Accessors_WorkAsExpected() {
        DateTime expected = new(2026, 11, 23, 20, 0, 0, DateTimeKind.Utc);
        DataRow row = CreateRow(
            ("DtCol", typeof(DateTime), expected),
            ("StrCol", typeof(string), "2026-11-23T20:00:00Z"),
            ("Invalid", typeof(string), "not-a-date"),
            ("Null", typeof(DateTime), DBNull.Value)
        );

        Assert.AreEqual(expected, row.GetDateTime("DtCol"));
        Assert.AreEqual(expected, row.GetDateTime("StrCol").ToUniversalTime());
        Assert.AreEqual(default, row.GetDateTime("Invalid"));
        Assert.AreEqual(expected, row.GetDateTime("Invalid", expected));
        Assert.IsNull(row.GetDateTimeOrNull("Invalid"));
        Assert.IsNull(row.GetDateTimeOrNull("Null"));

        Assert.AreEqual(expected, row.GetRequiredDateTime("DtCol"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredDateTime("Invalid"));
    }

    [TestMethod]
    public void DateTimeOffset_Accessors_HandleOffsetDateTimeAndString() {
        DateTimeOffset expected = new(2026, 11, 23, 20, 0, 0, TimeSpan.FromHours(1));
        DateTime dt = new(2026, 11, 23, 20, 0, 0, DateTimeKind.Local);

        DataRow row = CreateRow(
            ("DtoCol", typeof(DateTimeOffset), expected),
            ("DtCol", typeof(DateTime), dt),
            ("StrCol", typeof(string), "2026-11-23T20:00:00+01:00"),
            ("Invalid", typeof(string), "invalid-dto"),
            ("Null", typeof(DateTimeOffset), DBNull.Value)
        );

        Assert.AreEqual(expected, row.GetDateTimeOffset("DtoCol"), "#1");
        Assert.AreEqual(new DateTimeOffset(dt), row.GetDateTimeOffset("DtCol"), "#2");
        Assert.AreEqual(expected, row.GetDateTimeOffset("StrCol"), "#3");
        Assert.AreEqual(default, row.GetDateTimeOffset("Invalid"), "#4");
        Assert.AreEqual(expected, row.GetDateTimeOffset("Invalid", expected), "#5");
        Assert.IsNull(row.GetDateTimeOffsetOrNull("Null"), "#6");

        Assert.AreEqual(expected, row.GetRequiredDateTimeOffset("DtoCol"), "#7");
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredDateTimeOffset("Invalid"), "#8");
    }

    [TestMethod]
    public void TimeSpan_Accessors_HandleTimeSpanAndString() {
        TimeSpan expected = new(2, 30, 15);
        DataRow row = CreateRow(
            ("TsCol", typeof(TimeSpan), expected),
            ("StrCol", typeof(string), "02:30:15"),
            ("Invalid", typeof(string), "not-a-timespan"),
            ("Null", typeof(TimeSpan), DBNull.Value)
        );

        Assert.AreEqual(expected, row.GetTimeSpan("TsCol"));
        Assert.AreEqual(expected, row.GetTimeSpan("StrCol"));
        Assert.AreEqual(TimeSpan.Zero, row.GetTimeSpan("Invalid"));
        Assert.AreEqual(expected, row.GetTimeSpan("Invalid", expected));
        Assert.AreEqual(expected, row.GetTimeSpanOrNull("StrCol"));
        Assert.IsNull(row.GetTimeSpanOrNull("Invalid"));
        Assert.IsNull(row.GetTimeSpanOrNull("Null"));

        Assert.AreEqual(expected, row.GetRequiredTimeSpan("TsCol"));
        Assert.ThrowsException<InvalidOperationException>(() => row.GetRequiredTimeSpan("Invalid"));
    }

    #endregion

}