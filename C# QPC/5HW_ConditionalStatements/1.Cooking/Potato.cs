namespace Cooking
{
    using System;

    public class Potato : Vegetable, ICookable
    {
        public Potato(bool isPeeled, bool isRotten) :
            base(isPeeled, isRotten)
        {
        }

    }
}
