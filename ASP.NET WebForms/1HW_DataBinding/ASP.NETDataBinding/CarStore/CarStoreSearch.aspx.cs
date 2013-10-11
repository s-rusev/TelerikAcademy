using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarStore
{
    public partial class CarStoreSearch : System.Web.UI.Page
    {
        private int index = 0;

        private static List<string> BMWModels = new List<string>()
        {
            "x6", "x5", "M4 Coupe"
        };

        private static List<string> AudiModels = new List<string>()
        {
            "a4", "a6", "s6"
        };

        private static List<string> FordModels = new List<string>()
        {
            "Focus", "Mondeo", "Orion", "Fiesta"
        };

        private List<Producer> producers = new List<Producer>() 
        { 
            new Producer("BMW", BMWModels),
            new Producer("Audi", AudiModels),
            new Producer("Ford", FordModels)
        };

        private static List<Extra> extrasList = new List<Extra>()
        {
            new Extra("Navigation system"),
            new Extra("Parking Sensors"), 
            new Extra("Sunroof"),
            new Extra("Central Locking")
        };

        private List<string> engines = new List<string>() 
        {
            "diesel", "electric", "gas"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }
            this.ProducerDropDown.DataSource = producers.Select(x => x.Name);
            this.ModelDropDown.DataSource = producers[index].Models;
            this.CheckBoxListExtras.DataSource = extrasList.Select(x=>x.Name);
            this.RadioButtonsListEngines.DataSource = engines;

            ProducerDropDown.DataBind();
            ModelDropDown.DataBind();
            CheckBoxListExtras.DataBind();
            RadioButtonsListEngines.DataBind();

            ProducerDropDown.SelectedIndex = 0;
        }

        protected void Change_Models(object sender, EventArgs e)
        {
            index = this.ProducerDropDown.SelectedIndex;
            this.ModelDropDown.DataSource = producers[index].Models;
            this.ModelDropDown.DataBind();
        }

        protected void Show_Info(object sender, EventArgs e)
        {
            List<string> choosenExtras = new List<string>();
            for (int i = 0; i < this.CheckBoxListExtras.Items.Count; i++)
            {
                if (CheckBoxListExtras.Items[i].Selected)
                {
                    choosenExtras.Add(CheckBoxListExtras.Items[i].Text.ToString());
                }
            }
            SubmitInfo.Text = "Producer:" + ProducerDropDown.SelectedValue + " Model: " + ModelDropDown.SelectedValue +
               "Engine: " + RadioButtonsListEngines.SelectedValue + " choosen extras: ";
            foreach (var choosenExtra in choosenExtras)
            {
                SubmitInfo.Text += choosenExtra + " ";
            }
        }
    }
}