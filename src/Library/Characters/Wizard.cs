using System;
using System.Collections.Generic;

namespace Library
{
    //La clase Wizard cumple con el patron Expert ya que:
    //- Es la clase experta en conocer el daño total de un Mago y con ello tiene la responsabilidad de ejecutar un ataque
    // 
    //La clase Wizard no cumple con el principio SRP ya que tiene más de una razón de cambio, las cuales por ejemplo, pueden ser:
    //- Cambiar el comportamiento del ataque
    //- Cambiar el comportamiento de la cura
    //- Cambiar el cómo se calcula el daño total de un Wizard
    //- Cambiar el modo en que se recibe un ataque

    public class Wizard
    {
        public string Name{get; }

        public int Damage{get; }
       
        private int initialHealth = 100; 
        public int InitialHealth {get; }
        private int health;
        public int Health
        {
            get{return health;}
            set
            {
                if(value < 0)
                {
                    health = 0;
                    Console.WriteLine($"{this.Name} no puede tener puntos de vida negativos.");
                }
                else
                {
                    health = value;
                }
            }
        }

        public MagicStaff MagicStaff{get;set;}
        public SpellBook SpellBook{get;set;}
        public string Role{get; }

        public Wizard(string name, MagicStaff magicStaff, SpellBook spellBook, string role)
        {
            this.Name = name;
            this.Damage = 0;
            this.Health = initialHealth;
            this.MagicStaff = magicStaff;
            this.SpellBook = spellBook;
            this.Role = role;
        }

        public void Attack(Orc enemy)
        {
            Console.WriteLine($"{this.Name} ataca a {enemy.Name}");
            enemy.ReceiveAttack(this.TotalDamage());

            if(enemy.Health <= 0)
            {
                Console.WriteLine($"{enemy.Name} fue asesinado.");
            }
            else
            {
                Console.WriteLine($"{enemy.Name} tiene {enemy.Health} de vida.");
            }
        }

        public void ReceiveAttack(int damage)
        {
            if(damage <= (this.health + this.TotalProtection()))
            {
                this.Health -= (damage - this.TotalProtection());
            }
            else
            {
                this.Health = 0;
            }  
        }

        public void HealOrc(Orc character)
        {
            character.Health = character.InitialHealth;
            Console.WriteLine($"{character.Name} ahora tiene {character.Health} de vida.");
        }

        public int TotalDamage()
        {
            return (MagicStaff.Damage + SpellBook.Damage + this.Damage);
        }

        public int TotalProtection()
        {
            return (MagicStaff.Protection + SpellBook.Protection);
        }

        public void LearnSpell(Spell spell)
        {
            this.SpellBook.AddSpell(spell);
            Console.WriteLine($"{this.Name} ha aprendido el hechizo {spell.Name}");
        }

        public void ForgetSpell(Spell spell)
        {
            this.SpellBook.RemoveSpell(spell);
        }
    }
}