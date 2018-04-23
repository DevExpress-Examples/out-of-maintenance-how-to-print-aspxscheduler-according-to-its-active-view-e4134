using System;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxScheduler;

public partial class DefaultObjectDataSources : System.Web.UI.UserControl {
    string sessionName = "CustomEvents";
    Random rnd = new Random();


    public ObjectDataSource AppointmentDataSource { get { return objAppointmentDataSource; } }
    public ObjectDataSource ResourceDataSource { get { return objResourceDataSource; } }
    public string SessionName { get { return sessionName; } set { sessionName = value; } }

    protected void Page_Load(object sender, EventArgs e) {

    }
    public void AttachTo(ASPxScheduler control) {
        control.AppointmentDataSource = this.AppointmentDataSource;
        control.ResourceDataSource = this.ResourceDataSource;
        control.DataBind();
    }
    protected void resourcesDataSource_ObjectCreated(object sender, ObjectDataSourceEventArgs e) {
        CustomResourceList resources = GetCustomResources();
        e.ObjectInstance = new CustomResourceDataSource(resources);
    }
    protected void appointmentsDataSource_ObjectCreated(object sender, ObjectDataSourceEventArgs e) {
        CustomEventList events = GetCustomEvents();
        e.ObjectInstance = new CustomEventDataSource(events);
    }
    object[] resourceIdList = { 0, 1, 2 };
    string[] resourceCaptionList = { "Sarah Brighton", "Ryan Fischer", "Andrew Miller" };
    CustomResourceList GetCustomResources() {
        string sessionName = "R" + SessionName;
        CustomResourceList resources = Session[sessionName] as CustomResourceList;
        if(resources != null)
            return resources;
        resources = new CustomResourceList();
        PopulateResourceList(resources);
        Session[sessionName] = resources;
        return resources;
    }
    void PopulateResourceList(CustomResourceList resources) {
        int count = resourceIdList.Length;
        for(int i = 0; i < count; i++) {
            CustomResource resource = new CustomResource();
            resource.Id = resourceIdList[i];
            resource.Caption = resourceCaptionList[i];
            resources.Add(resource);
        }
    }
    protected CustomEventList GetCustomEvents() {
        string sessionName = "A" + SessionName;
        CustomEventList events = Session[sessionName] as CustomEventList;
        if(events != null)
            return events;
        events = new CustomEventList();
        PopulateEventList(events);
        Session[sessionName] = events;
        return events;
    }
    protected void PopulateEventList(CustomEventList eventList) {
        int count = this.resourceIdList.Length;
        for(int i = 0; i < count; i++) {
            object resourceId = this.resourceIdList[i];
            string resourceCaption = this.resourceCaptionList[i];
            eventList.Add(CreateEvent(resourceId, resourceCaption + " meeting", 2, 2));
            eventList.Add(CreateEvent(resourceId, resourceCaption + " travel", 3, 0));
            eventList.Add(CreateEvent(resourceId, resourceCaption + " time off", 0, 1));
        }
    }
    CustomEvent CreateEvent(object resourceId, string subject, int status, int label) {
        CustomEvent customEvent = new CustomEvent();
        customEvent.Subject = subject;
        customEvent.OwnerId = resourceId;
        int rangeInHours = 48;
        customEvent.StartTime = DateTime.Today + TimeSpan.FromHours(rnd.Next(0, rangeInHours));
        customEvent.EndTime = customEvent.StartTime + TimeSpan.FromHours(rnd.Next(0, rangeInHours / 8));
        customEvent.Status = status;
        customEvent.Label = label;
        customEvent.Id = "ev" + customEvent.GetHashCode();
        return customEvent;
    }
    public void Clear() {
        CustomEventList events = new CustomEventList();
        Session[SessionName] = events;
    }
}
