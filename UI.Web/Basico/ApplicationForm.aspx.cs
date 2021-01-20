﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web.Basico
{
    public abstract partial class ApplicationForm : System.Web.UI.Page
    {
        public FormModes FormMode
        {
            get => (FormModes)ViewState["FormMode"];
            set => ViewState["FormMode"] = value;
        }

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        protected int selectID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set => ViewState["SelectedID"] = value;
        }

        protected bool isEntititySelected
        {
            get => selectID != 0;
        }
    }
}