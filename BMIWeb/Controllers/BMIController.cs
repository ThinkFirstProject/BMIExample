using System;
using System.Web.Mvc;
using System.Web.Routing;
using BMI;
using BMIWeb.DAL;
using BMIWeb.Models.Def;
using BMIWeb.Models.WrapperModels;
using Measurement = BMI.Containers.Measurement;
using Person = BMI.Person;

namespace BMIWeb.Controllers
{
    public class BMIController : Controller
    {
        private readonly IBMIDAL _dal;
        private readonly PersonManager _pm;

        public BMIController(IBMIDAL DAL)
        {
            _dal = DAL;
            _pm = PersonManager.instance;
        }

        public ActionResult Overview()
        {
            ViewBag.Title = "Persons";
            ViewBag.personsList = _dal.getSocialSecurityNumberList();

            return View();
        }

        public ActionResult ViewDetail(String sosecNr)
        {
            ViewBag.Title = "View Person";
            ViewBag.Message = "";

            PersonWrapper mdl = new PersonWrapper();
            mdl.state = StateDef.ModelState.View;

            _pm.activePerson = _dal.getPerson(sosecNr);
            mdl.loadPersonData(_pm.activePerson);
            
            return View(mdl);
        }

        [HttpPost]
        public ActionResult ViewDetail(PersonWrapper data)
        {
            data.length = "0";
            data.weight = "0";
            data.date = new DateTime(1,1,1);
            return RedirectToAction("AddMeasurementBis", data);
        }

        public ActionResult NewPerson()
        {
            ViewBag.Title = "New Person";
            ViewBag.Message = "";

            PersonWrapper mdl = new PersonWrapper();
            mdl.state = StateDef.ModelState.New;

            return View(mdl);
        }

        public ActionResult AddMeasurementBis(PersonWrapper dataModel)
        {
            ViewBag.Title = "New Measurement";
            ViewBag.Message = "";
            
            PersonWrapper mdl = new PersonWrapper
            {
                state = StateDef.ModelState.Measurement,
                socialSecurityNumber = dataModel.socialSecurityNumber
            };

            return View("~/Views/BMI/AddMeasurement.cshtml", mdl);
        }

        [HttpPost]
        public ActionResult AddMeasurement(PersonWrapper data)
        {
            ViewBag.Title = "New Measurement";

             try
            {
                if (data != null)
                {
                    if (ModelState.IsValid)
                    {
                        Measurement newMeasurement = new Measurement(int.Parse(data.length), int.Parse(data.weight),data.date);

                        _pm.activePerson.addMeasurement(newMeasurement);
                        _dal.addMeasurement(_pm.activePerson.socialSecurityNumber, newMeasurement);
                        ViewBag.Message = "New measurement for person with social security number " +
                                          data.socialSecurityNumber + " added";
                    }

                    return View(data);   
                }

                ViewBag.Title = "Error";
                ViewBag.Message = "Data error:No data was passed to the server. Data was 'null'";
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = ex.Message;
            }

             return View(data);   
        }

        [HttpPost]
        public ActionResult NewPerson(PersonWrapper data)
        {
            ViewBag.Title = "New Person";
            
            try
            {
                if (data != null)
                {
                    if (ModelState.IsValid)
                    {
                        Measurement firstMeasurement = new Measurement(int.Parse(data.length), int.Parse(data.weight), data.date);
                        Person newPerson = new Person(data.socialSecurityNumber, data.birthDate, data.gender,
                            firstMeasurement);

                        _dal.addPerson(newPerson);

                        ViewBag.Message = "New person with social security number " + data.socialSecurityNumber +
                                          " added";
                    }
                    else
                    {
                        ViewBag.Title = "Error";    
                    }
                    
                    return View(data);   
                }

                ViewBag.Message = "Data error:No data was passed to the server. Data was 'null'";
            }
            catch (Exception ex)
            {
                ViewBag.Title = "Error";
                ViewBag.Message = ex.Message;
            }

            return View(data); 
        }
    }
}
