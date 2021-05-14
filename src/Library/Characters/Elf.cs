using System;
using System.Collections.Generic;

namespace Library
{
    /* La clase Elf cumple con el patron Expert ya que:
    - Es la clase experta en conocer el daño total de las instancias de la clase Elf
      y tambien tiene las responsabilidades de ejecutar un ataque y de recibir un ataque.
     
    La clase Elf no cumple con el principio SRP ya que tiene más de una razón de cambio, 
    las cuales por ejemplo, pueden ser:
    - Cambiar el comportamiento del ataque
    - Cambiar el cómo se calcula el daño total de un Elfo
    - Cambiar el cómo se calcula la protección total de un Elfo
    - Cambiar el modo en que se recibe un ataque */
    
    public class Elf
    {
        public string Name {get; }
        public int Damage {get; }
    
        private int initialHealth = 150;
        public int InitialHealth {get;}
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

        public Bow Bow {get; set;}
        public InvisibilityCloak InvisibilityCloak {get; set;}
        public string Role {get; set;}

        public Elf(string name, Bow bow, InvisibilityCloak invisibilityCloak, string role)
        {
            this.Name = name;
            this.Damage = 20;
            this.Health = initialHealth;
            this.Bow = bow;
            this.InvisibilityCloak = invisibilityCloak;
            this.Role = role;
        }

        //Metodo que cambia arco al elfo.
        public void AttachBow(Bow bow)
        {
            this.Bow = bow;
        }

        //Metodo que elimina arco al elfo.
        public void RemoveBow()
        {
            this.Bow = null;
        }

        //Metodo que cambia la capa de invisibilidad al elfo.
        public void AttachInvisibilityCloak(InvisibilityCloak invisibilityCloak)
        {
            this.InvisibilityCloak = invisibilityCloak;
        }

        //Metodo que elimina capa de invisibilidad al elfo.
        public void RemoveInvisibilityCloak(InvisibilityCloak invisibilityCloak)
        {
            this.InvisibilityCloak = null;
        }

        //En este metodo, se calcula el daño total.
        public int TotalDamage()
        {
            if (this.Bow != null)
            {
                return (this.Damage + this.Bow.Damage);
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
            if (this.InvisibilityCloak != null || this.Bow != null)
            {
                totalProtection = (this.InvisibilityCloak.Protection + this.Bow.Protection);
            }
            else
            {
                totalProtection = 0;
            }
           return totalProtection;
        }
        //Este metodo ataca a un orco:
        /* public void Attack(Orc enemy)
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
        /* public void ReceiveAttack(int damage)
        {
        
            if (this.InvisibilityCloak != null || this.Bow != null)
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
        } */
        /* public void HealOrc(Orc character)
        {
            character.Health = character.InitialHealth;
            Console.WriteLine($"{character.Name} ahora tiene {character.Health} de vida.");
        } */

    }

}