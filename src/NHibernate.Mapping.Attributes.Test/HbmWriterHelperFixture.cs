using NUnit.Framework;

namespace NHibernate.Mapping.Attributes.Test
{
    [TestFixture]
    public class HbmWriterHelperFixture
    {

        [Test]
        public void WhenAssemblyAreRegisteredInGAC_GetNameWithAssemblyMustReturnTheFullyQualifiedName()
        {
            var type = typeof(System.Data.DataRow);
            var nameWithAssembly = HbmWriterHelper.GetNameWithAssembly(type);
            Assert.That(nameWithAssembly, Is.EqualTo($"{type.FullName}, {type.Assembly.FullName}"));
        }

        [Test]
        public void WhenAssemblyAreNotRegisteredInGAC_GetNameWithAssemblyMustReturnTheShortenedAssemblyName()
        {
            var type = typeof(HbmWriterHelper);
            var nameWithAssembly = HbmWriterHelper.GetNameWithAssembly(type);
            Assert.That(nameWithAssembly, Is.EqualTo($"{type.FullName}, {type.Assembly.GetName().Name}"));
        }

    }
}
