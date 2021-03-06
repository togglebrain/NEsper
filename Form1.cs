﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using com.espertech.esper.client;

namespace NesperTest
{
    public delegate void PredictionChangedHandler(string prediction);
    public partial class Form1 : Form
    {
        static EPRuntime _runtime;
        List<string> eplStatements;
        MessageHandler mh;
        Configuration nesperConf;
        EPServiceProvider epService;

        public Form1()
        {
            InitializeComponent();

            InitializeEPLStatements();
            InitializeNesper();

            WireEPLStatements();

            txtRecd.Text = "Events: ";
        }

        private void WireEPLStatements()
        {
            foreach (string st in eplStatements)
            {
                EPStatement statement = epService.EPAdministrator.CreateEPL(st);
                statement.Subscriber = mh;
            }
        }

        private void InitializeNesper()
        {
            nesperConf = new Configuration();
            nesperConf.AddEventType("pay", typeof(PayloadSys));
            nesperConf.AddEventType("pay2", typeof(PayloadHuman));
            epService = EPServiceProviderManager.GetDefaultProvider(nesperConf);
            _runtime = epService.EPRuntime;
            mh = new MessageHandler();
            mh.UpdatePrediction += Predict;
        }

        private void InitializeEPLStatements()
        {
            eplStatements = new List<string>();
            //Minimize->Maximize->Scroll->coffee (recharging)
            eplStatements.Add("SELECT \"recharging\" FROM pattern [every pay(PayloadText=\"Maximize\") -> pay(PayloadText=\"Scroll\") -> pay2(PayloadText=\"Coffee\")]");
            //minimize->maximize->scroll (bored)
            eplStatements.Add("SELECT \"bored\" FROM pattern [every a=pay(PayloadText=\"Minimize\") -> every b=pay(PayloadText=\"Maximize\") -> every c=pay(PayloadText=\"Scroll\")]");
            //minimize->maximize->lock (gave up)
            eplStatements.Add("SELECT \"Gave up\" FROM pattern [every a=pay(PayloadText=\"Minimize\") -> every b=pay(PayloadText=\"Maximize\") -> every c=pay(PayloadText=\"Lock\")]");
            //scroll (on a quest)
            eplStatements.Add("SELECT \"On a quest\" FROM pattern [every a=pay(PayloadText=\"Scroll\")]");
            //blink->blink->stare->delete (angry)
            eplStatements.Add("SELECT \"Angry\" FROM pattern [every a=pay2(PayloadText=\"Blink\") -> b=pay2(PayloadText=\"Blink\") -> c=pay2(PayloadText=\"Stare\") -> d=pay(PayloadText=\"Delete\")]");
            //blink->blink->stare (wondering who wrote that code)
            eplStatements.Add("SELECT \"Wondering who wrote that code\" FROM pattern [every a=pay2(PayloadText=\"Blink\") -> b=pay2(PayloadText=\"Blink\") -> c=pay2(PayloadText=\"Stare\")]");
            //blink->blink (In disbelief)
            eplStatements.Add("SELECT \"In disbelief\" FROM pattern [every a=pay2(PayloadText=\"Blink\") -> b=pay2(PayloadText=\"Blink\")]");
        }

        public void Predict(string prediction)
        {
            lblPredict.Text = "programmer " + prediction;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _runtime.SendEvent(new PayloadSys() { PayloadText = (sender as ComboBox).SelectedItem.ToString() });
            txtRecd.Text += "->" + (sender as ComboBox).SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _runtime.SendEvent(new PayloadHuman() { PayloadText = (sender as ComboBox).SelectedItem.ToString() });
            txtRecd.Text += "->" + (sender as ComboBox).SelectedItem.ToString();
        }
    }

    internal class PayloadSys : Payload
    {
    }
    internal class PayloadHuman : Payload
    {
    }

    internal abstract class Payload
    {
        public string PayloadText { get; set; }
    }

    internal class MessageHandler
    {
        public event PredictionChangedHandler UpdatePrediction;

        public MessageHandler()
        {
        }
        public void Update(string prediction)
        {
            if (UpdatePrediction != null)
                UpdatePrediction(prediction);
        }
    }
}
