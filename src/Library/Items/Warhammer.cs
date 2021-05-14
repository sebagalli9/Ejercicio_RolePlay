using System;

namespace Library
{

    //La clase MagicStaff cumple con el patron Expert ya que es la clase experta en conocer la información necesaria para crear una instancia de MagicStaff
    //Cumple con el principio SRP ya que no hay más de una razón de cambio.

    public class Warhammer
    {
        public string Name{get;}
        public int Damage{get;}
        public int Protection{get;}
        private string Power{get;}
        public bool MagicItem { get;}


        public Warhammer(string name, int damage, int protection, string power, bool magicItem)
        {
            this.Name = name;
            this.Damage = damage;
            this.Protection = protection;
            this.Power = power;
            this.MagicItem = magicItem;
        }
    }
}