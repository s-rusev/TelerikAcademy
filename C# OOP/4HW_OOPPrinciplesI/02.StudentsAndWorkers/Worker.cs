using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsAndWorkers
{
    public class Worker : Human
    {
        //property WeekSalary and WorkHoursPerDay and method MoneyPerHour() 
        #region private fields
        private decimal weekSalary;
        private ushort workHoursPerDay;
        #endregion

        #region constructors
        public Worker(decimal weekSalary, ushort workHoursPerDay, string firstName, string lastName)
            : base(firstName, lastName)
        {
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }
        #endregion

        #region properties
        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                this.weekSalary = value;
            }
        }

        public ushort WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                this.workHoursPerDay = value;
            }
        }
        #endregion

        #region methods

        public decimal MoneyPerHour() 
        {
            return this.weekSalary / (decimal)(this.workHoursPerDay * 5);
        }
        public override string ToString()
        {
            return string.Format("{0} {1} with weekSalary: {2:.##} and workHoursPerDay: {3}", 
                base.FirstName, base.LastName, weekSalary, workHoursPerDay);
        }

        #endregion
    }
}
