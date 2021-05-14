using NUnit.Framework;
using Library;

namespace Test.Library
{
    public class InvisibilityCloakTest
    {
        private InvisibilityCloak cloak;

        [SetUp]
        public void SetUp()
        {
            cloak = new InvisibilityCloak("Velo de la noche", 0, 80, "Invisibilidad", true);
        }

        [Test]
        public void AxeCorrectlyInstanced()
        //Se prueba que la capa se instanció correctamente.
        {   
            //Assert
            Assert.IsNotNull(cloak);
        }

        [Test]
        public void ProtectionValueCheck()
        //Se prueba que el valor de protección de la capa sea el esperado.
        {  
            //Act
            int expectedProtectionValue = 80;

            //Assert
            Assert.AreEqual(expectedProtectionValue, cloak.Protection);
        }

        [Test]
        public void NameCannotBeNull()
        //Se prueba que el nombre de la capa no sea nulo.
        {
            Assert.IsNotNull(cloak.Name);
        }
    }
}