using NUnit.Framework;
using Library;

namespace Test.Library
{
    public class WizardTest
    {
        private Wizard wizard;
        private MagicStaff magicStaff;

        private SpellBook spellBook;
        private Spell spell;

        private GoldenShield goldenShield;

        private Sword sword;

        private Orc orc;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            magicStaff = new MagicStaff("Varita", "Hace hechizos", true);
            spellBook = new SpellBook("Libro", "Tiene hechizos", true);
            spell = new Spell("Wingardium Leviosa", "Hace levitar objetos", true);
            wizard = new Wizard("Hermione", magicStaff, spellBook, "Mago");

            goldenShield = new GoldenShield ("GoldenShield", 0, 30,"Escudo Protector",false);
            sword = new Sword ("Katana", 50, 0,"Corte Fugaz",false);
            orc = new Orc ("Grom", sword, goldenShield, "Tanque");  
        }

        [Test]
        public void NameCannotBeNull()
        //Se prueba que el nombre del mago no sea null
        {
            Assert.IsNotNull(wizard.Name);
        }

        [Test]
        public void NameMustBeString()
        //Se prueba que el nombre del mago sea del tipo string
        {
            Assert.IsInstanceOf(typeof(string), wizard.Name);
        }

        [Test]
        public void RoleCannotBeNull()
        //Se prueba que el rol del mago no sea null
        {
            Assert.IsNotNull(wizard.Role);
        }

        [Test]
        public void RoleMustBeString()
        //Se prueba que el rol del mago sea del tipo string
        {
            Assert.IsInstanceOf(typeof(string), wizard.Role);
        }

        [Test]
        public void MagicStaffMustBeMagicStaffInstance()
        //Se prueba que el atributo magicStaff del mago contenga una instancia de la clase MagicStaff
        //y por tanto solamente se pueda equipar un item del tipo MagicStaff
        {
            Assert.IsInstanceOf(typeof(MagicStaff), wizard.MagicStaff);
        }

        [Test]
        public void MagicStaffCannotBeNull()
        //Se prueba que el atributo magicStaff no sea null
        {
            Assert.IsNotNull(wizard.MagicStaff);
        }

        [Test]
        public void SpellBookMustBeSpellBookInstance()
        //Se prueba que el atributo spellBook del mago contenga una instancia de la clase SpellBook
        //y por tanto solamente se pueda equipar un item del tipo SpellBook
        {
            Assert.IsInstanceOf(typeof(SpellBook), wizard.SpellBook);
        }

        [Test]
        public void SpellBookCannotBeNull()
        //Se prueba que atributo spellBook no sea null
        {
            Assert.IsNotNull(wizard.SpellBook);
        }

        [Test]
        public void AttackTest()
        //Se prueba el metodo de ataque en un orco
        {
            //Act
            wizard.LearnSpell(spell);
            wizard.Attack(orc);

            //Assert
            Assert.AreEqual(179, orc.Health);

        }

        [Test]
        public void ReceiveAttackTest()
        //Se prueba el metodo para recibir un ataque
        {
            //Act
            wizard.ReceiveAttack(10);
            //Assert
            Assert.AreEqual(90, wizard.Health);
        }


        [Test]
        public void InitialWizardDamageMustBeZero()
        //Se prueba que el daño propio del mago es 0 puntos
        {
            Assert.AreEqual(0, wizard.Damage);
        }

        [Test]
        public void CorrectTotalDamageCalculation()
        //Se prueba que el calculo del daño total sea correcto
        {
            //Act
            wizard.LearnSpell(spell);
            wizard.LearnSpell(spell);
            //Assert
            Assert.AreEqual(52, wizard.TotalDamage());
        }

        [Test]
        public void TotalDamageMustReturnInt()
        //Se prueba que el metodo TotalDamage devuelva un valor del tipo int
        {
            Assert.IsInstanceOf(typeof(int), wizard.TotalDamage());
        }

        [Test]
        public void CorrectTotalProtectionCalculation()
        //Se prueba que el calculo de la proteccion total sea correcto
        {
            Assert.AreEqual(0, wizard.TotalProtection());
        }

        [Test]
        //Se prueba que el metodo TotalProtection devuelva un valor del tipo int
        public void TotalProtectionMustReturnInt()
        {
            Assert.IsInstanceOf(typeof(int), wizard.TotalProtection());
        }

        [Test]
        public void LearnSpellTest()
        //Se prueba que el hechizo aprendido se añada al libro
        {
            //Act
            wizard.LearnSpell(spell);
            //Assert
            Assert.True(spellBook.spells.Contains(spell));
        }

        [Test]
        public void RemoveSpellTest()
        //Se prueba que el hechizo olvidado se retire del libro
        {
            //Act
            wizard.LearnSpell(spell);
            wizard.ForgetSpell(spell);
            //Assert
            Assert.False(spellBook.spells.Contains(spell));
        }
    }
}