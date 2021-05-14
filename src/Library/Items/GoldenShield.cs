using System;

namespace Library
{
    //La clase GoldenShield cumple con el patron Expert, ya que es la clase experta en conocer el nombre y el poder de este item
    //para poder cumplir con la responsabilidad de construir un escudo nuevo.
    //Cumple con el principio SRP ya que no hay más de una razón de cambio.
    public class GoldenShield
    {
        public string Name {get; }
        public int Damage {get; }
        public int Protection {get; }

        private string Power { get; }

        public bool MagicItem { get; }

        public GoldenShield(string name, int damage, int protection, string power, bool magicItem)
        {
            this.Name = name;
            this.Damage = damage;
            this.Protection = protection;
            this.Power = power;
            this.MagicItem = magicItem;
        }
    }
}