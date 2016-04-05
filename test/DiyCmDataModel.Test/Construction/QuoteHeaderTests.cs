using DiyCmDataModel.Construction;
using DiyCmDataModel.Test.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace DiyCmDataModel.Test.Construction
{
    public class QuoteHeaderTests
    {
        public QuoteHeaderTests()
        {

        }
        [Fact]
        public void Property_Count_of_QuoteHeader_is_16()
        {
            PropertyInfo[] properties = typeof(QuoteHeader).GetProperties();
            Assert.Equal(16, properties.Length);
        }
        [Fact]
        public void Have_QuoteHeaderId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.QuoteHeaderId);
            Assert.Equal("QuoteHeaderId", property);
        }
        [Fact]
        public void Have_Supplier_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.Supplier);
            Assert.Equal("Supplier", property);
        }
        [Fact]
        public void Have_Date_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.Date);
            Assert.Equal("Date", property);
        }
        [Fact]
        public void Have_StartDate_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.StartDate);
            Assert.Equal("StartDate", property);
        }
        [Fact]
        public void Have_ReferredBy_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.ReferredBy);
            Assert.Equal("ReferredBy", property);
        }
        [Fact]
        public void Have_AddressStreet_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.AddressStreet);
            Assert.Equal("AddressStreet", property);
        }
        [Fact]
        public void Have_AddressCity_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.AddressCity);
            Assert.Equal("AddressCity", property);
        }
        [Fact]
        public void Have_AddressProvince_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.AddressProvince);
            Assert.Equal("AddressProvince", property);
        }
        [Fact]
        public void Have_AddressPostalCode_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.AddressPostalCode);
            Assert.Equal("AddressPostalCode", property);
        }
        [Fact]
        public void Have_AddressCountry_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.AddressCountry);
            Assert.Equal("AddressCountry", property);
        }
        [Fact]
        public void Have_ExpiryDate_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.ExpiryDate);
            Assert.Equal("ExpiryDate", property);
        }
        [Fact]
        public void Have_PercentDiscount_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.PercentDiscount);
            Assert.Equal("PercentDiscount", property);
        }
        [Fact]
        public void Have_Notes_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.notes);
            Assert.Equal("notes", property);
        }
        [Fact]
        public void Have_IsAccept_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.IsAccept);
            Assert.Equal("IsAccept", property);
        }
        [Fact]
        public void Have_ContactName_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.ContactName);
            Assert.Equal("ContactName", property);
        }
        [Fact]
        public void Have_PhoneNumber_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteHeader x) => x.PhoneNumber);
            Assert.Equal("PhoneNumber", property);
        }
        //////////

        [Fact]
        public void Type_of_QuoteHeaderId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.QuoteHeaderId);
            Assert.Equal("Int32", type);
        }
        [Fact]
        public void Type_of_Supplier_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.Supplier);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_Date_is_DateTime()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.Date);
            Assert.Equal("DateTime", type);
        }
        [Fact]
        public void Type_of_StartDate_is_DateTime()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.StartDate);
            Assert.Equal("DateTime", type);
        }
        [Fact]
        public void Type_of_ReferredBy_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.ReferredBy);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_AddressStreet_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.AddressStreet);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_AddressCity_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.AddressCity);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_AddressProvince_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.AddressProvince);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_AddressPostalCode_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.AddressPostalCode);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_AddressCountry_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.AddressCountry);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_ExpiryDate_is_DateTime()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.ExpiryDate);
            Assert.Equal("DateTime", type);
        }
        [Fact]
        public void Type_of_PercentDiscount_is_Decimal()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.PercentDiscount);
            Assert.Equal("Decimal", type);
        }
        [Fact]
        public void Type_of_Notes_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.notes);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_IsAccept_is_Char()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.IsAccept);
            Assert.Equal("Char", type);
        }
        [Fact]
        public void Type_of_ContactName_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.ContactName);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_PhoneNumber_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((QuoteHeader x) => x.PhoneNumber);
            Assert.Equal("String", type);
        }

    }
}
