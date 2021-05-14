using System;

namespace Library
{

    //La clase Spell cumple con el patron Expert, ya que es la clase experta en conocer el nombre y el poder de cada hechizo
    //para poder cumplir con la responsabilidad de construir un hechizo nuevo.
    //Cumple con el principio SRP ya que no hay más de una razón de cambio. 

    public class Spell
    {
        public string Name{get; set;}
        public string Power{get; set;}

        public bool MagicItem {get; }

        public Spell(string name, string power, bool magicItem)
        {
            this.Name = name;
            this.Power = power;
            this.MagicItem = magicItem;
        }
    }

}