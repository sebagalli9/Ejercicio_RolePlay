using NUnit.Framework;
using Library;

namespace Test.Library
{


    public class MagicStaffTest
    {
        private MagicStaff magicStaff;

        [SetUp]
        public void SetUp()
        {
            
            magicStaff = new MagicStaff("Accio", "Atrae un objeto", true);
            
        }


        [Test]
        public void MagicStaffNameCannotBeNull()
        //Se prueba que el atributo nombre de la instancia de MagicStaff no sea null 
        {
            Assert.IsNotNull(magicStaff.Name);
        }

        [Test]
        public void MagicStaffNameMustBeAString()
        //Se prueba que el atributo name sea del tipo string
        {
            Assert.IsInstanceOf(typeof(string), magicStaff.Name);
        }

        [Test]
        public void MagicStaffPowerCannotBeNull()
        //Se prueba que el atributo power de la instancia de MagicStaff no sea null 
        {
            Assert.IsNotNull(magicStaff.Power);
        }

        [Test]
        public void MagicStaffPowerMustBeAString()
        //Se prueba que el atributo power sea del tipo string
        {
            Assert.IsInstanceOf(typeof(string), magicStaff.Power);
        }

        [Test]
        public void MagicStaffDamageTest()
        //Se prueba que el magicStaff tenga un daño fijo de 50 puntos en todas sus instancias
        {
            Assert.AreEqual(50, magicStaff.Damage);
        }

        [Test]        
        public void MagicStaffProtectionMustBeZero()
        //Se prueba que el magicStaff sea un elemento puramente ofensivo
        {
            Assert.AreEqual(0, magicStaff.Protection);
        }

    }


}