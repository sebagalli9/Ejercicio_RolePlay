using NUnit.Framework;
using Library;

namespace Test.Library
{
    public class DwarfTest
    {
        private Orc orc;
        private Sword sword;
        private GoldenShield goldenShield;
        private Dwarf dwarf;

        private Wizard wizard;
        private MagicStaff magicStaff;

        private SpellBook spellBook;
        private Spell spell;
        private Axe axe;
        private Warhammer warhammer;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            sword = new Sword("Espadon", 50, 0, "Corte Fugaz", false);
            goldenShield = new GoldenShield("Escudo Dorado", 0, 25, "Escudazo", false);
            orc = new Orc("Azog", sword, goldenShield, "Tanque");
            
            axe = new Axe("Hacha",50,5,"Corte Rapaz",false);
            warhammer = new Warhammer("Martillo de Guerra", 60, 10, "Martillazo", false);
            dwarf = new Dwarf("Throrn", axe, warhammer, "Luchador"); 

            magicStaff = new MagicStaff("Báculo ancestral", "Hace hechizos", true);
            spellBook = new SpellBook("Lumen", "Tiene hechizos", true);
            spell = new Spell("You shall not pass", "Genera una barrera", true);
            wizard = new Wizard("Gandalf", magicStaff, spellBook, "Mago");

        }

        [Test]
        public void NameAndRoleCannotBeNull()
        //Se prueba que el nombre y el rol del enano no sea nulo
        {   
            //Assert
            Assert.IsTrue(dwarf.Name!=null && dwarf.Role!=null);
        }

        [Test]
        public void DwarfCorrectlyInstanced()
        //Se prueba que el enano se instanció correctamente.
        {   
            //Assert
            Assert.IsNotNull(dwarf);
        }

        [Test]
        public void AttachAxeCheck()
        //Se prueba que el hacha sea añadida al enano.
        {   
            //Act
            //dwarf.AttachAxe(axe);
            //Assert
            Assert.IsNotNull(dwarf.Axe);
        }

        [Test]
        public void AttachWarhammer()
        //Se prueba que el martillo de guerra sea añadido correctamente al enano.
        {   
            //Assert
            Assert.IsNotNull(dwarf.Warhammer);
        }

        [Test]
        public void RemoveAxe()
        //Se prueba que el hacha se le quite correctamente al enano.
        {   
            //Act
            dwarf.RemoveAxe();

            //Assert
            Assert.IsNull(dwarf.Axe);
        }

        [Test]
        public void RemoveWarhammerTest()
        //Se prueba que el martillo de guerra se remueva del enano.
        {   
            //Act
            dwarf.RemoveWarhammer(warhammer);

            //Assert
            Assert.IsNull(dwarf.Warhammer);
        }

        [Test]
        public void TotalDamageCheck()
        //Se prueba que el valor total del damage del enano sea el esperado.
        {   
            int expectedTotalDamage = 135;

            //Act
            int calcTotalDamage = dwarf.TotalDamage();

            //Assert
            Assert.AreEqual(expectedTotalDamage, calcTotalDamage);
        }

        [Test]
        public void TotalProtectionCheck()
        //Se prueba que el valor total de la proteccion del enano sea el esperado.
        {
            int expectedProtection = 15;

            //Act
            int calcProtection = dwarf.TotalProtection();

            //Assert
            Assert.AreEqual(expectedProtection, calcProtection);
        }
        
        [Test]
        public void AtackCheckHealthEnemy()
        /*Se prueba que el valor total de la vida del enemigo sea el esperado
         despues de recibir un ataque por el enano.*/
        {   
            int expectedHealthLeftEnemy = 90;

            //Act
            dwarf.Attack(orc);

            //Assert
            Assert.AreEqual(expectedHealthLeftEnemy, orc.Health);
        }


        [Test]
        public void ReceiveAttackCheck()
        /*Se prueba que el valor total de la vida (con su protección) del enano
         sea el esperado despues de recibir un daño de ataque en especifico.*/
        {   
            int expectedDwarfHealth = 15;

            //Act
            dwarf.ReceiveAttack(100);
        
            //Assert
            Assert.AreEqual(expectedDwarfHealth, dwarf.Health);
        }
        [Test]
        public void HealWizardCheck()
        // Se comprueba que el el método para curar a un mago del enano funcione correctamente. //
        {
            //Act
            wizard.Health = 10;
            dwarf.HealWizard(wizard);
            int newHealth = wizard.Health;
            //Assert
            Assert.AreEqual(wizard.InitialHealth, newHealth);
        }
    }
}