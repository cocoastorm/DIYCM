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
    public class SupplierInvoiceHeaderTests
    {
        public SupplierInvoiceHeaderTests()
        {

        }
        [Fact]
        public void Property_Count_of_SupplierInvoiceHeader_is_17()
        {
            PropertyInfo[] properties = typeof(SupplierInvoiceHeader).GetProperties();
            Assert.Equal(17, properties.Length);
        }
        [Fact]
        public void Have_InvoiceId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.InvoiceId);
            Assert.Equal("InvoiceId", property);
        }
        [Fact]
        public void Have_SupplierName_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.SupplierName);
            Assert.Equal("SupplierName", property);
        }
        [Fact]
        public void Have_QuoteHeaderId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.QuoteHeaderId);
            Assert.Equal("QuoteHeaderId", property);
        }
        [Fact]
        public void Have_ContactName_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.ContactName);
            Assert.Equal("ContactName", property);
        }
        [Fact]
        public void Have_PhoneNumber_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.PhoneNumber);
            Assert.Equal("PhoneNumber", property);
        }
        [Fact]
        public void Have_ReferredBy_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.ReferredBy);
            Assert.Equal("ReferredBy", property);
        }
        [Fact]
        public void Have_AddressStreet_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.AddressStreet);
            Assert.Equal("AddressStreet", property);
        }
        [Fact]
        public void Have_AddressCity_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.AddressCity);
            Assert.Equal("AddressCity", property);
        }
        [Fact]
        public void Have_AddressProvince_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.AddressProvince);
            Assert.Equal("AddressProvince", property);
        }
        [Fact]
        public void Have_AddressPostalCode_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.AddressPostalCode);
            Assert.Equal("AddressPostalCode", property);
        }
        [Fact]
        public void Have_AddressCountry_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.AddressCountry);
            Assert.Equal("AddressCountry", property);
        }
        [Fact]
        public void Have_AmountPaid_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.AmountPaid);
            Assert.Equal("AmountPaid", property);
        }
        [Fact]
        public void Have_PaymentDate_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.PaymentDate);
            Assert.Equal("PaymentDate", property);
        }
        public void Have_SH_AMOUNT_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.SH_AMOUNT);
            Assert.Equal("SH_AMOUNT", property);
        }
        public void Have_SH_AMOUNT_PAID_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceHeader x) => x.SH_AMOUNT_PAID);
            Assert.Equal("SH_AMOUNT_PAID", property);
        }

        ////////////

        [Fact]
        public void Type_of_InvoiceId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.InvoiceId);
            Assert.Equal("Int32", type);
        }
        [Fact]
        public void Type_of_SupplierName_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.SupplierName);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_QuoteHeaderId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.QuoteHeaderId);
            Assert.Equal("Int32", type);
        }
        [Fact]
        public void Type_of_QuoteHeader_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.QuoteHeader);
            Assert.Equal("QuoteHeader", type);
        }
        [Fact]
        public void Type_of_Date_is_DateTime()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.Date);
            Assert.Equal("DateTime", type);
        }
        [Fact]
        public void Type_of_ContactName_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.ContactName);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_PhoneNumber_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.PhoneNumber);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_ReferredBy_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.ReferredBy);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_AddressStreet_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.AddressStreet);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_AddressCity_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.AddressCity);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_AddressProvince_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.AddressProvince);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_AddressPostalCode_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.AddressPostalCode);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_AddressCountry_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.AddressCountry);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_AmountPaid_is_Char()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.AmountPaid);
            Assert.Equal("Char", type);
        }
        [Fact]
        public void Type_of_PaymentDate_is_DateTime()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.PaymentDate);
            Assert.Equal("DateTime", type);
        }
        [Fact]
        public void Type_of_SH_AMOUNT_is_Decimal()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.SH_AMOUNT);
            Assert.Equal("Decimal", type);
        }
        [Fact]
        public void Type_of_SH_AMOUNT_PAID_is_Decimal()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceHeader x) => x.SH_AMOUNT_PAID);
            Assert.Equal("Decimal", type);
        }
    }
}
