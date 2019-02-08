﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using Xunit;

namespace System.Text.Json.Serialization.Tests
{
    public interface ITestClass
    {
        void Initialize();
        void Verify();
    }

    public enum SampleEnum
    {
        One = 1,
        Two = 2
    }
    public class SimpleTestClass : ITestClass
    {
        public short MyInt16 { get; set; }
        public int MyInt32 { get; set; }
        public long MyInt64 { get; set; }
        public ushort MyUInt16 { get; set; }
        public uint MyUInt32 { get; set; }
        public ulong MyUInt64 { get; set; }
        public byte MyByte { get; set; }
        public char MyChar { get; set; }
        public string MyString { get; set; }
        public decimal MyDecimal { get; set; }
        public bool MyBooleanTrue { get; set; }
        public bool MyBooleanFalse { get; set; }
        public float MySingle { get; set; }
        public double MyDouble { get; set; }
        public DateTime MyDateTime { get; set; }
        public SampleEnum MyEnum { get; set; }

        public static readonly string s_json =
                @"{" +
                @"""MyInt16"" : 1," +
                @"""MyInt32"" : 2," +
                @"""MyInt64"" : 3," +
                @"""MyUInt16"" : 4," +
                @"""MyUInt32"" : 5," +
                @"""MyUInt64"" : 6," +
                @"""MyByte"" : 7," +
                @"""MyChar"" : ""a""," +
                @"""MyString"" : ""Hello""," +
                @"""MyBooleanTrue"" : true," +
                @"""MyBooleanFalse"" : false," +
                @"""MySingle"" : 1.1," +
                @"""MyDouble"" : 2.2," +
                @"""MyDecimal"" : 3.3," +
                @"""MyDateTime"" : ""2019-01-30T12:01:02.0000000Z""," +
                @"""MyEnum"" : 2" + // int by default
                @"}";

        public static readonly byte[] s_data = Encoding.UTF8.GetBytes(s_json);

        public void Initialize()
        {
            MyInt16 = 1;
            MyInt32 = 2;
            MyInt64 = 3;
            MyUInt16 = 4;
            MyUInt32 = 5;
            MyUInt64 = 6;
            MyByte = 7;
            MyChar = 'a';
            MyString = "Hello";
            MyBooleanTrue = true;
            MyBooleanFalse = false;
            MySingle = 1.1f;
            MyDouble = 2.2d;
            MyDecimal = 3.3m;
            MyDateTime = new DateTime(2019, 1, 30, 12, 1, 2, DateTimeKind.Utc);
            MyEnum = SampleEnum.Two;
        }

        public void Verify()
        {
            Assert.Equal((short)1, MyInt16);
            Assert.Equal((int)2, MyInt32);
            Assert.Equal((long)3, MyInt64);
            Assert.Equal((ushort)4, MyUInt16);
            Assert.Equal((uint)5, MyUInt32);
            Assert.Equal((ulong)6, MyUInt64);
            Assert.Equal((byte)7, MyByte);
            Assert.Equal('a', MyChar);
            Assert.Equal("Hello", MyString);
            Assert.Equal(3.3m, MyDecimal);
            Assert.Equal(false, MyBooleanFalse);
            Assert.Equal(true, MyBooleanTrue);
            Assert.Equal(1.1f, MySingle);
            Assert.Equal(2.2d, MyDouble);
            Assert.Equal(new DateTime(2019, 1, 30, 12, 1, 2, DateTimeKind.Utc), MyDateTime);
            Assert.Equal(SampleEnum.Two, MyEnum);
        }
    }

    public class SimpleTestClassWithNullables : ITestClass
    {
        public short? MyInt16 { get; set; }
        public int? MyInt32 { get; set; }
        public long? MyInt64 { get; set; }
        public ushort? MyUInt16 { get; set; }
        public uint? MyUInt32 { get; set; }
        public ulong? MyUInt64 { get; set; }
        public byte? MyByte { get; set; }
        public char? MyChar { get; set; }
        public decimal? MyDecimal { get; set; }
        public bool? MyBooleanTrue { get; set; }
        public bool? MyBooleanFalse { get; set; }
        public float? MySingle { get; set; }
        public double? MyDouble { get; set; }
        public DateTime? MyDateTime { get; set; }
        public SampleEnum? MyEnum { get; set; }

