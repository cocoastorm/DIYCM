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
    public class AreaTest
    {
        [Fact]
        public void Property_Count_of_Area_is_3()
        {
            PropertyInfo[] properties = typeof(Area).GetProperties();
            Assert.Equal(3, properties.Length);
        }

        [Fact]
        public void Have_AreadId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Area x) => x.AreaId);
            Assert.Equal("AreaId", property);
        }
        [Fact]
        public void Have_AreaSquareFootage_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Area x) => x.AreaSquareFootage);
            Assert.Equal("AreaSquareFootage", property);
        }

        [Fact]
        public void Type_of_AreaId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((Area x) => x.AreaId);
            Assert.Equal("Int32", type);
        }
        [Fact]
        public void Type_of_AreaRoom_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((Area x) => x.AreaRoom);
            Assert.Equal("String", type);
        }

        [Fact]
        public void Type_of_AreaSquareFootage_is_Decimal()
        {
            string type = ReflectionUtility.GetPropertyType((Area x) => x.AreaSquareFootage);
            Assert.Equal("Decimal", type);
        }
    }
}
