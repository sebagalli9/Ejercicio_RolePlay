using System;

namespace Library
{
    /* La clase InvisibilityCloak cumple con el patron Expert, ya que es la clase experta en conocer el nombre 
    y poder de este item para poder cumplir con la responsabilidad de construir una capa invisible nueva.
    Cumple con el principio SRP ya que no hay más de una razón de cambio. */
    public class InvisibilityCloak
    {
        public string Name {get; }
        public int Damage {get; }
        public int Protection {get; }
        private string Power { get; }
        public bool MagicItem { get; }

        public InvisibilityCloak(string name, int damage, int protection, string power, bool magicItem)
        {
            this.Name = name;
            this.Damage = damage;
            this.Protection = protection;
            this.Power = power;
            this.MagicItem = magicItem;
        }
    }
}