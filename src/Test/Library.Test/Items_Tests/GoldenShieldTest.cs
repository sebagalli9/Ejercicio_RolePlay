using NUnit.Framework;
using Library;

namespace Test.Library
{
    public class GoldenShieldTest
    {
        private GoldenShield goldenShield;

        [SetUp]
        public void SetUp()
        {
            goldenShield = new GoldenShield("Escudo Dorado",0,25,"Escudazo",false);
        }

        [Test]
        public void GoldenShieldCorrectlyInstanced()
        //Se prueba que el escudo se instanció correctamente.
        {   
            //Assert
            Assert.IsNotNull(goldenShield);
        }

        [Test]
        public void DefenseValueCheck()
        //Se prueba que el valor de la defensa del escudo sea el esperado.
        {   
            int expectedDefenseValue = 25;

            //Assert
            Assert.AreEqual(expectedDefenseValue,goldenShield.Protection);
        }

        [Test]
        public void NameCannotBeNull()
        //Se prueba que el nombre del escudo no sea null.
        {
            Assert.IsNotNull(goldenShield.Name);
        }

        [Test]
        public void ItemNotMagic()
        //Se prueba que no sea un item de daño magico sino que en cambio sea de daño fisico.
        {
            Assert.AreEqual(false,goldenShield.MagicItem);
        }
    }
}