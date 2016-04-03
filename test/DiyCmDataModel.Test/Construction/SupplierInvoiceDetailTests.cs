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
    public class SupplierInvoiceDetailTests
    {
        public SupplierInvoiceDetailTests()
        {

        }

        [Fact]
        public void Property_Count_of_SupplierInvoiceDetail_is_14()
        {
            PropertyInfo[] properties = typeof(SupplierInvoiceDetail).GetProperties();
            Assert.Equal(14, properties.Length);
        }

        [Fact]
        public void Have_InvoiceId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.InvoiceId);
            Assert.Equal("InvoiceId", property);
        }

        [Fact]
        public void Have_LineNumber_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.LineNumber);
            Assert.Equal("LineNumber", property);
        }

        [Fact]
        public void Have_PartNumber_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.PartNumber);
            Assert.Equal("PartNumber", property);
        }

        [Fact]
        public void Have_PartDescription_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.PartDescription);
            Assert.Equal("PartDescription", property);
        }

        [Fact]
        public void Have_CategoryId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.CategoryId);
            Assert.Equal("CategoryId", property);
        }

        [Fact]
        public void Have_Category_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.Category);
            Assert.Equal("Category", property);
        }

        [Fact]
        public void Have_SubCategoryId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.SubCategoryId);
            Assert.Equal("SubCategoryId", property);
        }

        [Fact]
        public void Have_SubCategory_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.SubCategory);
            Assert.Equal("SubCategory", property);
        }

        [Fact]
        public void Have_AreaId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.AreaId);
            Assert.Equal("AreaId", property);
        }

        [Fact]
        public void Have_Area_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.Area);
            Assert.Equal("Area", property);
        }

        [Fact]
        public void Have_Quantity_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.Quantity);
            Assert.Equal("Quantity", property);
        }

        [Fact]
        public void Have_UnitPrice_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.UnitPrice);
            Assert.Equal("UnitPrice", property);
        }

        [Fact]
        public void Have_Notes_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SupplierInvoiceDetail x) => x.Notes);
            Assert.Equal("Notes", property);
        }

        [Fact]
        public void Type_of_InvoiceId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.InvoiceId);
            Assert.Equal("Int32", type);
        }

        [Fact]
        public void Type_of_SupplierInvoiceHeader_is_SupplierInvoiceHeader()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.SupplierInvoiceHeader);
            Assert.Equal("SupplierInvoiceHeader", type);
        }

        [Fact]
        public void Type_of_LineNumber_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.LineNumber);
            Assert.Equal("Int32", type);
        }

        [Fact]
        public void Type_of_PartNumber_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.PartNumber);
            Assert.Equal("String", type);
        }

        [Fact]
        public void Type_of_PartDescription_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.PartDescription);
            Assert.Equal("String", type);
        }

        [Fact]
        public void Type_of_CategoryId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.CategoryId);
            Assert.Equal("Int32", type);
        }

        [Fact]
        public void Type_of_Category_is_Category()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.Category);
            Assert.Equal("Category", type);
        }

        [Fact]
        public void Type_of_SubCategoryId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.SubCategoryId);
            Assert.Equal("Int32", type);
        }

        [Fact]
        public void Type_of_SubCategory_is_SubCategory()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.SubCategory);
            Assert.Equal("SubCategory", type);
        }

        [Fact]
        public void Type_of_AreaId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.AreaId);
            Assert.Equal("Int32", type);
        }

        [Fact]
        public void Type_of_Area_is_Area()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.Area);
            Assert.Equal("Area", type);
        }

        [Fact]
        public void Type_of_Quantity_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.Quantity);
            Assert.Equal("Int32", type);
        }

        [Fact]
        public void Type_of_UnitPrice_is_Decimal()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.UnitPrice);
            Assert.Equal("Decimal", type);
        }

        [Fact]
        public void Type_of_Notes_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SupplierInvoiceDetail x) => x.Notes);
            Assert.Equal("String", type);
        }
    }
}
