using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            GoldenShield goldenShield = new GoldenShield ("GoldenShield", 0, 25,"Escudo Protector",false);
            Sword sword1 = new Sword ("Katana", 50, 0,"Corte Fugaz",false);
            Orc orc = new Orc ("Grom", sword1, goldenShield, "Tanque");
            Sword sword2 = new Sword ("Excalibur", 10, 0,"Corte Diagonal",false);
            orc.AttachSword(sword2);

            InvisibilityCloak invisibilityCloak = new InvisibilityCloak ("Capa maxima", 0, 85, "Invisibilidad",false);
            Bow bow1 = new Bow ("Arco gigante", 75, 5,"Tira fuego",false);
            Elf elf = new Elf ("Frank", bow1, invisibilityCloak, "Escurridizo");
            Bow bow2 = new Bow ("Arco", 60, 5,"Automatico",false);
            elf.AttachBow(bow2); 
                    
            MagicStaff magicStaff = new MagicStaff("Varita", "Es mágica(?)", true);
            SpellBook spellBook = new SpellBook("Libro de Hechizos", "Tiene hechizos(?)", true);
            Wizard wizard = new Wizard("Harry", magicStaff, spellBook, "Support");
            Spell spell = new Spell("Lumos", "La varita enciende luz", true);
            wizard.LearnSpell(spell);

            Axe axe1 = new Axe("El ejecutor", 65, 5, "Hacha giratoria", false);
            Axe axe2 = new Axe("Verdugo", 70, 0, "Juicio final", false);
            Warhammer warhammer = new Warhammer("Mjölnir", 90, 10, "Aplastar y machacar", false);
            Dwarf dwarf = new Dwarf("Thorin", axe1, warhammer, "Luchador");
            dwarf.AttachAxe(axe2);
       
            wizard.Attack(orc);
            orc.Attack(dwarf);
            wizard.HealOrc(orc);
            dwarf.Attack(orc);
            dwarf.HealWizard(wizard);
            elf.Attack(orc);
        }
    }
}