using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUWindowsFormFramework
{
    public class WindowsFormUtility
    {
        public static void SetListBinding(ComboBox lst, DataTable dtsource, string fieldname, DataTable dttarget)
        {
            lst.DataSource = dtsource;
            lst.DisplayMember = lst.Name.Substring(3);
            lst.ValueMember = fieldname;
            lst.DataBindings.Add("SelectedValue", dttarget, lst.ValueMember, true, DataSourceUpdateMode.OnPropertyChanged);
        }
        public static void SetControlBinding(Control ctrl, DataTable dt)
        {
            string propertyname = "";
            string controlname = ctrl.Name.ToLower();
            string columnname = controlname.Substring(3);
            if (controlname.StartsWith("txt") || controlname.StartsWith("lbl"))
            {
                propertyname = "Text";

            }
            else if (controlname.StartsWith("dtp"))
            {
                propertyname = "Value";
            }
            if (columnname != "" && propertyname != "")
            {
                ctrl.DataBindings.Add(propertyname, dt, columnname, true, DataSourceUpdateMode.OnPropertyChanged);

            }
        }
    }
}