        public static readonly string s_json =
                @"{" +
                @"""MyInt16"" : 1," +
                @"""MyInt32"" : 2," +
                @"""MyInt64"" : 3," +
                @"""MyUInt16"" : 4," +
                @"""MyUInt32"" : 5," +
                @"""MyUInt64"" : 6," +
                @"""MyByte"" : 7," +
                @"""MyChar"" : ""a""," +
                @"""MyBooleanTrue"" : true," +
                @"""MyBooleanFalse"" : false," +
                @"""MySingle"" : 1.1," +
                @"""MyDouble"" : 2.2," +
                @"""MyDecimal"" : 3.3," +
                @"""MyDateTime"" : ""2019-01-30T12:01:02.0000000Z""," +
                @"""MyEnum"" : 2" + // int by default
                @"}";

        public static readonly byte[] s_data = Encoding.UTF8.GetBytes(s_json);

        public void Initialize()
        {
            MyInt16 = 1;
            MyInt32 = 2;
            MyInt64 = 3;
            MyUInt16 = 4;
            MyUInt32 = 5;
            MyUInt64 = 6;
            MyByte = 7;
            MyChar = 'a';
            MyBooleanTrue = true;
            MyBooleanFalse = false;
            MySingle = 1.1f;
            MyDouble = 2.2d;
            MyDecimal = 3.3m;
            MyDateTime = new DateTime(2019, 1, 30, 12, 1, 2, DateTimeKind.Utc);
            MyEnum = SampleEnum.Two;
        }

        public void Verify()
        {
            Assert.Equal(MyInt16, (short)1);
            Assert.Equal(MyInt32, (int)2);
            Assert.Equal(MyInt64, (long)3);
            Assert.Equal(MyUInt16, (ushort)4);
            Assert.Equal(MyUInt32, (uint)5);
            Assert.Equal(MyUInt64, (ulong)6);
            Assert.Equal(MyByte, (byte)7);
            Assert.Equal(MyChar, 'a');
            Assert.Equal(MyDecimal, 3.3m);
            Assert.Equal(MyBooleanFalse, false);
            Assert.Equal(MyBooleanTrue, true);
            Assert.Equal(MySingle, 1.1f);
            Assert.Equal(MyDouble, 2.2d);
            Assert.Equal(MyDateTime, new DateTime(2019, 1, 30, 12, 1, 2, DateTimeKind.Utc));
            Assert.Equal(MyEnum, SampleEnum.Two);
        }
    }


     public class TestClassWithNull
    {
        public string MyString { get; set; }
        public static readonly string s_json =
                @"{" +
                @"""MyString"" : null" +
                @"}";

        public static readonly byte[] s_data = Encoding.UTF8.GetBytes(s_json);

        public void Initialize()
        {
            MyString = null;
        }

        public void Verify()
        {
            Assert.Equal(MyString, null);
        }
    }

    public class TestClassWithNullButInitialized
    {
        public string MyString { get; set; } = "Hello";
        public int? MyInt { get; set; } = 1;
        public static readonly string s_json =
                @"{" +
                @"""MyString"" : null," +
                @"""MyInt"" : null" +
                @"}";

        public static readonly byte[] s_data = Encoding.UTF8.GetBytes(s_json);
    }

    public class TestClassWithNestedObjectInner : ITestClass
    {
        public SimpleTestClass MyData { get; set; }

        public static readonly string s_json =
            @"{" +
                @"""MyData"":" + SimpleTestClass.s_json +
            @"}";

        public static readonly byte[] s_data = Encoding.UTF8.GetBytes(s_json);

        public void Initialize()
        {
            MyData = new SimpleTestClass();
            MyData.Initialize();
        }

        public void Verify()
        {
            Assert.NotNull(MyData);
            MyData.Verify();
        }
    }

    public class TestClassWithNestedObjectOuter : ITestClass
    {
        public TestClassWithNestedObjectInner MyData { get; set; }

        public static readonly byte[] s_data = Encoding.UTF8.GetBytes(
            @"{" +
                @"""MyData"":" + TestClassWithNestedObjectInner.s_json +
            @"}");

