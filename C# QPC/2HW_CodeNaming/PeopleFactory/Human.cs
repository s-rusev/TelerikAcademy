namespace PeopleFactory
{
    public class Human
    {
        private Sex sex;
        private string fullName;
        private int age;

        public Human() 
        {
        }

        public Human(Sex sex, string fullName, int age)
        {
            this.Sex = sex;
            this.FullName = fullName;
            this.Age = age;
        }

        public override string ToString()
        {
            return string.Format("FullName: {0}, age: {1}, sex {2}", fullName, age , sex);
        }

        public Sex Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
    }
}