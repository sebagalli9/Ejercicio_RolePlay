using NUnit.Framework;
using Library;

namespace Test.Library
{
    public class BowTest
    {
        private Bow bow;

        [SetUp]
        public void SetUp()
        {
            bow = new Bow("Arco gigante",50,0,"Tira fuego",false);
        }


        [Test]
        public void BowCorrectlyInstanced()
        //Se prueba que el arco se instanció correctamente.
        {
            //Assert
            Assert.IsNotNull(bow);
        }

        [Test]
        public void AttackValueCheck()
        //Se prueba que el valor del ataque del arco sea el esperado.
        {
            int expectedAttackValue = 50;

            //Assert
            Assert.AreEqual(expectedAttackValue,bow.Damage);
        }

        [Test]
        public void NameCannotBeNull()
        //Se prueba que el nombre del arco no sea null.
        {
            Assert.IsNotNull(bow.Name);
        }

        [Test]
        public void ItemNotMagic()
        //Se prueba que no sea un item de daño magico sino que en cambio sea de daño fisico.
        {
            Assert.AreEqual(false,bow.MagicItem);
        }
    }
}