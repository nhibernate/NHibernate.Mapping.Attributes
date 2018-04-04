using NUnit.Framework;

namespace NHibernate.Mapping.Attributes.Test
{
    [TestFixture]
    public class HbmWriterHelperFixture
    {

        [Test]
        public void WhenAssemblyAreRegisteredInGAC_GetNameWithAssemblyMustReturnTheFullyQualifiedName()
        {
#if NET461 //There is no GAC in Core.
            var type = typeof(System.Data.DataRow);
            var nameWithAssembly = HbmWriterHelper.GetNameWithAssembly(type);
            Assert.That(nameWithAssembly, Is.EqualTo($"{type.FullName}, {type.Assembly.FullName}"));
#endif
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
