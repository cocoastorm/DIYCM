using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using DiyCmDataModel.Construction;
using DiyCmDataModel.Test.Utility;

namespace DiyCmDataModel.Test.Construction
{
    public class QuoteDetailsTest
    {
        [Fact]
        public void Property_Count_of_QuoteDetails_is_15()
        {
            PropertyInfo[] properties = typeof(QuoteDetail).GetProperties();
            Assert.Equal(15, properties.Length);
        }

        [Fact]
        public void Have_QuoteDetailId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.QuoteDetailId);
            Assert.Equal("QuoteDetailId", property);
        }
        [Fact]
        public void Have_QuoteHeader_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.QuoteHeader);
            Assert.Equal("QuoteHeader", property);
        }
        [Fact]
        public void Have_LineNumber_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.LineNumber);
            Assert.Equal("LineNumber", property);
        }
        [Fact]
        public void Have_PartId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.PartId);
            Assert.Equal("PartId", property);
        }

        [Fact]
        public void Have_PartDescription_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.PartDescription);
            Assert.Equal("PartDescription", property);
        }

        [Fact]
        public void Have_CategoryId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.CategoryId);
            Assert.Equal("CategoryId", property);
        }

        [Fact]
        public void Have_Category_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.Category);
            Assert.Equal("Category", property);
        }

        [Fact]
        public void Have_SubCategoryId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.SubCategoryId);
            Assert.Equal("SubCategoryId", property);
        }
        [Fact]
        public void Have_SubCategory_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.SubCategory);
            Assert.Equal("SubCategory", property);
        }

        [Fact]
        public void Have_AreaId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.AreaId);
            Assert.Equal("AreaId", property);
        }
        [Fact]
        public void Have_Area_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.Area);
            Assert.Equal("Area", property);
        }

        [Fact]
        public void Have_UnitPrice_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.UnitPrice);
            Assert.Equal("UnitPrice", property);
        }

        [Fact]
        public void Have_Quantity_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.Quantity);
            Assert.Equal("Quantity", property);
        }

        [Fact]
        public void Have_Notes_Property()
        {
            string property = ReflectionUtility.GetPropertyName((QuoteDetail x) => x.Notes);
            Assert.Equal("Notes", property);
        }

        [Fact]
        public void Type_of_QuoteDetailId_is_Int32()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.QuoteDetailId);
            Assert.Equal("Int32", property);
        }

        [Fact]
        public void Type_of_QuoteHeader_is_QuoteHeader()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.QuoteHeader);
            Assert.Equal("QuoteHeader", property);
        }

        [Fact]
        public void Type_of_LineNumber_is_Int32()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.LineNumber);
            Assert.Equal("Int32", property);
        }

        [Fact]
        public void Type_of_PartId_is_String()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.PartId);
            Assert.Equal("String", property);
        }

        [Fact]
        public void Type_of_PartDescription_is_String()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.PartDescription);
            Assert.Equal("String", property);
        }

        [Fact]
        public void Type_of_CategoryId_is_Int32()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.CategoryId);
            Assert.Equal("Int32", property);
        }

        [Fact]
        public void Type_of_Category_is_Category()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.SubCategory);
            Assert.Equal("SubCategory", property);
        }

        [Fact]
        public void Type_of_SubCategory_is_SubCategory()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.SubCategory);
            Assert.Equal("SubCategory", property);
        }

        [Fact]
        public void Type_of_AreaId_is_Int32()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.AreaId);
            Assert.Equal("Int32", property);
        }

        [Fact]
        public void Type_of_Area_is_Area()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.Area);
            Assert.Equal("Area", property);
        }

        [Fact]
        public void Type_of_UnitPrice_is_decimal()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.UnitPrice);
            Assert.Equal("Decimal", property);
        }

        [Fact]
        public void Type_of_Quantity_is_Int32()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.Quantity);
            Assert.Equal("Int32", property);
        }

        [Fact]
        public void Type_of_Notes_is_String()
        {
            string property = ReflectionUtility.GetPropertyType((QuoteDetail x) => x.Notes);
            Assert.Equal("String", property);
        }



    }
}
