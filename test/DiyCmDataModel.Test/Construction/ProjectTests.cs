using DiyCmDataModel.Construction;
using DiyCmDataModel.Test.Utility;
using System;
using System.Linq.Expressions;
using System.Reflection;
using Xunit;

namespace DiyCmDataModel.Test.Construction
{
    public class ProjectTests
    {
        public ProjectTests()
        {
            
        }

        [Fact]
        public void Property_Count_of_Project_is_7()
        {
            PropertyInfo[] properties = typeof(Project).GetProperties();
            Assert.Equal(7, properties.Length);
        }

        [Fact]
        public void Have_ProjectId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Project x) => x.ProjectId);
            Assert.Equal("ProjectId", property);
        }

        [Fact]
        public void Have_ProjectName_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Project x) => x.ProjectName);
            Assert.Equal("ProjectName", property);
        }

        [Fact]
        public void Have_Description_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Project x) => x.Description);
            Assert.Equal("Description", property);
        }

        [Fact]
        public void Have_ProjectedStartDate_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Project x) => x.ProjectedStartDate);
            Assert.Equal("ProjectedStartDate", property);
        }

        [Fact]
        public void Have_ActualStartDate_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Project x) => x.ActualStartDate);
            Assert.Equal("ActualStartDate", property);
        }

        [Fact]
        public void Have_ProjectedFinishDate_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Project x) => x.ProjectedFinishDate);
            Assert.Equal("ProjectedFinishDate", property);
        }

        [Fact]
        public void Have_ActualFinishDate_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Project x) => x.ActualFinishDate);
            Assert.Equal("ActualFinishDate", property);
        }

        [Fact]
        public void Type_of_ProjectId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((Project x) => x.ProjectId);
            Assert.Equal("Int32", type);
        }

        [Fact]
        public void Type_of_ProjectName_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((Project x) => x.ProjectName);
            Assert.Equal("String", type);
        }

        [Fact]
        public void Type_of_Description_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((Project x) => x.Description);
            Assert.Equal("String", type);
        }

        [Fact]
        public void Type_of_ProjectedStartDate_is_DateTime()
        {
            string type = ReflectionUtility.GetPropertyType((Project x) => x.ProjectedStartDate);
            Assert.Equal("DateTime", type);
        }

        [Fact]
        public void Type_of_ActualStartDate_is_DateTime()
        {
            string type = ReflectionUtility.GetPropertyType((Project x) => x.ActualStartDate);
            Assert.Equal("DateTime", type);
        }

        [Fact]
        public void Type_of_ProjectedFinishDate_is_DateTime()
        {
            string type = ReflectionUtility.GetPropertyType((Project x) => x.ProjectedFinishDate);
            Assert.Equal("DateTime", type);
        }

        [Fact]
        public void Type_of_ActualFinishDate_is_DateTime()
        {
            string type = ReflectionUtility.GetPropertyType((Project x) => x.ActualFinishDate);
            Assert.Equal("DateTime", type);
        }
    }
}
