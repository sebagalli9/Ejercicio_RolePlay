using System;
using System.Collections.Generic;

namespace Library
{
    //La clase Orc cumple con el patron Expert ya que:
    //- Es la clase experta en conocer el daño total de un Orco y con ello tiene la responsabilidad de ejecutar un ataque
    // 
    //La clase Orc no cumple con el principio SRP ya que tiene más de una razón de cambio, las cuales por ejemplo, pueden ser:
    //- Cambiar el comportamiento del ataque
    //- Cambiar el cómo se calcula el daño total de un Orco
    //- Cambiar el cómo se calcula la protección total de un Orco
    //- Cambiar el modo en que se recibe un ataque
    public class Orc
    {
        public string Name {get; }
        public int Damage {get; }
    
        private int initialHealth = 200;
        public int InitialHealth {get; set;}
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
        public GoldenShield GoldenShield {get; set;}
        public Sword Sword {get; set;}
        public string Role {get; }

        public Orc(string name, Sword sword, GoldenShield shield, string role)
        {
            this.Name = name;
            this.Damage = 20;
            this.Health = initialHealth;
            this.Sword = sword;
            this.GoldenShield = shield;
            this.Role = role;
        }

        //Metodo que cambia espada al orco.
        public void AttachSword(Sword sword)
        {
            this.Sword = sword;
        }

        //Metodo que elimina espada al orco.
        public void RemoveSword()
        {
            this.Sword = null;
        }

        //Metodo que cambia escudo al orco.
        public void AttachShield(GoldenShield shield)
        {
            this.GoldenShield = shield;
        }

        //Metodo que elimina escudo al orco.
        public void RemoveGoldenShield()
        {
            this.GoldenShield = null;
        }
        
        //En este metodo, se calcula el daño total.
        public int TotalDamage()
        {
            if (this.Sword != null)
            {
                return (this.Damage + this.Sword.Damage);
            }
            else
            {
                return this.Damage;
            }
           
        }
        //En este metodo, se calcula la protección total.
        public int TotalProtection()
        {
            int totalProtection;
            if (this.GoldenShield != null || this.Sword != null)
            {
                totalProtection = (this.GoldenShield.Protection + this.Sword.Protection);
            }
            else
            {
                totalProtection = 0;
            }
           return totalProtection;
        }

        public void ReceiveAttack(int damage)
        {
        
            if (this.GoldenShield != null || this.Sword != null)
            {
                if(damage <= (this.health + this.TotalProtection()))
                {
                    this.Health -= (damage - TotalProtection());
                }
                else
                {
                    this.Health = 0;
                }
            }
            else
            {
                this.Health -= damage;
            }
        }

        //Este metodo ataca a un enano
        /* public void Attack(Dwarf enemy)
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
        } */

        /* public void HealDwarf(Dwarf character)
        {
            character.Health = character.InitialHealth;
            Console.WriteLine($"{character.Name} ahora tiene {character.Health} de vida.");
        } */

    }
}