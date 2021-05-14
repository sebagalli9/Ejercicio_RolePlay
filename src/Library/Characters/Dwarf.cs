using System;
using System.Collections.Generic;

namespace Library
{
    /* La clase Dwarf cumple con el patron Expert ya que:
    - Es la clase experta en conocer el daño total de las instancias de la clase Dwarf
      y tambien tiene las responsabilidades de ejecutar un ataque y de recibir un ataque.
     
    La clase Dwarf no cumple con el principio SRP ya que tiene más de una razón de cambio, 
    las cuales por ejemplo, pueden ser:
    - Cambiar el comportamiento del ataque
    - Cambiar el cómo se calcula el daño total de un enano
    - Cambiar el cómo se calcula la protección total de un enano
    - Cambiar el modo en que se recibe un ataque */
    
    public class Dwarf
    {
        public string Name {get; }
        private int Damage {get; }
    
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

        public Axe Axe {get; set;}
        public Warhammer Warhammer {get; set;}
        public string Role {get;}

        public Dwarf(string name, Axe axe, Warhammer warhammer, string role)
        {
            this.Name = name;
            this.Damage = 25;
            this.Health = initialHealth;
            this.Axe = axe;
            this.Warhammer = warhammer;
            this.Role = role;
        }

        //Metodo para cambiar el hacha del enano.
        public void AttachAxe(Axe axe)
        {
            this.Axe = axe;
        }

        //Metodo que elimina el hacha del enano.
        public void RemoveAxe()
        {
            this.Axe = null;
        }

        //Metodo que cambia el martillo de guerra del enano.
        public void AttachWarhammer(Warhammer warhammer)
        {
            this.Warhammer = warhammer;
        }

        //Metodo que elimina el martillo de guerra del enano.
        public void RemoveWarhammer(Warhammer warhammer)
        {
            this.Warhammer = null;
        }
        
        //En este metodo, se calcula el daño total.
        public int TotalDamage()
        {
            if (this.Axe != null || this.Warhammer != null)
            {
                return (this.Damage + this.Axe.Damage + this.Warhammer.Damage);
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
            if (this.Warhammer != null || this.Axe != null)
            {
                totalProtection = (this.Warhammer.Protection + this.Axe.Protection);
            }
            else
            {
                totalProtection = 0;
            }
           return totalProtection;
        }
        
        //Este metodo ataca a un orco:
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
        
            if (this.Warhammer != null || this.Axe != null)
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

         //Método que incrementa la vida de un mago:
        public void HealWizard(Wizard character)
        {
            character.Health = character.InitialHealth;
            Console.WriteLine($"{character.Name} ahora tiene {character.Health} de vida.");
        } 
    }
}