        public void Initialize()
        {
            MyData = new TestClassWithNestedObjectInner();
            MyData.Initialize();
        }

        public void Verify()
        {
            Assert.NotNull(MyData);
            MyData.Verify();
        }
    }

    public class TestClassWithObjectList : ITestClass
    {
        public List<SimpleTestClass> MyData { get; set; }

        public static readonly byte[] s_data = Encoding.UTF8.GetBytes(
            @"{" +
                @"""MyData"":[" +
                    SimpleTestClass.s_json + "," +
                    SimpleTestClass.s_json +
                @"]" +
            @"}");

        public void Initialize()
        {
            MyData = new List<SimpleTestClass>();

            {
                SimpleTestClass obj = new SimpleTestClass();
                obj.Initialize();
                MyData.Add(obj);
            }

            {
                SimpleTestClass obj = new SimpleTestClass();
                obj.Initialize();
                MyData.Add(obj);
            }
        }

        public void Verify()
        {
            Assert.Equal(2, MyData.Count);
            MyData[0].Verify();
            MyData[1].Verify();
        }
    }

    public class TestClassWithObjectArray : ITestClass
    {
        public SimpleTestClass[] MyData { get; set; }

        public static readonly byte[] s_data = Encoding.UTF8.GetBytes(
            @"{" +
                @"""MyData"":[" +
                    SimpleTestClass.s_json + "," +
                    SimpleTestClass.s_json +
                @"]" +
            @"}");

        public void Initialize()
        {
            SimpleTestClass obj1 = new SimpleTestClass();
            obj1.Initialize();

            SimpleTestClass obj2 = new SimpleTestClass();
            obj2.Initialize();

            MyData = new SimpleTestClass[2] { obj1, obj2 };
        }

        public void Verify()
        {
            MyData[0].Verify();
            MyData[1].Verify();
            Assert.Equal(2, MyData.Length);
        }
    }

    public class TestClassWithStringArray : ITestClass
    {
        public string[] MyData { get; set; }

        public static readonly byte[] s_data = Encoding.UTF8.GetBytes(
            @"{" +
                @"""MyData"":[" +
                    @"""Hello""," +
                    @"""World""" +
                @"]" +
            @"}");

        public void Initialize()
        {
            MyData = new string[] { "Hello", "World" };
        }

        public void Verify()
        {
            Assert.Equal("Hello", MyData[0]);
            Assert.Equal("World", MyData[1]);
            Assert.Equal(2, MyData.Length);
        }
    }

    public class TestClassWithCycle
    {
        public TestClassWithCycle Parent { get; set; }

        public void Initialize()
        {
            Parent = this;
        }
    }

    public class TestClassWithGenericList : ITestClass
    {
        public List<string> MyData { get; set; }

        public static readonly byte[] s_data = Encoding.UTF8.GetBytes(
            @"{" +
                @"""MyData"":[" +
                    @"""Hello""," +
                    @"""World""" +
                @"]" +
            @"}");

        public void Initialize()
        {
            MyData = new List<string>();
            MyData.Add("Hello");
            MyData.Add("World");
            Assert.Equal(2, MyData.Count);
        }

        public void Verify()
        {
            Assert.Equal("Hello", MyData[0]);
            Assert.Equal("World", MyData[1]);
            Assert.Equal(2, MyData.Count);
        }
    }

    public class SimpleDerivedTestClass : SimpleTestClass
    {
    }

    public class OverridePropertyNameDesignTime_TestClass
    {
        [JsonPropertyName(Name = "blah")]
        public Int16 MyInt16 { get; set; }

        public static readonly byte[] DataMatchingAttribute = Encoding.UTF8.GetBytes(
            @"{" +
            @"""blah"" : 1" +
            @"}"
        );

        public static readonly byte[] DataNotMatchingAttribute = Encoding.UTF8.GetBytes(
            @"{" +
            @"""blah2"" : 1" +
            @"}"
        );
    }

    public class OverridePropertyNameRuntime_TestClass
    {
        public Int16 MyInt16 { get; set; }

        public static readonly byte[] Data = Encoding.UTF8.GetBytes(
            @"{" +
            @"""blah"" : 1" +
            @"}"
        );
    }
}
