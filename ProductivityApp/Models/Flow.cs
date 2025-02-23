using System;
using System.Collections.Generic;
using System.Linq;

public class Flow {
  
    //Fields:: Setters and getters
    //unique id for filled flows
    public Guid Id {get;set;}
    public string name {set; get;}
    public string Description {get;set;}
    public Survey inputSurvey {set; get;}
    public Assignment[] assignments {set; get;}
    public List<Criteria> criteria {set; get;}
    public Destination[] destinations {set; get;}

    //Constructor
    public Flow() {

    }
    public Flow(string name, Survey survey) {
        this.name = name;
        this.inputSurvey = survey;
    }
    public Flow initializeFlow() {
        //copy templates
            //Get from database
        //copy forms
            //get from paths
        //return new Flow
        return new Flow();      //temporary
    }

    public Flow copyFromTemplate(Flow template) {
        Flow newFlow = new Flow();
        newFlow.name = template.name;
        newFlow.inputSurvey = template.inputSurvey;
        newFlow.assignments = template.assignments;
        newFlow.criteria = template.criteria;
        newFlow.destinations = template.destinations;
        return newFlow;
    }
    public bool checkFilter(Filter filter) {

        foreach (Criteria criterion in this.criteria)
        {   
            if ( criterion.Category == filter.name) {
                //find the answer's name that matches the filter's value and determine if it is selected
                var answer = criterion.SelectedValue;
                
                //if answer is null, we didn't find a match, don't apply the filter
                if (!String.IsNullOrEmpty(answer))
                {
                    return true;
                }
                else
                {
                    return false;                    
                }
                
            }
        }
        return false;
    }
}