using NUnit.Framework;
using Library;

namespace Test.Library
{


    public class SpellBookTest
    {
        private SpellBook spellBook;
        private Spell spell;

        [SetUp]
        public void SetUp()
        {
            spellBook = new SpellBook("Libro", "Libro con hechizos", true);
            spell = new Spell("Expecto patronum", "Invoca un Patronus", true);
            
        }

        [Test]
        public void SpellBookNameCannotBeNull()
        //Se prueba que el atributo name de la instancia de spellBook no sea null
        {
            Assert.IsNotNull(spellBook.Name);
        }

        [Test]
        public void SpellBookPowerCannotBeNull()
        //Se prueba que el atributo power de la instancia de spellBook no sea null 
        {
            Assert.IsNotNull(spellBook.Power);
        }

        [Test]
        public void SpellBookNameMustBeAString()
        //Se prueba que el atributo name sea del tipo string
        {
            Assert.IsInstanceOf(typeof(string), spellBook.Name);
        }

        [Test]
        public void SpellBookPowerMustBeString()
        //Se prueba que el atributo power sea del tipo string
        {
            Assert.IsInstanceOf(typeof(string), spellBook.Power);
        }

        [Test]
        public void SpellBookMustStartEmpty()
        //Se prueba que el libro de hechizos se instancie inicialmente sin contener hechizos
        {
            Assert.AreEqual(0,spellBook.spells.Count);
        }

        [Test]
        public void CorrectSpellBookDamageCalculation()
        //Se prueba que el daño de un spellbook sea igual al total de hechizos que contiene
        {
            //Act
            spellBook.AddSpell(spell);
            spellBook.AddSpell(spell);
            spellBook.AddSpell(spell);
            spellBook.AddSpell(spell);
            //Assert
            Assert.AreEqual(4, spellBook.Damage);
        }

        [Test]
        public void SpellBookProtectionMustBeZero()
        //Se prueba que el spellbook sea un elemento puramente ofensivo
        {
            Assert.AreEqual(0, spellBook.Protection);
        }

        [Test]
        public void AddSpellTest()
        //Se prueba que el metodo AddSpell agregue hechizos al spellbook
        {
            //Act
            spellBook.AddSpell(spell);
            spellBook.AddSpell(spell);
            //Assert
            Assert.AreEqual(2, spellBook.spells.Count);
        }

        [Test]
        public void RemoveSpellTest()
        //Se prueba que el metodo RemoveSpell remueva hechizos del spellbook
        {
            //Act
            spellBook.AddSpell(spell);
            spellBook.RemoveSpell(spell);
            //Assert
            Assert.AreEqual(0, spellBook.spells.Count);
        }

    }


}