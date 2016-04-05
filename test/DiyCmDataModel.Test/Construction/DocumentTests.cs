using DiyCmDataModel.Construction;
using DiyCmDataModel.Test.Utility;
using System;
using System.Linq.Expressions;
using System.Reflection;
using Xunit;

namespace DiyCmDataModel.Test.Construction
{
    public class DocumentTests
    {
        //Checks that model has a total of 3 attributes
        [Fact]
        public void Property_Count_of_Document_is_3()
        {
            PropertyInfo[] properties = typeof(Document).GetProperties();
            Assert.Equal(3, properties.Length);
        }
        //Checks that the attributes of the model have the correct naming
        [Fact]
        public void Have_DocumentId_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Document x) => x.DocumentId);
            Assert.Equal("DocumentId", property);
        }
        [Fact]
        public void Have_DocumentType_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Document x) => x.DocumentType);
            Assert.Equal("DocumentType", property);
        }
        [Fact]
        public void Have_Title_Property()
        {
            string property = ReflectionUtility.GetPropertyName((Document x) => x.Title);
            Assert.Equal("Title", property);
        }
        //Checks the type of each attribute
        [Fact]
        public void Type_of_DocumentId_is_Int32()
        {
            string type = ReflectionUtility.GetPropertyType((Document x) => x.DocumentId);
            Assert.Equal("Int32", type);
        }
        [Fact]
        public void Type_of_DocumentType_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((Document x) => x.DocumentType);
            Assert.Equal("String", type);
        }
        [Fact]
        public void Type_of_Title_is_String()
        {
            string type = ReflectionUtility.GetPropertyType((Document x) => x.Title);
            Assert.Equal("String", type);
        }


    }
}
