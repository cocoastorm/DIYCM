using DiyCmDataModel.Construction;
using DiyCmDataModel.Test.Utility;
using System;
using System.Linq.Expressions;
using System.Reflection;
using Xunit;

namespace DiyCmDataModel.Test.Construction
{
    public class CategoryTest
    {
        //Check that the Category Model has 8 attributes total
        [Fact]
        public void Property_Count_of_Category_is_9()
        {
            PropertyInfo[] properties = typeof(Category).GetProperties();
            Assert.Equal(9, properties.Length);
        }
        //Check that each Attribute is named correctly
        [Fact]
        public void Have_CategoryId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Category x) => x.CategoryId);
            Assert.Equal("CategoryId", property);
        }
        [Fact]
        public void Have_ProjectId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Category x) => x.ProjectId);
            Assert.Equal("ProjectId", property);
        }

        [Fact]
        public void Have_ProjectEntity_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Category x) => x.ProjectEntity);
            Assert.Equal("ProjectEntity", property);
        }
        [Fact]
        public void Have_CategoryName_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Category x) => x.CategoryName);
            Assert.Equal("CategoryName", property);
        }
        [Fact]
        public void Have_Description_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Category x) => x.Description);
            Assert.Equal("Description", property);
        }
        [Fact]
        public void Have_BudgetAmount_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Category x) => x.BudgetAmount);
            Assert.Equal("BudgetAmount", property);
        }
        [Fact]
        public void Have_ActualAmount_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Category x) => x.ActualAmount);
            Assert.Equal("ActualAmount", property);
        }
        [Fact]
        public void Have_PercentCompleted_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Category x) => x.PercentCompleted);
            Assert.Equal("PercentCompleted", property);
        }
        [Fact]
        public void Have_VarianceAmount_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Category x) => x.VarianceAmount);
            Assert.Equal("VarianceAmount", property);
        }
        //Check that the type of the attributes are correctly set
        [Fact]
        public void Type_of_CategoryId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((Category x) => x.CategoryId);
            Assert.Equal("Int32", type);
        }
        [Fact]
        public void Type_of_ProjectId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((Category x) => x.ProjectId);
            Assert.Equal("Int32", type);
        }

        [Fact]
        public void Type_of_ProjectEntity_is_Project()
        {
            string type = ReflectionUtility.GetPropertyType((Category x) => x.ProjectEntity);
            Assert.Equal("Project", type);
        }
        [Fact]
        public void Type_of_CategoryName_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((Category x) => x.CategoryName);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_Description_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((Category x) => x.Description);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_BudgetAmount_is_Decimal()
        {
            string type = ReflectionUtility.GetPropertyType((Category x) => x.BudgetAmount);
            Assert.Equal("Decimal", type);
        }
        [Fact]
        public void Type_of_ActualAmount_is_Decimal()
        {
            string type = ReflectionUtility.GetPropertyType((Category x) => x.ActualAmount);
            Assert.Equal("Decimal", type);
        }
        [Fact]
        public void Type_of_PercentCompleted_is_Decimal()
        {
            string type = ReflectionUtility.GetPropertyType((Category x) => x.PercentCompleted);
            Assert.Equal("Decimal", type);
        }
        [Fact]
        public void Type_of_VarianceAmount_is_Decimal()
        {
            string type = ReflectionUtility.GetPropertyType((Category x) => x.VarianceAmount);
            Assert.Equal("Decimal", type);
        }
    }
}
