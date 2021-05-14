using NUnit.Framework;
using Library;

namespace Test.Library
{


    public class SpellTest
    {
        private Spell spell;

        [SetUp]
        public void SetUp()
        {
            
            spell = new Spell("Accio", "Atrae un objeto", true);
            
        }


        [Test]
        public void SpellNameCannotBeNull()
        //Se prueba que el atributo nombre de la instancia de Spell no sea null 
        {
            Assert.IsNotNull(spell.Name);
        }

        [Test]
        public void SpellNameMustBeAString()
        //Se prueba que el atributo name sea del tipo string
        {
            Assert.IsInstanceOf(typeof(string), spell.Name);
        }

        [Test]
        public void SpellPowerCannotBeNull()
        //Se prueba que el atributo power de la instancia de Spell no sea null 
        {
            Assert.IsNotNull(spell.Power);
        }

        [Test]
        public void SpellPowerMustBeAString()
        //Se prueba que el atributo power sea del tipo string
        {
            Assert.IsInstanceOf(typeof(string), spell.Power);
        }

        

    }


}