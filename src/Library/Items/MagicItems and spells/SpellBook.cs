using System;
using System.Collections.Generic;

namespace Library
{

    //La clase SpellBook cumple con el patron Expert ya que es la clase experta en conocer el contenido de cada libro
    //para poder cumplir con la responsabilidad de agregar o sacar hechizos. 
    //Cumple con el principio SRP ya que la única razón de cambio seria cambiar la forma en la que se agregan o sacan hechizos.

    public class SpellBook
    {
        public string Name {get;set;}
        public int Damage {get;set;}
        public int Protection {get;set;}
        public string Power {get;set;}

        public bool MagicItem { get;}
        public List<Spell> spells;

        public SpellBook(string name, string power, bool magicItem)
        {
            this.Name = name;
            this.Damage = 0;                    //El daño inicial es cero pero se actualiza cada vez que se agrega un hechizo nuevo (o se saca uno)
            this.Protection = 0;
            this.Power = power;
            this.MagicItem = magicItem;
            this.spells = new List<Spell>();
        }

        public void AddSpell(Spell spell)
        {
            this.spells.Add(spell);
            this.Damage = this.spells.Count;
            //Console.WriteLine($"El libro ahora tiene {this.Damage} puntos de daño");
        }

        public void RemoveSpell(Spell spell)
        {
            this.spells.Remove(spell);
            this.Damage = this.spells.Count;
        }

    }
}