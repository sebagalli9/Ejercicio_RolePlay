using NUnit.Framework;
using Library;

namespace Test.Library
{
    public class ElfTest
    {
        private Orc orc;
        private Sword sword;
        private GoldenShield goldenShield;

        private Elf elf;
        private Bow bow;
        private InvisibilityCloak invisibilityCloak;


        [SetUp]
        public void SetUp()
        {
            //Arrange
            sword = new Sword("Espadon",50,0,"Corte Fugaz",false);
            goldenShield = new GoldenShield("Escudo Dorado",0,25,"Escudazo",false);
            orc = new Orc("Thor",sword,goldenShield,"Tanque");
            
            bow = new Bow("Arco gigante",60,5,"Tira fuego",false);
            invisibilityCloak = new InvisibilityCloak("Capa magica",0,80,"Invisible",false);
            elf = new Elf("Ralf",bow,invisibilityCloak,"Escurridizo");
        }

        [Test]
        public void NameAndRoleCannotBeNull()
        //Se prueba que el nombre y el rol del elfo no sea nulo
        {   
            //Assert
            Assert.IsTrue(elf.Name!=null && elf.Role!=null);
        }

        [Test]
        public void ElfCorrectlyInstanced()
        //Se prueba que el elfo se instanció correctamente.
        {   
            //Assert
            Assert.IsNotNull(elf);
        }

        [Test]
        public void AttachBowCheck()
        //Se prueba que el arco sea añadido al elfo.
        {   
            //Assert
            Assert.IsNotNull(elf.Bow);
        }

        [Test]
        public void AttachInvisibilityCloak()
        //Se prueba que la capa de invisibilidad sea añadida correctamente al elfo.
        {   
            //Assert
            Assert.IsNotNull(elf.InvisibilityCloak);
        }

        [Test]
        public void RemoveBow()
        //Se prueba que el arco se le quite correctamente al elfo.
        {   
            //Act
            elf.RemoveBow();

            //Assert
            Assert.IsNull(elf.Bow);
        }

        [Test]
        public void RemoveInvisibilityCloakTest()
        //Se prueba que la capa se remueva del elfo correctamente.
        {   
            //Act
            elf.RemoveInvisibilityCloak(invisibilityCloak);

            //Assert
            Assert.IsNull(elf.InvisibilityCloak);
        }

        [Test]
        public void TotalDamageCheck()
        //Se prueba que el valor total del damage del elfo sea el esperado.
        {   
            int expectedTotalDamage = 80;

            //Act
            int calcTotalDamage = elf.TotalDamage();

            //Assert
            Assert.AreEqual(expectedTotalDamage, calcTotalDamage);
        }

        [Test]
        public void TotalProtectionCheck()
        //Se prueba que el valor total de la proteccion del enano sea el esperado.
        {
            int expectedProtection = 85;

            //Act
            int calcProtection = elf.TotalProtection();

            //Assert
            Assert.AreEqual(expectedProtection, calcProtection);
        }

        [Test]
        public void AtackCheckHealthEnemy()
        /*Se prueba que el valor total de la vida del enemigo sea el esperado
         despues de recibir un ataque por el elfo.*/
        {   
            int expectedHealthLeftEnemy = 145;

            //Act
            elf.Attack(orc);

            //Assert
            Assert.AreEqual(expectedHealthLeftEnemy, orc.Health);
        }

        [Test]
        public void ReceiveAttackCheck()
        /*Se prueba que el valor total de la vida (con su protección) del elfo
         sea el esperado despues de recibir un daño de ataque en especifico.*/
        {   
            int expectedElfHealth = 100;

            //Act
            elf.ReceiveAttack(135);
        
            //Assert
            Assert.AreEqual(expectedElfHealth, elf.Health);
        }
        [Test]
        public void HealOrcCheck()
        // Se comprueba que el el método para curar a un orco del elfo funcione correctamente. //
        {
            //Act
            orc.Health = 10;
            elf.HealOrc(orc);
            int newHealth = orc.Health;
            //Assert
            Assert.AreEqual(orc.InitialHealth, newHealth);
        }
    }
}