using NUnit.Framework;
using Library;

namespace Test.Library
{
    public class OrcTest
    {
        private Orc orc;
        private Sword sword;
        private GoldenShield goldenShield;
        private Dwarf dwarf;
        private Axe axe;
        private Warhammer warhammer;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            sword = new Sword("Espadon",50,0,"Corte Fugaz",false);
            goldenShield = new GoldenShield("Escudo Dorado",0,25,"Escudazo",false);
            orc = new Orc("Thor",sword,goldenShield,"Tanque");
            axe = new Axe("Hacha",50,0,"Corte Rapaz",false);
            warhammer = new Warhammer("Martillo de Guerra",60,0,"Martillazo",false);
            dwarf = new Dwarf("Wagner",axe,warhammer,"Apoyo"); 
        }

        [Test]
        public void NameAndRoleCannotBeNull()
        //Se prueba que el nombre y el rol del orco que no sea nulo
        {   
            //Assert
            Assert.IsTrue(orc.Name!=null && orc.Role!=null);
        }

        [Test]
        public void OrcCorrectlyInstanced()
        //Se prueba que orco se instanció correctamente.
        {   
            //Assert
            Assert.IsNotNull(orc);
        }

        [Test]
        public void AttachSwordCheck()
        //Se prueba que la espada se attach al orco.
        {   
            //Assert
            Assert.IsNotNull(orc.Sword);
        }

        [Test]
        public void AttachShield()
        //Se prueba que el escudo se attach al orco.
        {   
            //Assert
            Assert.IsNotNull(orc.GoldenShield);
        }

        [Test]
        public void RemoveSword()
        //Se prueba que la espada se remueva del orco.
        {   
            //Act
            orc.RemoveSword();

            //Assert
            Assert.IsNull(orc.Sword);
        }

        [Test]
        public void RemoveGoldenShield()
        //Se prueba que la escudo se remueva del orco.
        {   
            //Act
            orc.RemoveGoldenShield();

            //Assert
            Assert.IsNull(orc.GoldenShield);
        }

        [Test]
        public void TotalDamageCheck()
        //Se prueba que el valor total del damage del orco sea el esperado.
        {   
            //Act

            int expectedTotalDamage = 70;

            int calcTotalDamage = orc.TotalDamage();

            //Assert
            Assert.AreEqual(expectedTotalDamage, calcTotalDamage);
        }

        [Test]
        public void TotalProtectionCheck()
        //Se prueba que el valor total de la proteccion del orco sea el esperado.
        {
            //Act
            int expectedProtection = 25;

            int calcProtection = orc.TotalProtection();

            //Assert
            Assert.AreEqual(expectedProtection, calcProtection);
        }

        [Test]
        public void AtackCheckHealthEnemy()
        //Se prueba que el valor total de la vida del enemigo sea el esperado despues de recibir un ataque por el orco.
        {  
            //Act 
            int expectedHealthLeftEnemy = 30;

            orc.Attack(dwarf);

            //Assert
            Assert.AreEqual(expectedHealthLeftEnemy,dwarf.Health);
        }

        [Test]
        public void ReceiveAttackCheck()
        //Se prueba que el valor total de la vida (con su protección) orco sea el esperado despues de recibir un dañp ataque en especifico.
        {   
            //Act
            int expectedOrcHealth = 125;

            orc.ReceiveAttack(100);
        
            //Assert
            Assert.AreEqual(expectedOrcHealth,orc.Health);
        }

        [Test]
        public void HealDwarfCheck()
        // Se comprueba que el el método para curar a un mago del enano funcione correctamente. //

        {
            //Act
            dwarf.Health = 10;
            orc.HealDwarf(dwarf);
            int newHealth = dwarf.Health;
            //Assert
            Assert.AreEqual(dwarf.InitialHealth, newHealth);
        }
    }
}