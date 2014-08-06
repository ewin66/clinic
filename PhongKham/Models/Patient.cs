//-----------------------------------------------------------------------
// <copyright file="Patient.cs" company="emotive GmbH">
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
    public class Patient
    {
        #region Fields
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        private int old;
        private DateTime birthday;

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public int Old
        {
            get { return old; }
            set { old = value; }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        private int weight;

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private string symptom;

        public string Symptom
        {
            get { return symptom; }
            set { symptom = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
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
