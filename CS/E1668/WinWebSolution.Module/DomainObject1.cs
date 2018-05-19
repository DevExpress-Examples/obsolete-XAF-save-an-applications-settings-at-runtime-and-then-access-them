using System;
using System.ComponentModel;

using DevExpress.Xpo;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace WinWebSolution.Module {
    [DefaultClassOptions]
    public class DomainObject1 : BaseObject {
        public DomainObject1(Session session) : base(session) { }
        public string StringProperty {
            get { return GlobalOptions.Instance.MyStringProperty; }
        }
        public int IntProperty {
            get { return GlobalOptions.Instance.MyIntProperty; }
        }
    }
}
