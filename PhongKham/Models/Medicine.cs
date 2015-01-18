//-----------------------------------------------------------------------
// <copyright file="Medicine.cs" company="emotive GmbH">
//     Copyright (c) emotive GmbH. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Clinic.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Comment for the class
    /// </summary>
    public class Medicine
    {
        #region Fields
        private string name;
        private string hDSD;
        private string activity;

        public string Activity
        {
            get { return activity; }
            set { activity = value; }
        }
        private int number;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public string HDSD
        {
            get { return hDSD; }
            set { hDSD = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int costOut;

        public int CostOut
        {
            get { return costOut; }
            set { costOut = value; }
        }
        private int costIn;

        public int CostIn
        {
            get { return costIn; }
            set { costIn = value; }
        }
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private DateTime inputDay;

        public DateTime InputDay
        {
            get { return inputDay; }
            set { inputDay = value; }
        }

        private string admin;

        public string Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        #endregion

        #region ctors

        #endregion

        #region Properties

        #endregion

        #region Methods

        #endregion
    }
}
