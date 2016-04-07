using DiyCmDataModel.Construction;
using DiyCmDataModel.Test.Utility;
using System;
using System.Linq.Expressions;
using System.Reflection;
using Xunit;

namespace DiyCmDataModel.Test.Construction
{
    public class SubCategoryTests
    {
        [Fact]
        public void Property_Count_of_SubCategory_is_9()
        {
            PropertyInfo[] properties = typeof(SubCategory).GetProperties();
            Assert.Equal(9, properties.Length);
        }

        [Fact]
        public void Have_SubCategoryId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SubCategory x) => x.SubCategoryId);
            Assert.Equal("SubCategoryId", property);
        }

        [Fact]
        public void Have_SubCategoryName_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SubCategory x) => x.SubCategoryName);
            Assert.Equal("SubCategoryName", property);
        }

        [Fact]
        public void Have_Description_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SubCategory x) => x.Description);
            Assert.Equal("Description", property);
        }

        [Fact]
        public void Have_CategoryId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SubCategory x) => x.CategoryId);
            Assert.Equal("CategoryId", property);
        }

        [Fact]
        public void Have_Category_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SubCategory x) => x.Category);
            Assert.Equal("Category", property);
        }

        [Fact]
        public void Have_BudgetAmount_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SubCategory x) => x.BudgetAmount);
            Assert.Equal("BudgetAmount", property);
        }

        [Fact]
        public void Have_ActualAmount_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SubCategory x) => x.ActualAmount);
            Assert.Equal("ActualAmount", property);
        }

        [Fact]
        public void Have_PercentCompleted_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SubCategory x) => x.PercentCompleted);
            Assert.Equal("PercentCompleted", property);
        }

        [Fact]
        public void Have_VarianceAmount_Property()
        {
            string property = ReflectionUtility.GetPropertyName((SubCategory x) => x.VarianceAmount);
            Assert.Equal("VarianceAmount", property);
        }

        [Fact]
        public void Type_of_SubCategoryId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((SubCategory x) => x.SubCategoryId);
            Assert.Equal("Int32", type);
        }

        [Fact]
        public void Type_of_SubCategoryName_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SubCategory x) => x.SubCategoryName);
            Assert.Equal("String", type);
        }

        [Fact]
        public void Type_of_Descriptioin_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((SubCategory x) => x.Description);
            Assert.Equal("String", type);
        }

        [Fact]
        public void Type_of_CategoryId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((SubCategory x) => x.CategoryId);
            Assert.Equal("Int32", type);
        }

        [Fact]
        public void Type_of_Category_is_Category()
        {
            string type = ReflectionUtility.GetPropertyType((SubCategory x) => x.Category);
            Assert.Equal("Category", type);
        }

        [Fact]
        public void Type_of_BudgetAmount_is_decimal()
        {
            string type = ReflectionUtility.GetPropertyType((SubCategory x) => x.BudgetAmount);
            Assert.Equal("Decimal", type);
        }

        [Fact]
        public void Type_of_ActualAmount_is_decimal()
        {
            string type = ReflectionUtility.GetPropertyType((SubCategory x) => x.ActualAmount);
            Assert.Equal("Decimal", type);
        }

        [Fact]
        public void Type_of_PercentCompleted_is_decimal()
        {
            string type = ReflectionUtility.GetPropertyType((SubCategory x) => x.PercentCompleted);
            Assert.Equal("Decimal", type);
        }

        [Fact]
        public void Type_of_VarianceAmount_is_decimal()
        {
            string type = ReflectionUtility.GetPropertyType((SubCategory x) => x.VarianceAmount);
            Assert.Equal("Decimal", type);
        }
    }
}
