namespace BMIExample.Models.Containers
{
    public abstract class Identifiable
    {
        private long _id;

        protected Identifiable()
        {
            id = -1;
        }
        
        public long id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
    }
}
