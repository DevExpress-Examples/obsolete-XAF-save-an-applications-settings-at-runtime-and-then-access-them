using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Actions;

namespace WinWebSolution.Module {
    public class GlobalOptionsController : Controller {
        private SimpleAction changeOptions = null;
        public GlobalOptionsController()
            : base() {
            changeOptions = new SimpleAction(this, "ChangeOptions", PredefinedCategory.Tools);
            changeOptions.Execute += changeOptions_Execute;
            changeOptions.ImageName = "Attention";
        }
        void changeOptions_Execute(object sender, SimpleActionExecuteEventArgs e) {
            OnChangeOptionsExecute(e);
        }
        protected virtual void OnChangeOptionsExecute(SimpleActionExecuteEventArgs e) {
            DetailView dv = Application.CreateDetailView(ObjectSpaceInMemory.CreateNew(), GlobalOptions.Instance);
            dv.ViewEditMode = ViewEditMode.Edit;
            e.ShowViewParameters.CreatedView = dv;
            e.ShowViewParameters.TargetWindow = TargetWindow.NewModalWindow;
        }
    }
    [NonPersistent]
    public class GlobalOptions {
        private GlobalOptions() {
            myIntVar = 100;
            myStringVar = "A string option";
        }
        private static IValueManager<GlobalOptions> instanceManager;
        public static GlobalOptions Instance {
            get {
                if (instanceManager == null) {
                    instanceManager = ValueManager.GetValueManager<GlobalOptions>("GlobalOptions_GlobalOptions");
                }
                if (instanceManager.Value == null) {
                    instanceManager.Value = new GlobalOptions();
                }
                return instanceManager.Value;
            }
        }
        private int myIntVar;
        public int MyIntProperty {
            get { return myIntVar; }
            set { myIntVar = value; }
        }
        private string myStringVar;
        public string MyStringProperty {
            get { return myStringVar; }
            set { myStringVar = value; }
        }
    }
}