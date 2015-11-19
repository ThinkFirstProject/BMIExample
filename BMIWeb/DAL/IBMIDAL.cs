using System;
using System.Collections.Generic;

namespace BMIWeb.DAL
{
    public interface IBMIDAL
    {
        BMI.Person getPerson(String socialSecurityNumber);
        Boolean addPerson(BMI.Person newPerson);
        Boolean addMeasurement(String socialSecurityNumber, BMI.Containers.Measurement newMeasurement);
        List<String> getSocialSecurityNumberList();
    }
}
