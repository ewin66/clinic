using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DirectX.Capture;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Clinic.SieuAm
{
    public class SieuAmManager
    {
        private Filters filters;
        private Capture capture;
        private static SieuAmManager instance;
        TemplateCategories templateCategories;

        public TemplateCategories TemplateCategories
        {
            get { return templateCategories; }
        }
        

        public Capture Capture
        {
            get { return capture; }
            set { capture = value; }
        }

        private SieuAmManager()
        {
            try
            {
                filters = new Filters();
            }
            catch
            {
                MessageBox.Show("Không nhận diện được bất kỳ card video! Xin kiểm tra lại");
                return;
            }


            capture = new Capture(filters.VideoInputDevices[0], null);

        }



        public void LoadAllCategoryFromFile()
        {
            if (!File.Exists(ClinicConstant.Categories_FileName))
            {
                templateCategories = new TemplateCategories();
                templateCategories.ListTemplateCategory = new List<TemplateCategory>();
                TemplateCategory categoryTongQuat = new TemplateCategory();
                categoryTongQuat.NameCategory = "Siêu Âm Tổng Quát";
                ControlSieuAm controlSieuAm = new ControlSieuAm();
                controlSieuAm.NameControlDisplayed = "Gan";
                controlSieuAm.ListDefaultValue = new List<string>(){"Cấu trúc echo đồng nhất, mặt gan phẳng, bờ gan đều, kích thước bình thường."};
                controlSieuAm.TypeControl = typeof(TextBox).ToString();
                categoryTongQuat.ListControl = new List<ControlSieuAm>();
                categoryTongQuat.ListControl.Add(controlSieuAm);
                templateCategories.ListTemplateCategory.Add(categoryTongQuat);

                using (StreamWriter sw = new StreamWriter(ClinicConstant.Categories_FileName))
                {
                    XmlSerializer serializer = new XmlSerializer(TemplateCategories.GetType());

                    serializer.Serialize(sw, TemplateCategories);
                }
            }
            TemplateCategories result;
            using (StreamReader sr = new StreamReader(ClinicConstant.Categories_FileName))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TemplateCategories));
                 result = xmlSerializer.Deserialize(sr) as TemplateCategories;
            }
            this.templateCategories= result;

        }

        public static SieuAmManager Instance
        {
            get {
                if (instance == null)
                {
                    instance = new SieuAmManager();
                }
                return instance;
            }
        }
        

    }
}
