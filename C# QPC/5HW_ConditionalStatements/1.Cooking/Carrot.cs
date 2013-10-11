namespace Cooking
{
    using System;

    public class Carrot : Vegetable, ICookable
    {
        public Carrot(bool isPeeled, bool isRotten) :
            base(isPeeled, isRotten)
        {
        }
    }
}
