using System;

namespace Library
{
    /* La clase Bow cumple con el patron Expert, ya que es la clase experta en conocer el nombre 
    y poder de este item para poder cumplir con la responsabilidad de construir un nuevo arco.
    Cumple con el principio SRP ya que no hay más de una razón de cambio. */

    public class Bow
    {
        public string Name{get; }
        public int Damage{get; }
        public int Protection{get; }
        private string Power{get; }
        public bool MagicItem { get; set;}

        public Bow(string name, int damage, int protection, string power, bool magicItem)
        {
            this.Name = name;
            this.Damage = damage;
            this.Protection = protection;
            this.Power = power;
            this.MagicItem = magicItem;
        }
    }
    
}