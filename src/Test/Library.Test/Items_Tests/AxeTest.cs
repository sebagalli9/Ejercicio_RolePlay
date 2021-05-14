using NUnit.Framework;
using Library;

namespace Test.Library
{
    public class AxeTest
    {
        private Axe axe;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe("Super hacha", 50, 0, "Corte Fugaz", false);
        }

        [Test]
        public void AxeCorrectlyInstanced()
        //Se prueba que el hacha se instanció correctamente.
        {   
            //Assert
            Assert.IsNotNull(axe);
        }

        [Test]
        public void AttackValueCheck()
        //Se prueba que el valor del ataque del hacha sea el esperado.
        {  
            //Act
            int expectedAttackValue = 50;

            //Assert
            Assert.AreEqual(expectedAttackValue, axe.Damage);
        }

        [Test]
        public void NameCannotBeNull()
        //Se prueba que el nombre del hacha no sea nulo.
        {
            Assert.IsNotNull(axe.Name);
        }
    }
}