namespace BMI
{
    public class PersonManager
    {
        private Person _activePerson;
        private static PersonManager _instance;

        private PersonManager()
        {
           
        }

        public Person activePerson
        {
            get
            {
                return _activePerson;
            }
            set
            {
                _activePerson = value;
            }
        }

        public static PersonManager instance
        {
            get
            {
                return _instance ?? (_instance = new PersonManager());
            }
        }
    }
}
